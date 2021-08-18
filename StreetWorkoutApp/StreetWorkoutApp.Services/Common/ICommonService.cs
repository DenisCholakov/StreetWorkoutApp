using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Data.Models;

namespace StreetWorkoutApp.Services.Common
{
    public interface ICommonService
    {
        Task<ICollection<string>> GetMuscleGroupNames();

        Task<ICollection<MuscleGroup>> GetMuscleGroupsByNames(List<string> names);
    }
}
