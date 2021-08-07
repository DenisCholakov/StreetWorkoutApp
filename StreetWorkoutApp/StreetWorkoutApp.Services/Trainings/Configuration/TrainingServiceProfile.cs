using AutoMapper;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Trainings.Models;
using System.Linq;

namespace StreetWorkoutApp.Services.Trainings.Configuration
{
    public class TrainingServiceProfile : Profile
    {
        public TrainingServiceProfile()
        {
            CreateMap<Training, TrainingDetailsServiceModel>()
                .ForMember(dest => dest.MuscleGroups,
                opt => opt.MapFrom(src => src.MuscleGroups.Select(x => x.Name)));

            CreateMap<TrainingExercise, TrainingExerciseDetailsServiceModel>();
        }
    }
}
