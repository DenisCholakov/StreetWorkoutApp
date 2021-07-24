using Microsoft.AspNetCore.Mvc;

namespace StreetWorkoutApp.Server.Features
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
