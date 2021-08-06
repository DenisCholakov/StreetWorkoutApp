using System.Collections.Generic;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class CreateExerciseServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public string ExampleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<string> Equipment { get; set; }
    }
}
