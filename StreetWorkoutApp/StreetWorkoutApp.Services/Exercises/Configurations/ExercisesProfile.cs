using AutoMapper;
using System.Linq;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Exercises.Models;
using dataEntities = StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Services.Exercises.Configurations
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<Exercise, ExerciseDetailsServiceModel>()
                .ForMember(dest => dest.MuscleGroups,
                    opt => opt.MapFrom(src => src.MuscleGroups.Select(x => x.Name)));
            CreateMap<dataEntities.Equipment, ExerciseEquipmentServiceModel>();
            CreateMap<ExerciseDetailsServiceModel, Exercise>();
            CreateMap<Exercise, ExerciseServiseModel>()
                .ForMember(dest => dest.MuscleGroups,
                    opt => opt.MapFrom(src => src.MuscleGroups.Select(x => x.Name)));
        }
    }
}
