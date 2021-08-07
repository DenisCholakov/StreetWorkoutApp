using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models.Enums;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class CreateTrainingFormModel
    {
        [Required]
        public string Name { get; set; }

        public bool IsIndoor { get; set; }

        public string GoalExercise { get; set; }

        public int CyclesCount { get; set; }

        [Required]
        public string BreakBetweenExercises { get; set; }

        [Required]
        public string BreakBetweenCycles { get; set; }

        [EnumDataType(typeof(TrainingLevelEnum))]
        public TrainingLevelEnum TrainingLevel { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<TrainingExerciseCreateModel> Exercises { get; set; }
    }
}
