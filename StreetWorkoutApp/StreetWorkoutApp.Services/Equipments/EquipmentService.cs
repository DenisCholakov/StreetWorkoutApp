using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StreetWorkoutApp.Data;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipments.Models;

namespace StreetWorkoutApp.Services.Equipments
{
    public class EquipmentService : IEquipmentService
    {
        private readonly StreetWorkoutDbContext data;

        public EquipmentService(StreetWorkoutDbContext data)
        {
            this.data = data;
        }

        public Task<ICollection<EquipmentServiceModel>> GetAllEquipment()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ICollection<Equipment>> GetEquipmentByNames(List<string> equipmentNames)
        {
            var result = this.data.Equipments.Where(eq => equipmentNames.Contains(eq.Name)).ToList();

            return result;
        }
    }
}
