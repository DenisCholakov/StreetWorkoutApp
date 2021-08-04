using System.Collections.Generic;
using System.Threading.Tasks;

using dataEntities = StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipment.Models;

namespace StreetWorkoutApp.Services.Equipment
{
    public interface IEquipmentService
    {
        Task<ICollection<EquipmentServiceModel>> GetAllEquipment();

        Task<ICollection<string>> GetAllEquipmentNames();

        Task CreateEquipment(EquipmentServiceModel equipment);

        Task<ICollection<dataEntities.Equipment>> GetEquipmentByName(ICollection<string> names);
    }
}
