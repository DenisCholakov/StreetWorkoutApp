using System.Collections.Generic;

namespace StreetWorkoutApp.Data.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
    }
}
