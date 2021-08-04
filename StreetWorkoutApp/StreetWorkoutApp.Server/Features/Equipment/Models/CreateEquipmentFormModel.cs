using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static StreetWorkoutApp.Server.ServerGlobalConstants;

namespace StreetWorkoutApp.Server.Features.Equipment.Models
{
    public class CreateEquipmentFormModel
    {
        [Required]
        public string Name { get; set; }

        [RegularExpression(imageUrlRegexPattern)]
        public string ImageUrl { get; set; }
    }
}
