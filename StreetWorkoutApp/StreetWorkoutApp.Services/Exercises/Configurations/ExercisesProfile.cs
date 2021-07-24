using AutoMapper;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Exercises.Models;

namespace StreetWorkoutApp.Services.Exercises.Configurations
{
    public class ExercisesProfile : Profile
    {
        public ExercisesProfile()
        {
            CreateMap<Exercise, ExerciseDetailsServiceModel>().ReverseMap();
        }
    }
}
