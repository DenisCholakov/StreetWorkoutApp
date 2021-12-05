using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using StreetWorkoutApp.Services.Common;

namespace StreetWorkoutApp.Server.Features.Common
{
    public class CommonController : ApiController
    {
        private readonly ICommonService commonService;

        public CommonController(ICommonService commonService)
        {
            this.commonService = commonService;
        }

        [HttpGet("get-muscle-groups")]
        [SwaggerOperation(
            Summary = "Gets a list with the names of all muscle groups in the database",
            Description = "Gets a list with the names of all muscle groups in the database",
            OperationId = "GetMuscleGroupNames")]

        public ActionResult<ICollection<string>> GetMuscleGroupNames()
        {
            var result = this.commonService.GetMuscleGroupNames();

            return Ok(result);
        }
    }
}
