using System;
using Microsoft.EntityFrameworkCore;

using StreetWorkoutApp.Data;

namespace StreetWorkoutApp.Tests.Moq
{
    public static class DatabaseMock
    {

        public static StreetWorkoutDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<StreetWorkoutDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new StreetWorkoutDbContext(dbContextOptions);
            }
        }
    }
}
