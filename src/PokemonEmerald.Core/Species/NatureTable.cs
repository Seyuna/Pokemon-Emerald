using System;

namespace PokemonEmerald.Core.Species
{
    public static class NatureTable
    {
        private static readonly sbyte[,] Table =
        {
            { 0, 0, 0, 0, 0 }, // Hardy
            { +1, -1, 0, 0, 0 }, // Lonely
            { +1, 0, -1, 0, 0 }, // Brave
            { +1, 0, 0, -1, 0 }, // Adamant
            { +1, 0, 0, 0, -1 }, // Naughty

            { -1, +1, 0, 0, 0 }, // Bold
            { 0, 0, 0, 0, 0 }, // Docile
            { 0, +1, -1, 0, 0 }, // Relaxed
            { 0, +1, 0, -1, 0 }, // Impish
            { 0, +1, 0, 0, -1 }, // Lax

            { -1, 0, +1, 0, 0 }, // Timid
            { 0, -1, +1, 0, 0 }, // Hasty
            { 0, 0, 0, 0, 0 }, // Serious
            { 0, 0, +1, -1, 0 }, // Jolly
            { 0, 0, +1, 0, -1 }, // Naive

            { -1, 0, 0, +1, 0 }, // Modest
            { 0, -1, 0, +1, 0 }, // Mild
            { 0, 0, -1, +1, 0 }, // Quiet
            { 0, 0, 0, 0, 0 }, // Bashful
            { 0, 0, 0, +1, -1 }, // Rash

            { -1, 0, 0, 0, +1 }, // Calm
            { 0, -1, 0, 0, +1 }, // Gentle
            { 0, 0, -1, 0, +1 }, // Sassy
            { 0, 0, 0, -1, +1 }, // Careful
            { 0, 0, 0, 0, 0 } // Quirky
        };

        public static sbyte GetModifier(Nature nature, StatIndex stat)
        {
            var natureIndex = (int)nature;
            var statIndex = ((int)stat) - 1;

            if (natureIndex < 0 || natureIndex >= Table.GetLength(0))
                throw new ArgumentOutOfRangeException(nameof(nature));
            
            if (statIndex < 0 || statIndex >= Table.GetLength(1))
                throw new ArgumentOutOfRangeException(nameof(stat));
            
            return Table[natureIndex, statIndex];
        }
    }
}