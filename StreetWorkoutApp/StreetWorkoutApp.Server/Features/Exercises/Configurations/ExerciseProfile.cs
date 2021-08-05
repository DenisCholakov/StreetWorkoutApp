using AutoMapper;

using StreetWorkoutApp.Server.Features.Exercises.Models;
using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Server.Features.Exercises.Configurations
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<CreateExerciseFormModel, CreateExerciseServiceModel>();
            CreateMap<ExerciseDetailsServiceModel, ExerciseDetailsModel>()
                .ForMember(dest => dest.Equipment, opt => opt.MapFrom(src => src.EquipmentNeeded));
            CreateMap<ExerciseEquipmentServiceModel, ExerciseEquipmentModel>();
        }
    }
}
