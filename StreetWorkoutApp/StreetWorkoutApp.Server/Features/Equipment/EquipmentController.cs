using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using StreetWorkoutApp.Server.Features.Equipment.Models;
using AutoMapper;
using StreetWorkoutApp.Services.Equipment.Models;
using StreetWorkoutApp.Services.Equipment;
using Microsoft.AspNetCore.Authorization;
using StreetWorkoutApp.Server.Infrastructure;

namespace StreetWorkoutApp.Server.Features.Equipment
{
    [Authorize]
    public class EquipmentController : ApiController
    {
        private readonly IEquipmentService equipmentService;
        private readonly IMapper mapper;

        public EquipmentController(IEquipmentService equipmentService, IMapper mapper)
        {
            this.equipmentService = equipmentService;
            this.mapper = mapper;
        }

        [HttpGet("get-names")]
        [SwaggerOperation(
            Summary = "Gets a list with the names of all the quipment in the database",
            Description = "Gets a list with the names of all the quipment in the database",
            OperationId = "GetEquipment")]

        public ActionResult<ICollection<string>> GetEquipmentNames()
        {
            var result = this.equipmentService.GetAllEquipmentNames();

            return Ok(result);
        }

        [HttpPost("add-equipment")]
        [SwaggerOperation(
            Summary = "Adds new equipment to the database",
            Description = "Adds new equipment to the database",
            OperationId = "CreateEquipmentAsync")]

        public async Task<ActionResult> CreateEquipmentAsync([FromBody] CreateEquipmentFormModel equipment)
        {
            var equipmentToAdd = mapper.Map<EquipmentServiceModel>(equipment);

            await this.equipmentService.CreateEquipmentAsync(equipmentToAdd, this.User.GetId());

            return Ok("created");
        }
    }
}
