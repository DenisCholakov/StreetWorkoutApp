using AutoMapper;
using StreetWorkoutApp.Server.Features.Trainings.Models;
using StreetWorkoutApp.Services.Trainings.Models;

namespace StreetWorkoutApp.Server.Features.Trainings.Configurations
{
    public class TrainingsProfile : Profile
    {
        public TrainingsProfile()
        {
            CreateMap<CreateTrainingFormModel, CreateTrainingServiceModel>();
            CreateMap<TrainingExerciseCreateModel, TrainingExerciseCreateServiceModel>();
            CreateMap<TrainingDetailsServiceModel, TrainingDetailsModel>();
            CreateMap<TrainingExerciseDetailsServiceModel, TrainingExerciseDetailsModel>();
        }
    }
}
