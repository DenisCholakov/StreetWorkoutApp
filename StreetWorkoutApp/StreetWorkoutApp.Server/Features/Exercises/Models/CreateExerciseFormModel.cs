using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Server.Features.Exercises.Models
{
    public class CreateExerciseFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(ExerciseLevelEnum))]
        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public string ExampleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<string> EquipmentNeeded { get; set; }
    }
}
