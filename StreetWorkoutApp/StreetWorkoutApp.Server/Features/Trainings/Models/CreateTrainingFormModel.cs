using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StreetWorkoutApp.Data.Models.Enums;

using static StreetWorkoutApp.Server.ServerGlobalConstants;

namespace StreetWorkoutApp.Server.Features.Trainings.Models
{
    public class CreateTrainingFormModel
    {
        [Required]
        [MinLength(trainingNameMinLength)]
        [MaxLength(trainingNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(trainingDescriptionMinLength)]
        [MaxLength(trainingDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsIndoor { get; set; }

        public string GoalExercise { get; set; }

        public int CyclesCount { get; set; }

        [Required]
        [RegularExpression(timeSpanMaximumThreeMinutesRegexPattern)]
        public string BreakBetweenExercises { get; set; }

        [Required]
        [RegularExpression(timeSpanMaximumThreeMinutesRegexPattern)]
        public string BreakBetweenCycles { get; set; }

        public int TrainingLevel { get; set; }

        public ICollection<string> MuscleGroups { get; set; }

        public ICollection<TrainingExerciseCreateModel> Exercises { get; set; }
    }
}
