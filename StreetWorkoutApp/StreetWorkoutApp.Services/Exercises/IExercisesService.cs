using System.Threading.Tasks;

using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises
{
    public interface IExercisesService
    {
        Task<ExerciseDetailsServiceModel> CreateExercisee(CreateExerciseServiceModel exercise);

        Task<ExerciseDetailsServiceModel> GetExerciseDetails(int exerciseId);
    }
}
