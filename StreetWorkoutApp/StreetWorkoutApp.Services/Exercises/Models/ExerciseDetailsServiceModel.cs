using System.Collections.Generic;

using dataEntities = StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Services.Exercises.Models
{
    public class ExerciseDetailsServiceModel
    {
        public string Name { get; set; }

        public string ExamleUrl { get; set; }

        public string ImageUrl { get; set; }

        public ExerciseLevelEnum ExerciseLevel { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<Training> TrainingsForAcheiving { get; set; }

        public ICollection<TrainingExercise> TrainingsIncludedIn { get; set; }

        public ICollection<ExerciseEquipmentServiceModel> EquipmentNeeded { get; set; }
    }
}
