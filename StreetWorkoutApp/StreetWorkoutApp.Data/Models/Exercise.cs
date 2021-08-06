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

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Required]
        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public ICollection<Training> TrainingsForAcheiving { get; set; }

        public ICollection<TrainingExercise> TrainingsIncludedIn { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> EquipmentNeeded { get; set; }

        public ICollection<AppUser> Users { get; set; }
    }
}
