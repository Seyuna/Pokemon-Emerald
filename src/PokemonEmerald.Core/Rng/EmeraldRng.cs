namespace PokemonEmerald.Core.Rng
{
    public class EmeraldRng
    {
        private byte _unknown = 0;

        private uint _randCount = 0;

        private uint _rngValue = 0;
        private uint _rng2Value = 0;
        
        public EmeraldRng(ushort seed)
        {
            SeedRng(seed);
        }

        private static uint Next(uint value)
        {
            return unchecked(1103515245u * value + 24691u);
        }

        public ushort Random()
        {
            _rngValue = Next(_rngValue);
            _randCount++;
            return (ushort)(_rngValue >> 16);
        }

        public ushort Random2()
        {
            _rng2Value = Next(_rng2Value);
            return (ushort)(_rng2Value >> 16);
        }

        public void SeedRng(ushort seed)
        {
            _rngValue = seed;
            _unknown = 0;
        }

        public void SeedRng2(uint seed)
        {
            _rng2Value = seed;
        }

        public uint Random32()
        {
            uint low = Random();
            uint high = Random();

            return low | (high << 16);
        }
    }
}