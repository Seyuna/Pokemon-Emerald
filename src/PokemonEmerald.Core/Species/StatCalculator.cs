namespace PokemonEmerald.Core.Species
{
    public static class StatCalculator
    {
        public static uint Calculate(byte baseStat, byte iv, byte ev, byte level, StatIndex statIndex, Nature nature = Nature.Hardy)
        {
            return statIndex switch
            {
                StatIndex.Hp => CalculateHpStat(baseStat, iv, ev, level),
                _ => CalculateStat(baseStat, iv, ev, level, nature, statIndex)
            };
        }

        private static uint CalculateStat(byte baseStat, byte iv, byte ev, byte level, Nature nature, StatIndex statIndex)
        {
            var statValue = (uint)((((2 * baseStat + iv + ev / 4) * level) / 100) + 5);
            statValue = ApplyNature(statValue, nature, statIndex);
            return statValue;
        }
        
        private static uint CalculateHpStat(byte baseStat, byte iv, byte ev, byte level)
        {
            var n = 2 * baseStat + iv;
            return (uint)((((n + ev / 4) * level) / 100) + level + 10);
        }

        private static uint ApplyNature(uint statValue, Nature nature, StatIndex statIndex)
        {
            var modifier = NatureTable.GetModifier(nature, statIndex);
            return (statValue * (uint)(10 + modifier)) / 10;
        }
    }
}