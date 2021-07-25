using System.Collections.Generic;
using System.Threading.Tasks;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipments.Models;

namespace StreetWorkoutApp.Services.Equipments
{
    public interface IEquipmentService
    {
        Task<ICollection<EquipmentServiceModel>> GetAllEquipment();

        Task<ICollection<Equipment>> GetEquipmentByNames(List<string> equipmentNames);
    }
}
