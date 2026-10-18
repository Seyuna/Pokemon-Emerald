using PokemonEmerald.Core.Moves;
using PokemonEmerald.Core.Moves.Registry;
using PokemonEmerald.Core.Species;

namespace PokemonEmerald.Tests.Moves
{
    [TestFixture]
    public class MoveRegistryTests
    {
        [Test]
        public void MoveCount_MatchesOriginalEmerald()
        {
            Assert.That((int)MoveId.MoveCount, Is.EqualTo(355));
            Assert.That((int)MoveId.None, Is.EqualTo(0));
        }

        [TestCase(1)]   // First Generation I move
        [TestCase(165)] // Last Generation I move
        [TestCase(166)] // First Generation II move
        [TestCase(251)] // Last Generation II move
        [TestCase(252)] // First Generation III move
        [TestCase(354)] // Last Generation III move
        public void Get_GenerationBoundary_ReturnsMatchingId(int id)
        {
            MoveData move = MoveRegistry.Get((MoveId)id);
            Assert.That(move, Is.Not.Null);
            Assert.That(move.Id, Is.EqualTo((MoveId)id));
        }

        [Test]
        public void EveryMoveId_HasMatchingDefinition()
        {
            for (int id = 0; id < (int)MoveId.MoveCount; id++)
            {
                MoveData move;
                bool found = MoveRegistry.TryGet((MoveId)id, out move);

                Assert.That(found, Is.True, "Missing move ID " + id);
                Assert.That(move, Is.Not.Null, "Null move at ID " + id);
                Assert.That(move.Id, Is.EqualTo((MoveId)id), "Wrong move at ID " + id);
                Assert.That(MoveRegistry.Get((MoveId)id), Is.SameAs(move),
                    "Get and TryGet returned different objects at ID " + id);
            }
        }

        [TestCase(-1)]
        [TestCase(355)]
        [TestCase(999)]
        public void TryGet_InvalidId_ReturnsFalseAndNull(int id)
        {
            MoveData move;
            bool found = MoveRegistry.TryGet((MoveId)id, out move);
            Assert.That(found, Is.False);
            Assert.That(move, Is.Null);
        }

        [TestCase(-1)]
        [TestCase(355)]
        [TestCase(999)]
        public void Get_InvalidId_ThrowsKeyNotFoundException(int id)
        {
            Assert.Throws<KeyNotFoundException>(() => MoveRegistry.Get((MoveId)id));
        }

        [Test]
        public void Pound_HasOriginalBattleValues()
        {
            MoveData move = MoveRegistry.Get(MoveId.Pound);
            Assert.Multiple(() =>
            {
                Assert.That(move.Power, Is.EqualTo(40));
                Assert.That(move.Accuracy, Is.EqualTo(100));
                Assert.That(move.Pp, Is.EqualTo(35));
                Assert.That(move.Priority, Is.EqualTo(0));
                Assert.That(move.Type, Is.EqualTo(PokemonType.Normal));
                Assert.That(move.Effect, Is.EqualTo(MoveBattleEffect.Hit));
            });
        }

        [Test]
        public void QuickAttack_HasPriorityOne()
        {
            Assert.That(MoveRegistry.Get(MoveId.QuickAttack).Priority, Is.EqualTo(1));
        }

        [Test]
        public void AllMoves_HaveExpectedRangesAndContestData()
        {
            for (int id = 1; id < (int)MoveId.MoveCount; id++)
            {
                MoveData move = MoveRegistry.Get((MoveId)id);
                Assert.Multiple(() =>
                {
                    Assert.That(move.Accuracy, Is.InRange(0, 100), "Accuracy, ID " + id);
                    Assert.That(move.Pp, Is.GreaterThan(0), "PP, ID " + id);
                    Assert.That(move.SecondaryEffectChance, Is.InRange(0, 100),
                        "Secondary effect chance, ID " + id);
                    Assert.That(move.ComboMoves, Is.Not.Null, "Contest combo list, ID " + id);
                    Assert.That(Enum.IsDefined(typeof(ContestEffect), move.ContestEffect),
                        Is.True, "Contest effect, ID " + id);
                    Assert.That(Enum.IsDefined(typeof(ContestCategory), move.ContestCategory),
                        Is.True, "Contest category, ID " + id);
                    Assert.That(Enum.IsDefined(typeof(MoveTarget), move.Target),
                        Is.True, "Target, ID " + id);
                });
            }
        }

        [Test]
        public void MoveFlags_UseBitMasks()
        {
            Assert.That((int)MoveFlag.MakesContact, Is.EqualTo(1));
            Assert.That((int)MoveFlag.ProtectAffected, Is.EqualTo(2));
            Assert.That((int)MoveFlag.MagicCoatAffected, Is.EqualTo(4));
            Assert.That((int)MoveFlag.SnatchAffected, Is.EqualTo(8));
            Assert.That((int)MoveFlag.MirrorMoveAffected, Is.EqualTo(16));
            Assert.That((int)MoveFlag.KingsRockAffected, Is.EqualTo(32));
        }
    }
}
