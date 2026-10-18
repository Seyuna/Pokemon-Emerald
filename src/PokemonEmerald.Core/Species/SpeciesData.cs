using PokemonEmerald.Core.Abilities;

namespace PokemonEmerald.Core.Species
{
    public sealed class SpeciesData
    {
        public SpeciesId Id { get; set; }
        
        public byte BaseHp { get; set; }
        public byte BaseAttack { get; set; }
        public byte BaseDefense { get; set; }
        public byte BaseSpeed { get; set; }
        public byte BaseSpAttack  { get; set; }
        public byte BaseSpDefense { get; set; }
        
        public PokemonType Type1 { get; set; }
        public PokemonType Type2 { get; set; }
        
        public byte CatchRate { get; set; }
        public byte ExpYield { get; set; }
        public GrowthRate GrowthRate { get; set; }
        
        public byte EvYieldHp { get; set; }
        public byte EvYieldAttack { get; set; }
        public byte EvYieldDefense { get; set; }
        public byte EvYieldSpeed { get; set; }
        public byte EvYieldSpAttack  { get; set; }
        public byte EvYieldSpDefense { get; set; }
        
        public ushort ItemCommon { get; set; }
        public ushort ItemRare { get; set; }
        
        public byte GenderRatio { get; set; }
        public byte EggCycles { get; set; }
        public EggGroup EggGroup1 { get; set; }
        public EggGroup EggGroup2 { get; set; }
        
        public byte Friendship { get; set; }
        public AbilityId Ability1 { get; set; }
        public AbilityId Ability2 { get; set; }
        public byte SafariZoneFleeRate { get; set; }
        public BodyColor BodyColor { get; set; }
        public bool NoFlip { get; set; }
    }
}