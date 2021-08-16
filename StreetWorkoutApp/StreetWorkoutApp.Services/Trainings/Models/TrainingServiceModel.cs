using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Trainings.Models
{
    public class TrainingServiceModel
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
