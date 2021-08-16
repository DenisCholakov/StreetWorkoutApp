using System.Collections.Generic;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class TrainingFiltersModel
    {
        public string SearchTerm { get; set; }

        public bool? IsIndoor { get; set; }

        public bool MyTrainings { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public int? TrainingLevel { get; set; }

        public string GoalExerciseName { get; set; }
    }
}
