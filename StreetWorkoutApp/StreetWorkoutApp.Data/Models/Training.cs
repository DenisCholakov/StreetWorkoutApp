using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models.Enums;

using static StreetWorkoutApp.Data.DataValidationConstants;

namespace StreetWorkoutApp.Data.Models
{
    public class Training
    {

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

        public int CreatorId { get; set; }

        [Required]
        public Trainer Creator { get; set; }

        public TrainingLevelEnum TrainingLevel { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; } = new HashSet<MuscleGroup>();

        public ICollection<TrainingExercise> Exercises { get; set; } = new HashSet<TrainingExercise>();

        public ICollection<AppUser> BookmarkedUsers { get; set; } = new HashSet<AppUser>();
    }
}
