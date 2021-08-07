using System;
using System.Collections.Generic;

using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Services.Trainings.Models
{
    public class TrainingDetailsServiceModel
    {
        public string Name { get; set; }

        public int CyclesCount { get; set; }

        public TimeSpan BreakBetweenExercises { get; set; }

        public TimeSpan BreakBetweenCycles { get; set; }

        public bool IsIndoor { get; set; }

        public int? GoalExerciseId { get; set; }

        public string GoalExerciseName { get; set; }

        public TrainingLevelEnum TrainingLevel { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<string> Exercises { get; set; }
    }
}
