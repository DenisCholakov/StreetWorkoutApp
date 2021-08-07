using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models.Enums;

using static StreetWorkoutApp.Data.DataValidationConstants;

namespace StreetWorkoutApp.Data.Models
{
    public class Training
    {
        public Training()
        {
            this.MuscleGroups = new HashSet<MuscleGroup>();
            this.Exercises = new HashSet<TrainingExercise>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(trainingNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(trainingDescriptionMaxLength)]
        public string Description { get; set; }

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
