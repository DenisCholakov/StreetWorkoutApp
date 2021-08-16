using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using IdentityServer4.Extensions;
using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;
using StreetWorkoutApp.Services.Common;
using StreetWorkoutApp.Services.Exercises;
using StreetWorkoutApp.Services.Trainings.Models;

namespace StreetWorkoutApp.Services.Trainings
{
    public class TrainingsService : ITrainingsService
    {
        private readonly StreetWorkoutDbContext data;
        private readonly IMapper mapper;
        private readonly IExercisesService exerciseService;
        private readonly ICommonService commonService;

        public TrainingsService(
            StreetWorkoutDbContext data,
            IMapper mapper,
            IExercisesService exerciseService, 
            ICommonService commonService)
        {
            this.data = data;
            this.mapper = mapper;
            this.exerciseService = exerciseService;
            this.commonService = commonService;
        }

        public async Task<int> CreateTraining(CreateTrainingServiceModel training)
        {
            if (this.data.Trainings.Any(t => t.Name == training.Name))
            {
                return -1;
            }

            var goalExercise = await exerciseService.GetExerciseByName(training.GoalExercise);
            var muscleGroups = await commonService.GetMuscleGroupsByNames(training.MuscleGroups.ToList());

            if (!Enum.IsDefined(typeof(TrainingLevelEnum), training.TrainingLevel))
            {
                return -1;
            }

            var trainngToAdd = new Training
            {
                Name = training.Name,
                Description = training.Description,
                CyclesCount = training.CyclesCount,
                BreakBetweenCycles = TimeSpan.ParseExact(training.BreakBetweenCycles, "m':'ss", null),
                BreakBetweenExercises = TimeSpan.ParseExact(training.BreakBetweenExercises, "m':'ss", null),
                IsIndoor = training.IsIndoor,
                GoalExercise = goalExercise,
                TrainingLevel = (TrainingLevelEnum)training.TrainingLevel,
                MuscleGroups = muscleGroups
            };

            foreach (var exercise in training.Exercises)
            {
                var exerciseToAdd = await this.exerciseService.GetExerciseByName(exercise.ExerciseName);

                trainngToAdd.Exercises.Add(new TrainingExercise
                {
                    Exercise = exerciseToAdd,
                    Reps = exercise.Reps
                });
            }

            await this.data.Trainings.AddAsync(trainngToAdd);
            await this.data.SaveChangesAsync();

            return trainngToAdd.Id;
        }

        public async Task<FilteredTrainingsServiceResponseModel> GetFilteredTrainings(int currentPage, int resultsPerPage, TrainingFiltersServiceModel filters)
        {
            var allTrainigs = this.data.Trainings.Select(t => new TrainingServiceModel
            {
                Id = t.Id,
                Name = t.Name,
                TrainigLevel = (int)t.TrainingLevel,
                GoalExerciseName = t.GoalExercise.Name,
                IsIndoor = t.IsIndoor,
                MuscleGroups = t.MuscleGroups.Select(mg => mg.Name).ToList(),
                IncludedExerciseNames = t.Exercises.Select(e => e.Exercise.Name).ToList()
            }).ToList();

            allTrainigs = FilterTrainings(filters, allTrainigs);

            var trainingsResponse = new FilteredTrainingsServiceResponseModel
            {
                Trainings = allTrainigs.Skip(currentPage * resultsPerPage).Take(resultsPerPage).ToList(),
                AllTrainingsCount = allTrainigs.Count()
            };

            return trainingsResponse;
        }

        public async Task<TrainingDetailsServiceModel> GetTrainingDetails(int trainingId)
        {
            var training = this.data.Trainings.FirstOrDefault(t => t.Id == trainingId);

            if (training == null)
            {
                return null;
            }

            var result = this.mapper.Map<TrainingDetailsServiceModel>(training);

            return result;
        }

        private static List<TrainingServiceModel> FilterTrainings(TrainingFiltersServiceModel filters, List<TrainingServiceModel> allTrainigs)
        {
            if (!String.IsNullOrWhiteSpace(filters.SearchTerm))
            {
                allTrainigs = allTrainigs
                    .Where(t => t.Name.Contains(filters.SearchTerm, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (filters.IsIndoor != null)
            {
                allTrainigs = allTrainigs.Where(t => t.IsIndoor == filters.IsIndoor).ToList();
            }

            if (!filters.MuscleGroups.IsNullOrEmpty())
            {
                allTrainigs = allTrainigs.Where(t => !filters.MuscleGroups.Intersect(t.MuscleGroups).IsNullOrEmpty()).ToList();
            }

            if (filters.TrainingLevel != null && Enum.IsDefined(typeof(TrainingLevelEnum), filters.TrainingLevel))
            {
                allTrainigs = allTrainigs.Where(t => t.TrainigLevel == filters.TrainingLevel).ToList();
            }

            if (!String.IsNullOrWhiteSpace(filters.GoalExerciseName))
            {
                allTrainigs = allTrainigs.Where(t => t.GoalExerciseName == filters.GoalExerciseName).ToList();
            }

            return allTrainigs;
        }
    }
}
