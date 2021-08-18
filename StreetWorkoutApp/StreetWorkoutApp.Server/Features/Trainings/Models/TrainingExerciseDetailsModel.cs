using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class TrainingExerciseDetailsModel
    {
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        public int Reps { get; set; }
    }
}
