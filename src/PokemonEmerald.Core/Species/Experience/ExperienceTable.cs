using System;

namespace PokemonEmerald.Core.Species.Experience
{
    public static class ExperienceTable
    {

        private static readonly uint[,] Table = CreateTable();

        private static uint[,] CreateTable()
        {
            var table = new uint[6, Config.MaxLevel + 1];

            foreach (GrowthRate growthRate in Enum.GetValues(typeof(GrowthRate)))
            {
                for (byte level = 0; level <= Config.MaxLevel; level++)
                {
                    table[(int)growthRate, level] =
                        ExperienceCalculator.CalculateExperience(level, growthRate);
                }
            }

            return table;
        }

        public static uint GetExperience(GrowthRate growthRate, byte level)
        {
            if ((int)growthRate < 0 || (int)growthRate >= Table.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(growthRate));

            if (level > Config.MaxLevel)
                throw new ArgumentOutOfRangeException(nameof(level));

            return Table[(int)growthRate, level];
        }

        public static byte GetLevelByExperience(GrowthRate growthRate, uint experience)
        {
            byte level = 0;

            while (level < Config.MaxLevel && Table[(int)growthRate, level + 1] <= experience)
                level++;
            
            return level;
        }
    }
}