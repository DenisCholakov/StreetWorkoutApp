using Moq;
using StreetWorkoutApp.Services.Equipment;
using System.Collections.Generic;

namespace StreetWorkoutApp.Tests.Moq
{
    public static class EquipmentServiceMock
    {
        public static IEquipmentService Instance
        {
            get
            {
                var equipmentServiceMock = new Mock<IEquipmentService>();

                equipmentServiceMock.Setup(es => es.GetAllEquipmentNames())
                    .Returns(new List<string> { "Rings", "Dumbells", "Pull Up Bar" });

                return equipmentServiceMock.Object;
            }
        }
    }
}
