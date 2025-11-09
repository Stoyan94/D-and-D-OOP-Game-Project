using DandD_OOP.Utilities;

namespace DandD_OOP.HeroAbsClass
{
    public abstract class Hero
    {
        private const sbyte MinNameLength = 2;
        private const sbyte MaxNameLength = 10;

        private const ushort MinPower = 1000;
        private const ushort MaxPower = 50000;

        private const sbyte MinLevel = 1;
        private const sbyte MaxLevel = 100;

        private const double MinExperience = 0;
        private const double MaxExperiencePerGain = 10000;
        private const double MaxExperience = 1000000;

        private string name;
        private sbyte level = 1;
        private double experience = 0;

        protected Hero(string name, sbyte level, ushort power, double experience)
        {
            Name = name;
            Level = level;
            Power = power;
            Experience = experience;
        }

        public string Name
        {
            get => name;
            private set
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
            private set
            {
                if (value < MinLevel)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.LevelBelowMinimumMessage, MinLevel));
                }

                if (value > MaxLevel)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.LevelExceedMessage, MaxLevel));
                }

                level = value;
            }
        }


        public ushort Power
        {
            get => Power;
            private set
            {
                if (value < MinPower)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.PowerBelowMinimumMessage, MinPower));
                }

                if (value > MaxPower)
                {
                    throw new ArgumentException(string.Format(HeroErrorMessages.PowerExceedMaximumMessage, MaxPower));
                }

                Power = value;
            }
        }

        public double Experience { get; set; }


        protected virtual void CheckLevelUp()
        {
            while (Experience >= GetExperienceForNextLevel())
            {
                Experience -= GetExperienceForNextLevel();
                Level++;
            }
        }

        protected virtual int GetExperienceForNextLevel()
        {
            // Връща нужния опит за текущото ниво
            return ExperienceConfig.ExperienceTable.TryGetValue(Level, out int exp) ? exp : Level * 100;
        }


        protected void GainExperience(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Experience gain cannot be negative.");

            // Ограничаваме максималния опит за едно добавяне
            Experience += Math.Min(amount, MaxExperiencePerGain);

            CheckLevelUp();
        }



    }
}
