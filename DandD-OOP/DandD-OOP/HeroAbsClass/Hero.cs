namespace DandD_OOP.HeroAbsClass
{
    public class Hero
    {
        private const int minLevel = 1;
        protected virtual int maxLevel => 100;

        private const int MinNameLength = 2;

        private string name;
        private int level = 1;

        public Hero(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinNameLength)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.InvalidNameError, MinNameLength));
                }
                name = value;
            }
        }

        public int Level
        {
            get => level;
            set
            {
                if (value < minLevel)
                {
                    throw new ArgumentException();
                }

                if (value > maxLevel)
                {
                    throw new ArgumentException($"Level cannot exceed {maxLevel}.");
                }

                level = value;
            }
        }

    }
}
