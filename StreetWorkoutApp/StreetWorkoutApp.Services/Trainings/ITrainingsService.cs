using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Services.Trainings.Models;

namespace StreetWorkoutApp.Services.Trainings
{
    public interface ITrainingsService
    {
        Task<int> CreateTrainingAsync(CreateTrainingServiceModel training, string userId);

        TrainingDetailsServiceModel GetTrainingDetails(int trainingId);

        FilteredTrainingsServiceResponseModel GetFilteredTrainings(
            int currentPage,
            int resultsPerPage,
            TrainingFiltersServiceModel filters);

        Task<bool> DeleteTrainingAsync(int trainingId, string userId);
    }
}
