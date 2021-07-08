using System.Collections.Generic;

using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Data.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        public string Example { get; set; }

        public ExerciseLevel ExerciseLevel { get; set; }

        public ICollection<Training> TrainingsForAcheiving { get; set; }

        public ICollection<TrainingExercise> TrainingsIncludedIn { get; set; }

        public ICollection<MuscleGroup> MuscleGroups { get; set; }

        public ICollection<Equipment> EquipmentNeeded { get; set; }
    }
}
