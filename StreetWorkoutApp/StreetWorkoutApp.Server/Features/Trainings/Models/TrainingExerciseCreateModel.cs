using System.ComponentModel.DataAnnotations;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class TrainingExerciseCreateModel
    {
        [Required]
        public string ExerciseName { get; set; }

        public int Reps { get; set; }
    }
}
