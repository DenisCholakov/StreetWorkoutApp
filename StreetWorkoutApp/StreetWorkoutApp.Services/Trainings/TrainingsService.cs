using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IExercisesService exerciseService;
        private readonly ICommonService commonService;

        public TrainingsService(
            StreetWorkoutDbContext data,
            IExercisesService exerciseService, 
            ICommonService commonService)
        {
            this.data = data;
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
                BreakBetweenCycles = TimeSpan.Parse(training.BreakBetweenCycles),
                BreakBetweenExercises = TimeSpan.Parse(training.BreakBetweenExercises),
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

        public Task<TrainingDetailsServiceModel> GetTrainingDetails(int trainingId)
        {
            throw new NotImplementedException();
        }
    }
}
