using StreetWorkoutApp.Data.Models;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Services.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
