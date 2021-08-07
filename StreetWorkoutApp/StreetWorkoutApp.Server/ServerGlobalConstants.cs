using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreetWorkoutApp.Server
{
    public class ServerGlobalConstants
    {
        #region regex
        public const string imageUrlRegexPattern = @"(http)?s?:?(\/\/[^""']*\.(?:png|jpg|jpeg|gif|png|svg))";
        public const string timeSpanMaximumThreeMinutes = @"[0-3]:[0-5][0-9]";
        #endregion

        #region exercise
        public const int exerciseNameMinLength = 3;
        public const int exerciseNameMaxLength = 20;
        public const int exerciseDescriptionMinLength = 50;
        public const int exerciseDescriptionMaxLength = 600;
        #endregion

        #region training
        public const int trainingNameMinLength = 5;
        public const int trainingNameMaxLength = 30;
        public const int trainingDescriptionMinLength = 50;
        public const int trainingDescriptionMaxLength = 1000;
        #endregion
    }
}
