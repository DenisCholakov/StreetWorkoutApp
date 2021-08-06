using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class FilteredExercisesServiceResponse
    {
        public ICollection<ExerciseServiseModel> Exercises { get; set; }

        public int AllExercisesCount { get; set; }
    }
}
