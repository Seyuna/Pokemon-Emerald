namespace PokemonEmerald.Core.Moves
{
    public sealed class MoveData
    {
        public MoveId Id { get; set; }
        public byte Power { get; set; }
        public byte Accuracy { get; set; }
        public byte Pp { get; set; }
        public sbyte Priority { get; set; }
        public byte SecondaryEffectChance { get; set; }
        public MoveFlag Flags { get; set; }
        public PokemonEmerald.Core.Species.PokemonType Type { get; set; }
        public MoveBattleEffect Effect { get; set; }
        public MoveTarget Target { get; set; }
        public ContestEffect ContestEffect { get; set; }
        public ContestCategory ContestCategory { get; set; }
        public ContestComboStarter ComboStarter { get; set; }
        public ContestComboStarter[] ComboMoves { get; set; } = new ContestComboStarter[0];
    }
}
