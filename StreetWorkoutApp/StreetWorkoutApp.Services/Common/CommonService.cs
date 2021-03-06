using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly StreetWorkoutDbContext data;

        public CommonService(StreetWorkoutDbContext data)
        {
            this.data = data;
        }

        public ICollection<MuscleGroup> GetMuscleGroupsByNames(List<string> names)
        {
            var muscleGroups = this.data.MuscleGroups.Where(mg => names.Contains(mg.Name)).ToList();

            return muscleGroups;
        }

        public ICollection<string> GetMuscleGroupNames()
        {
            return this.data.MuscleGroups.Select(mg => mg.Name).ToList();
        }
    }
}
