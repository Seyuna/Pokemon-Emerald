using PokemonEmerald.Core.Items;

namespace PokemonEmerald.Core.Species
{
    public sealed class Pokemon
    {
        public SpeciesId Species { get; set; }
        public uint Personality { get; set; }
        public uint OriginalTrainerId  { get; set; }
        
        public uint Experience { get; set; }
        public byte Friendship { get; set; }
        
        public byte Level { get; set; }
        public ushort CurrentHp { get; set; }
        public uint Status { get; set; }
        
        public byte AbilitySlot { get; set; }
        
        public Stats Stats { get; set; }
        public Stats Evs { get; set; }
        public Stats Ivs { get; set; }
        
        public Nature Nature =>
            (Nature)PersonalityHelper.GetNature(Personality);
        public bool IsShiny => PersonalityHelper.IsShiny(Personality, OriginalTrainerId);
        public Gender Gender { get; set; } 
        
        public ItemId HeldItem { get; set; }
    }
}