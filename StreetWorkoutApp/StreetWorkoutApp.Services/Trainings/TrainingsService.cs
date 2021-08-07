using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
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
                return 0;
            }

            var goalExercise = await exerciseService.GetExerciseByName(training.GoalExercise);
            var muscleGroups = await commonService.GetMuscleGroupsByNames(training.MuscleGroups.ToList());

            var trainngToAdd = new Training
            {
                Name = training.Name,
                CyclesCount = training.CyclesCount,
                BreakBetweenCycles = TimeSpan.ParseExact(training.BreakBetweenCycles, "m':'ss", null),
                BreakBetweenExercises = TimeSpan.ParseExact(training.BreakBetweenExercises, "m':'ss", null),
                IsIndoor = training.IsIndoor,
                GoalExercise = goalExercise,
                TrainingLevel = training.TrainingLevel,
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
    }
}
