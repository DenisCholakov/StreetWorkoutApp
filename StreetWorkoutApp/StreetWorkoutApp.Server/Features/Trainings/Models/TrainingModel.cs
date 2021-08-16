using System.Collections.Generic;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class TrainingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TrainigLevel { get; set; }

        public string GoalExerciseName { get; set; }

        public bool IsIndoor { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<string> IncludedExerciseNames { get; set; }
    }
}
