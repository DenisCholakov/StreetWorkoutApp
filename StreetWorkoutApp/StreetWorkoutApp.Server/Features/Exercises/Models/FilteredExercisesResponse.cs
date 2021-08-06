using System.Collections.Generic;

namespace StreetWorkoutApp.Server.Features.Exercises.Models
{
    public class FilteredExercisesResponse
    {
        public ICollection<ExerciseModel> Exercises { get; set; }

        public int AllExercisesCount { get; set; }
    }
}
