using System;
using System.Collections.Generic;
using PokemonEmerald.Core.Moves;
namespace PokemonEmerald.Core.Moves.Registry
{
    public static partial class MoveRegistry
    {
        private static readonly MoveData[] Moves = CreateMoves();
        private static MoveData[] CreateMoves()
        {
            var data = new MoveData[(int)MoveId.MoveCount];
            PopulateGen1(data);
            PopulateGen2(data);
            PopulateGen3(data);
            return data;
        }
        static partial void PopulateGen1(MoveData[] data);
        static partial void PopulateGen2(MoveData[] data);
        static partial void PopulateGen3(MoveData[] data);
        public static bool TryGet(MoveId id, out MoveData move)
        {
            int i = (int)id;
            move = i >= 0 && i < Moves.Length ? Moves[i] : null;
            return move != null;
        }
        public static MoveData Get(MoveId id)
        {
            MoveData move;
            if (!TryGet(id, out move)) throw new KeyNotFoundException("No move definition for " + id);
            return move;
        }
    }
}
