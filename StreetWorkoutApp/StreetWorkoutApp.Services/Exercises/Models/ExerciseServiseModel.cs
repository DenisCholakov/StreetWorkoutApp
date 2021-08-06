using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class ExerciseServiseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string[] MuscleGroups { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }
    }
}
