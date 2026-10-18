namespace PokemonEmerald.Core.Moves
{
    [System.Flags]
    public enum MoveFlag : byte
    {
        None = 0,
        MakesContact = 1,
        ProtectAffected = 2,
        MagicCoatAffected = 4,
        SnatchAffected = 8,
        MirrorMoveAffected = 16,
        KingsRockAffected = 32,
    }
}
