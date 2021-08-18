using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StreetWorkoutApp.Data.Models.Enums;

using static StreetWorkoutApp.Data.DataValidationConstants;

namespace StreetWorkoutApp.Data.Models
{
    public class Exercise
    {
        public Exercise()
        {
            this.TrainingsForAcheiving = new HashSet<Training>();
            this.TrainingsIncludedIn = new HashSet<TrainingExercise>();
            this.MuscleGroups = new HashSet<MuscleGroup>();
            this.EquipmentNeeded = new HashSet<Equipment>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(exerciseNameMaxLength)]
        public string Name { get; set; }

        public string ExampleUrl { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CreatorId { get; set; }

        [Required]
        public Trainer Creator { get; set; }

        [Required]
        [MaxLength(exerciseDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public ICollection<Training> TrainingsForAcheiving { get; set; } = new HashSet<Training>();

        public ICollection<TrainingExercise> TrainingsIncludedIn { get; set; } = new HashSet<TrainingExercise>();

        public ICollection<MuscleGroup> MuscleGroups { get; set; } = new HashSet<MuscleGroup>();

        public ICollection<Equipment> EquipmentNeeded { get; set; } = new HashSet<Equipment>();

        public ICollection<AppUser> BookmarkedUsers { get; set; } = new HashSet<AppUser>();
    }
}
