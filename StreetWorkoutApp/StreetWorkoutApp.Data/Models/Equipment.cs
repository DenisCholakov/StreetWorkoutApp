using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutApp.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
