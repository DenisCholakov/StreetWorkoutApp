using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Data.Models
{
    public class TrainingExercise
    {
        public int Id { get; set; }

        public int Reps { get; set; }

        public Training Training { get; set; }

        public Exercise Exercise { get; set; }
    }
}
