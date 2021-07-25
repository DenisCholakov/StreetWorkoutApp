using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using StreetWorkoutApp.Services.Equipments;

namespace StreetWorkoutApp.Server.Features.Equipment
{
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentService equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }

        [HttpGet("all")]
        [SwaggerOperation(
            Summary = "Gets a list with the names of all the quipment in the database",
            Description = "Gets a list with the names of all the quipment in the database",
            OperationId = "GetEquipment")]

        public async Task<ActionResult<ICollection<string>>> GetEquipmentNames()
        {
            var equipment = await this.equipmentService.GetAllEquipment();

            var result = equipment.Select(x => x.Name);

            return Ok(result);
        }
    }
}
