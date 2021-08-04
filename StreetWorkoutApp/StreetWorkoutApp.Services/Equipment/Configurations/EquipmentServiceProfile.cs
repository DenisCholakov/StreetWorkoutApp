using AutoMapper;
using StreetWorkoutApp.Services.Equipment.Models;
using dataEntities = StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Services.Equipment.Configurations
{
    public class EquipmentServiceProfile : Profile
    {
        public EquipmentServiceProfile()
        {
            CreateMap<EquipmentServiceModel, dataEntities.Equipment>().ReverseMap();
        }
    }
}
