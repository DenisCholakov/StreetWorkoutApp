using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StreetWorkoutApp.Data.Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<Exercise> FavouriteExercises { get; set; } = new HashSet<Exercise>();

        public ICollection<Training> FavouriteTrainings { get; set; } = new HashSet<Training>();
    }
}
