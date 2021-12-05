using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises
{
    public interface IExercisesService
    {
        Task<int> CreateExerciseAsync(CreateExerciseServiceModel exercise, string userId);

        Task<int> EditExerciseAsync(CreateExerciseServiceModel model, int exerciseId, string userId);

        Task<bool> DeleteExerciseAsync(int exerciseId, string userId);

        ExerciseDetailsServiceModel GetExerciseDetails(int exerciseId);

        FilteredExercisesServiceResponse GetFileteredExercises(
            ExerciseFilterServiceModel filters,
            int currentPage,
            int resultsPerPage);

        Task<Exercise> GetExerciseByNameAsync(string exerciseName);

        ICollection<string> GetAllExerciseNames();
    }
}
