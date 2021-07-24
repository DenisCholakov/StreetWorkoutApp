using System.Collections.Generic;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class CreateExerciseServiceModel
    {
        public string Name { get; set; }

        public ExerciseLevel ExerciseLevel { get; set; }

        public string ExampleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> EquipmentNeeded { get; set; }
    }
}
