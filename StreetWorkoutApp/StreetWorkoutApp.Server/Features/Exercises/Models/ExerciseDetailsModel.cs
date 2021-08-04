using System.Collections.Generic;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Server.Features.Exercises.Models
{
    public class ExerciseDetailsModel
    {
        public string Name { get; set; }

        public string ExamleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public ICollection<Training> TrainingsForAcheiving { get; set; }

        public ICollection<TrainingExercise> TrainingsIncludedIn { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<ExerciseEquipmentModel> Equipment { get; set; }
    }
}
