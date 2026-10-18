using System;
using System.Collections.Generic;

namespace PokemonEmerald.Core.Species.Registry
{
    public static partial class SpeciesRegistry
    {
        private static readonly SpeciesData?[] Species = CreateSpecies();

        private static SpeciesData[] CreateSpecies()
        {
            var data = new SpeciesData[(int)SpeciesId.UnownZ + 1];
            PopulateGen1(data);
            PopulateGen2(data);
            PopulateGen3(data);
            return data;
        }
        
        static partial void PopulateGen1(SpeciesData[] data);
        static partial void PopulateGen2(SpeciesData[] data);
        static partial void PopulateGen3(SpeciesData[] data);

        public static bool TryGet(SpeciesId id, out SpeciesData? species)
        {
            var index = (int)id;
            if (index < 0 || index >= Species.Length)
            {
                species = null;
                return false;
            }
            
            species = Species[index];
            return species != null;
        }

        public static SpeciesData? Get(SpeciesId id)
        {
            SpeciesData? result;
            return !TryGet(id, out result) 
                ? throw new KeyNotFoundException("No species definition for " + id) 
                : result;
        }
    }
}