
using System;

namespace PokemonEmerald.Core.Species.Experience
{
    public static class ExperienceCalculator
    {
        public static uint CalculateExperience(byte level, GrowthRate growthRate)
        {
            return level switch
            {
                > 100 => throw new ArgumentOutOfRangeException(nameof(level)),
                0 => 0,
                1 => 1,
                _ => growthRate switch
                {
                    GrowthRate.MediumFast => CalculateMediumFast(level),
                    GrowthRate.Erratic => CalculateErratic(level),
                    GrowthRate.Fluctuating => CalculateFluctuating(level),
                    GrowthRate.MediumSlow => CalculateMediumSlow(level),
                    GrowthRate.Fast => CalculateFast(level),
                    GrowthRate.Slow => CalculateSlow(level),
                    _ => throw new ArgumentOutOfRangeException(nameof(growthRate))
                }
            };
        }

        private static uint CalculateMediumFast(byte level)
        {
            uint n = level;
            return n * n * n;
        }

        private static uint CalculateErratic(byte level)
        {
            uint n = level;
            var cube = n * n * n;

            return n switch
            {
                <= 50 => ((100 - n) * cube) / 50,
                <= 68 => ((150 - n) * cube) / 100,
                <= 98 => (((1911 - 10 * n) / 3) * cube) / 500,
                _ => ((160 - n) * cube) / 100
            };
        }

        private static uint CalculateFluctuating(byte level)
        {
            uint n = level;
            var cube = n * n * n;

            return n switch
            {
                <= 15 => (((n + 1) / 3 + 24) * cube) / 50,
                <= 36 => ((n + 14) * cube) / 50,
                _ => ((n / 2 + 32) * cube) / 50
            };
        }

        private static uint CalculateMediumSlow(byte level)
        {
            int n = level;
            var cube = n * n * n;
            var square = n * n;

            var experience =
                (6 * cube) / 5
                - (15 * square)
                + (100 * n)
                - 140;

            return (uint)experience;
        }

        private static uint CalculateFast(byte level)
        {
            uint n = level;
            var cube = n * n * n;

            return (4 * cube) / 5;
        }

        private static uint CalculateSlow(byte level)
        {
            uint n = level;
            var cube = n * n * n;

            return (5 * cube) / 4;
        }
    }
}
