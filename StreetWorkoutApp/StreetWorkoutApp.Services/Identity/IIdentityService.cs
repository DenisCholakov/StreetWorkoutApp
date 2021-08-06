namespace StreetWorkoutApp.Services.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);

        string GetLoggedUserId();
    }
}
