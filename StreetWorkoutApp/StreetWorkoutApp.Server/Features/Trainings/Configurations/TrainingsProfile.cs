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
            CreateMap<TrainingFiltersModel, TrainingFiltersServiceModel>();
            CreateMap<FilteredTrainingsServiceResponseModel, FilteredTrainingsResponseModel>();
            CreateMap<TrainingServiceModel, TrainingModel>();
        }
    }
}
