using StreetWorkoutApp.Data.Models.Enums;
using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Trainings.Models
{
    public class CreateTrainingServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsIndoor { get; set; }

        public string GoalExercise { get; set; }

        public int CyclesCount { get; set; }

        public string BreakBetweenExercises { get; set; }

        public string BreakBetweenCycles { get; set; }

        public int TrainingLevel { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<TrainingExerciseCreateServiceModel> Exercises { get; set; }
    }
}
