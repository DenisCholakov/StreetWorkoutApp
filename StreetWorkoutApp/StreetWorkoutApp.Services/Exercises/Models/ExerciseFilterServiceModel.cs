using StreetWorkoutApp.Data.Models.Enums;
using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class ExerciseFilterServiceModel
    {
        public string SearchTerm { get; set; }

        public bool MyExercises { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }
    }
}
