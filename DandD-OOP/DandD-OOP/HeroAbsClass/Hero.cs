using DandD_OOP.Utilities;

namespace DandD_OOP.HeroAbsClass
{
    public abstract class Hero
    {
        private const sbyte MinNameLength = 2;
        private const sbyte MaxNameLength = 10;

        private const ushort MinPower = 1000;
        private const ushort MaxPower = 50_000;

        private const sbyte MinLevel = 1;
        private const sbyte MaxLevel = 100;

        private const double MinExperience = 0;
        private const double MaxExperiencePerGain = 10_000;
        private const double MaxExperience = 100_000_000;

        private string name;
        private sbyte level = 1;
        private ushort power = 1000;
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
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.InvalidNameMessage, nameof(Name), MinNameLength));
                }

                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.NameTooLongMessage, nameof(Name), MaxNameLength));
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
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.LevelBelowMinimumMessage, nameof(Level), MinLevel));
                }

                if (value > MaxLevel)
                {
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.LevelExceedMessage, nameof(Level), MaxLevel));
                }

                level = value;
            }
        }

        public ushort Power
        {
            get => power;
            private set
            {
                if (value < MinPower)
                {
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.PowerBelowMinimumMessage, nameof(Power), MinPower));
                }

                if (value > MaxPower)
                {
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.PowerExceedMaximumMessage, nameof(Power), MaxPower));
                }

                power = value;
            }
        }

        public double Experience
        {
            get => experience;
            private set
            {
                if (value < MinExperience)
                {
                    throw new ArgumentException(
                        string.Format(HeroErrorMessages.NegativeExperienceMessage, nameof(Experience)));
                }

                experience = value;
            }
        }


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
            return ExperienceConfig.ExperienceTable.TryGetValue(Level, out int exp) ? exp : Level * 100;
        }


        protected void GainExperience(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Experience gain cannot be negative.");
            }

            Experience += Math.Min(amount, MaxExperiencePerGain);

            CheckLevelUp();
        }



    }
}
