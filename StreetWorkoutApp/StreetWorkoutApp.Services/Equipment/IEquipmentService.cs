using System.Collections.Generic;
using System.Threading.Tasks;

using dataEntities = StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipment.Models;

namespace StreetWorkoutApp.Services.Equipment
{
    public interface IEquipmentService
    {
        ICollection<EquipmentServiceModel> GetAllEquipment();

        ICollection<string> GetAllEquipmentNames();

        ICollection<dataEntities.Equipment> AddEquipmentToTraining(
            dataEntities.Exercise exercise,
            ICollection<string> equipmentNames);

        Task CreateEquipmentAsync(EquipmentServiceModel equipment, string userId);

        ICollection<dataEntities.Equipment> GetEquipmentByName(ICollection<string> names);
    }
}
