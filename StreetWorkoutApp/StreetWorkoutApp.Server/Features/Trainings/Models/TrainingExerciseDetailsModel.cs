using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class TrainingExerciseDetailsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Reps { get; set; }
    }
}
