namespace PokemonEmerald.Core.Species
{
    public struct Stats
    {
        public ushort Hp;
        public ushort Attack;
        public ushort Defense;
        public ushort Speed;
        public ushort SpAttack;
        public ushort SpDefense;

        public static Stats Empty()
        {
            return new Stats
            {
                Hp = 0,
                Attack = 0,
                Defense = 0,
                Speed = 0,
                SpAttack = 0,
                SpDefense = 0
            };
        }
    }
}