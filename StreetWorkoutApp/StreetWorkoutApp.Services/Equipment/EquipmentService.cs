using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

using StreetWorkoutApp.Data;
using dataEntities = StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipment.Models;

namespace StreetWorkoutApp.Services.Equipment
{
    public class EquipmentService : IEquipmentService
    {
        private readonly StreetWorkoutDbContext data;
        private readonly IMapper mapper;

        public EquipmentService(StreetWorkoutDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }
        public async Task CreateEquipment(EquipmentServiceModel equipment)
        {
            var equipmentToAdd = this.mapper.Map<dataEntities.Equipment>(equipment);

            await this.data.Equipments.AddAsync(equipmentToAdd);
            await this.data.SaveChangesAsync();
        }

        public async Task<ICollection<EquipmentServiceModel>> GetAllEquipment()
        {
            var allEquipment = this.data.Equipments.ToList();

            var result = this.mapper.Map<List<EquipmentServiceModel>>(allEquipment);

            return result;
        }

        public async Task<ICollection<string>> GetAllEquipmentNames()
        {
            var allEquipmentNames = this.data.Equipments.Select(x => x.Name).ToList();

            return allEquipmentNames;
        }

        public async Task<ICollection<dataEntities.Equipment>> GetEquipmentByName(ICollection<string> names)
        {
            var equipment = this.data.Equipments.Where(x => names.Contains(x.Name)).ToList();

            return equipment;
        }
    }
}
