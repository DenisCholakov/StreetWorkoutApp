using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

using StreetWorkoutApp.Data;
using dataEntities = StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Services.Equipment.Models;
using System;

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

        public async Task CreateEquipmentAsync(EquipmentServiceModel equipment, string userId)
        {
            if (this.data.Equipments.Any(e => e.Name == equipment.Name))
            {
                throw new InvalidOperationException("The name of the quipment is already used.");
            }

            var creator = this.data.Trainers.FirstOrDefault(t => t.UserId == userId);

            if (creator == null)
            {
                throw new InvalidOperationException("The user is not a trainer!");
            }

            var equipmentToAdd = this.mapper.Map<dataEntities.Equipment>(equipment);

            await this.data.Equipments.AddAsync(equipmentToAdd);
            await this.data.SaveChangesAsync();
        }

        public ICollection<EquipmentServiceModel> GetAllEquipment()
        {
            var allEquipment = this.data.Equipments.ToList();

            var result = this.mapper.Map<List<EquipmentServiceModel>>(allEquipment);

            return result;
        }

        public ICollection<string> GetAllEquipmentNames()
        {
            var allEquipmentNames = this.data.Equipments.Select(x => x.Name).ToList();

            return allEquipmentNames;
        }

        public ICollection<dataEntities.Equipment> GetEquipmentByName(ICollection<string> names)
        {
            var equipment = this.data.Equipments.Where(x => names.Contains(x.Name)).ToList();

            return equipment;
        }

        public ICollection<dataEntities.Equipment> AddEquipmentToTraining(
            dataEntities.Exercise exercise,
            ICollection<string> equipmentNames)
        {
            var equipmentToAdd = this.data.Equipments.Where(eq => equipmentNames.Contains(eq.Name)).ToList();

            foreach (var equipment in equipmentToAdd)
            {
                if (!exercise.EquipmentNeeded.Contains(equipment) && equipmentToAdd != null)
                {
                    exercise.EquipmentNeeded.Add(equipment);
                }
            }

            return equipmentToAdd;
        }
    }
}
