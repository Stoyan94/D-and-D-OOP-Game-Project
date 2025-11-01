namespace DandD_OOP
{
    static class HeroErrorMessages
    {
        internal const string InvalidNameMessage =
            "Hero name cannot be empty and must contain at least {0} letters.";

        internal const string NameTooLongMessage = "Hero name cannot exceed {0} letters.";



        internal const string LevelExceedMessage = "Level cannot exceed {0}";

        internal const string LevelBelowMinimumMessage = "Level cannot be below {0}";


        internal const string PowerBelowMinimumMessage = "Hero power cannot be below {0}.";

        internal const string PowerExceedMaximumMessage = "Hero power cannot exceed {0}.";
    }
}
