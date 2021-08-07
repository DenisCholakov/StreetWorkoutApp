﻿using System.Text.RegularExpressions;

namespace StreetWorkoutApp.Data
{
    public class DataValidationConstants
    {
        #region exercise
        public const int exerciseNameMaxLength = 20;
        public const int exerciseDescriptionMinLength = 50;
        public const int exerciseDescriptionMaxLength = 600;
        #endregion

        #region training
        public const int trainingNameMaxLength = 30;
        public const int trainingDescriptionMinLength = 50;
        public const int trainingDescriptionMaxLength = 1000;
        #endregion
    }
}
