using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutApp.Data.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<Training> CreatedTrainings { get; set; } = new HashSet<Training>();
    }
}
