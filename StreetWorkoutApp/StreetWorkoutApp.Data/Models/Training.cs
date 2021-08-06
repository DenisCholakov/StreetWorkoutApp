using System;
using System.Collections.Generic;

using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Data.Models
{
    public class Training
    {
        public int Id { get; set; }

        public int CyclesCount { get; set; }

        public TimeSpan BreakBetweenExercises { get; set; }

        public TimeSpan BreakBetweenCycles { get; set; }

        public bool IsIndoor { get; set; }

        public int? GoalExerciseId { get; set; }

        public Exercise GoalExercise { get; set; }

        public TrainingLevelEnum TrainingLevel { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<TrainingExercise> Exercises { get; set; }
    }
}
