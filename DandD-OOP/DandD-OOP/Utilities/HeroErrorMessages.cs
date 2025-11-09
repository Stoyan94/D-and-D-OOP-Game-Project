namespace DandD_OOP.Utilities
{
    static class HeroErrorMessages
    {
        internal const string InvalidNameMessage = 
            "{0} cannot be empty and must contain at least {1} letters.";

        internal const string NameTooLongMessage = "{0} cannot exceed {1} letters.";

        internal const string LevelExceedMessage = "{0} cannot exceed {1}";
        internal const string LevelBelowMinimumMessage = "{0} cannot be below {1}";


        internal const string PowerBelowMinimumMessage = "{0} cannot be below {1}";
        internal const string PowerExceedMaximumMessage = "{0} cannot exceed {1}";


        internal const string NegativeExperienceMessage = "{0} gain cannot be negative.";
    }
}
