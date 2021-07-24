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
        [EnumDataType(typeof(ExerciseLevel))]
        public ExerciseLevel ExerciseLevel { get; set; }

        public string ExampleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> EquipmentNeeded { get; set; }
    }
}
