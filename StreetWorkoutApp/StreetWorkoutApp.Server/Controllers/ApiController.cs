using Microsoft.AspNetCore.Mvc;

namespace StreetWorkoutApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
