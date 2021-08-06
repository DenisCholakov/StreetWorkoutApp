using StreetWorkoutApp.Data.Models.Enums;
using System.Collections.Generic;

namespace StreetWorkoutApp.Server.Features.Exercises.Models
{
    public class ExerciseFiltersModel
    {
        public string SearchTerm { get; set; }

        public bool MyExercises { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }
    }
}
