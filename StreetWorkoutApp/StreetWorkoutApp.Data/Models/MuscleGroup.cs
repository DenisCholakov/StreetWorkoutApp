using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Data.Models
{
    public class MuscleGroup
    {
        public MuscleGroup()
        {
            this.ExercisesForMuscleGroup = new HashSet<Exercise>();
            this.TrainingsForMuscleGroup = new HashSet<Training>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Exercise> ExercisesForMuscleGroup { get; set; }

        public IEnumerable<Training> TrainingsForMuscleGroup { get; set; }
    }
}
