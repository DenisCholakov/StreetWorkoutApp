using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Services.Common
{
    public interface ICommonService
    {
        ICollection<string> GetMuscleGroupNames();

        ICollection<MuscleGroup> GetMuscleGroupsByNames(List<string> names);
    }
}
