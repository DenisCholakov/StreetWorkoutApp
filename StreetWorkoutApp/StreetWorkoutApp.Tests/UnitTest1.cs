using System.Collections.Generic;
using AutoMapper;
using Moq;
using Xunit;

using StreetWorkoutApp.Server.Features.Equipment;
using StreetWorkoutApp.Tests.Moq;
using Microsoft.AspNetCore.Mvc;

namespace StreetWorkoutApp.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("2", 2.ToString());
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 3, 5)]
        [InlineData(5, 5, 10)]
        public void Test2(int x, int y, int sum)
        {
            Assert.Equal(sum, x + y);
        }

        [Fact]
        public void GetEquipmentNameShouldReturnEquipmentNames()
        {
            var equipmentController = new EquipmentController(EquipmentServiceMock.Instance, Mock.Of<IMapper>());

            var response = equipmentController.GetEquipmentNames();

            var expectedResult = new List<string> { "Rings", "Dumbells", "Pull Up Bar" };

            Assert.NotNull(response);
            var result = Assert.IsType<OkObjectResult>(response.Result);
            Assert.Equal(expectedResult, result.Value);
        }
    }
}
