namespace StreetWorkoutApp.Server
{
    public class ServerGlobalConstants
    {
        #region regex
        public const string imageUrlRegexPattern = @"(http)?s?:?(\/\/[^""']*\.(?:png|jpg|jpeg|gif|png|svg))";
        public const string emailRegexPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public const string timeSpanMaximumThreeMinutesRegexPattern = @"[0-3]:[0-5][0-9]";
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
