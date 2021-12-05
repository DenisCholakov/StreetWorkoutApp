using AutoMapper;
using StreetWorkoutApp.Services.Equipment;
using StreetWorkoutApp.Services.Equipment.Configurations;
using Xunit;

namespace StreetWorkoutApp.Tests.Unit.Services
{
    public class EquipmentServiceTests
    {
        [Fact]
        public void GetAllEquipmentShouldEquipmentCollection()
        {
            // Arrange

            var mapper = this.CretaeAutomapper
            var equipmentService = new EquipmentService()
        }


        private IMapper CreateAutomapper()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EquipmentServiceProfile>();
            });

            return new Mapper(mapperConfiguration);
        }
    }
}
