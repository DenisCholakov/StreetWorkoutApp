using System.Security.Claims;

namespace StreetWorkoutApp.Server.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static string GetUserName(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.Name).Value;
    }
}
