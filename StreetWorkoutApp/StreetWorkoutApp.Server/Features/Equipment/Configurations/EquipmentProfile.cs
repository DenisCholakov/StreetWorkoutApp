using AutoMapper;

using StreetWorkoutApp.Server.Features.Equipment.Models;
using StreetWorkoutApp.Services.Equipment.Models;

namespace StreetWorkoutApp.Server.Features.Equipment.Configurations
{
    public class EquipmentProfile : Profile
    {
        public EquipmentProfile()
        {
            CreateMap<CreateEquipmentFormModel, EquipmentServiceModel>();
        }
    }
}
