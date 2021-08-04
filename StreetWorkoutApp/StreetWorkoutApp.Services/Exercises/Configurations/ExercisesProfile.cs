using AutoMapper;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Exercises.Models;
using System.Linq;

namespace StreetWorkoutApp.Services.Exercises.Configurations
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<Exercise, ExerciseDetailsServiceModel>()
                .ForMember(dest => dest.MuscleGroups,
                    opt => opt.MapFrom(src => src.MuscleGroups.Select(x => x.Name)));
            CreateMap<ExerciseDetailsServiceModel, Exercise>();
        }
    }
}
