using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StreetWorkoutApp.Data.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Exercise> Exercises { get; set; } = new HashSet<Exercise>();
    }
}
