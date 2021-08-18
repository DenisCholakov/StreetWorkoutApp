using System.Collections.Generic;

namespace StreetWorkoutApp.Services.Trainings.Models
{
    public class FilteredTrainingsServiceResponseModel
    {
        public ICollection<TrainingServiceModel> Trainings { get; set; }

        public int AllTrainingsCount { get; set; }
    }
}
