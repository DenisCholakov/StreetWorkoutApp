using System.ComponentModel.DataAnnotations;

using static StreetWorkoutApp.Server.ServerGlobalConstants;

namespace StreetWorkoutApp.Server.Features.Identity.Models
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(emailRegexPattern)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
