using System.Threading.Tasks;

using StreetWorkoutApp.Services.Trainings.Models;

namespace StreetWorkoutApp.Services.Trainings
{
    public interface ITrainingsService
    {
        Task<int> CreateTraining(CreateTrainingServiceModel training);

        Task<TrainingDetailsServiceModel> GetTrainingDetails(int trainingId);
    }
}
