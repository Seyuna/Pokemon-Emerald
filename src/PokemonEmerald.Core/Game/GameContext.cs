using PokemonEmerald.Core.Rng;

namespace PokemonEmerald.Core.Game
{
    public class GameContext
    {
        public EmeraldRng Rng { get; }

        public GameContext()
        {
            Rng = new EmeraldRng(123);
        }
        
    }
}