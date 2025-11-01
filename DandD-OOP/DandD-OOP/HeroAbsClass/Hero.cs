namespace DandD_OOP.HeroAbsClass
{
    public class Hero
    {
        private const sbyte MinNameLength = 2;
        private const sbyte MaxNameLength = 10;

        private const sbyte minLevel = 1;
        protected virtual sbyte maxLevel => 100;

        private string name;
        private sbyte level = 1;

        public Hero(string name, sbyte level)
        {
            Name = name;
            Level = level;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.InvalidNameMessage, MinNameLength));
                }

                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.NameTooLongMessage, MaxNameLength));
                }

                name = value;
            }
        }

        public sbyte Level
        {
            get => level;
            set
            {
                if (value < minLevel)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.LevelBelowMinimumMessage, minLevel));
                }

                if (value > maxLevel)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.LevelExceedMessage, maxLevel));
                }

                level = value;
            }
        }

    }
}
