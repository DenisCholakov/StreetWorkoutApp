using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Trainings.Models
{
    public class TrainingFiltersServiceModel
    {
        public string SearchTerm { get; set; }

        public bool? IsIndoor { get; set; }

        public bool MyTrainings { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public int? TrainingLevel { get; set; }

        public string GoalExerciseName { get; set; }
    }
}
