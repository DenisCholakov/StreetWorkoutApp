using System.Collections.Generic;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class FilteredTrainingsResponseModel
    {
        public ICollection<TrainingModel> Trainings { get; set; }

        public int AllTrainingsCount { get; set; }
    }
}
