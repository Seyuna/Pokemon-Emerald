namespace PokemonEmerald.Core.Moves
{
    public enum MoveTarget : byte
    {
        Selected = 0,
        Depends = 1,
        UserOrSelected = 2,
        Random = 4,
        Both = 8,
        User = 16,
        FoesAndAlly = 32,
        OpponentsField = 64,
    }
}
