using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models.Enums;

using static StreetWorkoutApp.Server.ServerGlobalConstants;

namespace StreetWorkoutApp.Server.Features.Exercises.Models
{
    public class CreateExerciseFormModel
    {
        [Required]
        [MinLength(exerciseNameMinLength)]
        [MaxLength(exerciseNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(exerciseDescriptionMinLength)]
        [MaxLength(exerciseDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(ExerciseLevelEnum))]
        public int ExerciseLevel { get; set; }

        public string ExampleUrl { get; set; }

        [Required]
        [RegularExpression(imageUrlRegexPattern)]
        public string ImageUrl { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<string> Equipment { get; set; }
    }
}
