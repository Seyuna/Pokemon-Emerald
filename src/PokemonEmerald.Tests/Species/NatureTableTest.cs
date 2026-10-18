using PokemonEmerald.Core.Species;

namespace PokemonEmerald.Tests.Species
{
    [TestFixture]
    public class NatureTableTests
    {
        // Expected values are ordered:
        // Attack, Defense, Speed, SpAttack, SpDefense

        [TestCase(Nature.Hardy,   0,  0,  0,  0,  0)]
        [TestCase(Nature.Lonely,  1, -1,  0,  0,  0)]
        [TestCase(Nature.Brave,   1,  0, -1,  0,  0)]
        [TestCase(Nature.Adamant, 1,  0,  0, -1,  0)]
        [TestCase(Nature.Naughty, 1,  0,  0,  0, -1)]

        [TestCase(Nature.Bold,   -1,  1,  0,  0,  0)]
        [TestCase(Nature.Docile,  0,  0,  0,  0,  0)]
        [TestCase(Nature.Relaxed, 0,  1, -1,  0,  0)]
        [TestCase(Nature.Impish,  0,  1,  0, -1,  0)]
        [TestCase(Nature.Lax,     0,  1,  0,  0, -1)]

        [TestCase(Nature.Timid,  -1,  0,  1,  0,  0)]
        [TestCase(Nature.Hasty,   0, -1,  1,  0,  0)]
        [TestCase(Nature.Serious, 0,  0,  0,  0,  0)]
        [TestCase(Nature.Jolly,   0,  0,  1, -1,  0)]
        [TestCase(Nature.Naive,   0,  0,  1,  0, -1)]

        [TestCase(Nature.Modest, -1,  0,  0,  1,  0)]
        [TestCase(Nature.Mild,    0, -1,  0,  1,  0)]
        [TestCase(Nature.Quiet,   0,  0, -1,  1,  0)]
        [TestCase(Nature.Bashful, 0,  0,  0,  0,  0)]
        [TestCase(Nature.Rash,    0,  0,  0,  1, -1)]

        [TestCase(Nature.Calm,   -1,  0,  0,  0,  1)]
        [TestCase(Nature.Gentle,  0, -1,  0,  0,  1)]
        [TestCase(Nature.Sassy,   0,  0, -1,  0,  1)]
        [TestCase(Nature.Careful, 0,  0,  0, -1,  1)]
        [TestCase(Nature.Quirky,  0,  0,  0,  0,  0)]
        public void GetModifier_ReturnsCorrectModifiers(
            Nature nature,
            int attack,
            int defense,
            int speed,
            int spAttack,
            int spDefense)
        {
            Assert.Multiple(() =>
            {
                Assert.That(
                    NatureTable.GetModifier(nature, StatIndex.Attack),
                    Is.EqualTo(attack),
                    "Attack");

                Assert.That(
                    NatureTable.GetModifier(nature, StatIndex.Defense),
                    Is.EqualTo(defense),
                    "Defense");

                Assert.That(
                    NatureTable.GetModifier(nature, StatIndex.Speed),
                    Is.EqualTo(speed),
                    "Speed");

                Assert.That(
                    NatureTable.GetModifier(nature, StatIndex.SpAttack),
                    Is.EqualTo(spAttack),
                    "SpAttack");

                Assert.That(
                    NatureTable.GetModifier(nature, StatIndex.SpDefense),
                    Is.EqualTo(spDefense),
                    "SpDefense");
            });
        }

        [TestCase(Nature.Hardy)]
        [TestCase(Nature.Docile)]
        [TestCase(Nature.Serious)]
        [TestCase(Nature.Bashful)]
        [TestCase(Nature.Quirky)]
        public void GetModifier_NeutralNature_DoesNotModifyStats(
            Nature nature)
        {
            for (int i = (int)StatIndex.Attack;
                 i <= (int)StatIndex.SpDefense;
                 i++)
            {
                StatIndex stat = (StatIndex)i;

                Assert.That(
                    NatureTable.GetModifier(nature, stat),
                    Is.Zero,
                    $"Nature: {nature}, Stat: {stat}");
            }
        }

        [Test]
        public void GetModifier_Hp_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NatureTable.GetModifier(Nature.Adamant, StatIndex.Hp));
        }

        [TestCase(-1)]
        [TestCase(25)]
        [TestCase(100)]
        public void GetModifier_InvalidNature_ThrowsArgumentOutOfRangeException(
            int natureId)
        {
            Nature nature = (Nature)natureId;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NatureTable.GetModifier(nature, StatIndex.Attack));
        }

        [TestCase(-1)]
        [TestCase(6)]
        [TestCase(100)]
        public void GetModifier_InvalidStat_ThrowsArgumentOutOfRangeException(
            int statId)
        {
            StatIndex stat = (StatIndex)statId;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                NatureTable.GetModifier(Nature.Adamant, stat));
        }

        [Test]
        public void AllNatures_HaveValidModifierValues()
        {
            foreach (Nature nature in Enum.GetValues(typeof(Nature)))
            {
                for (int i = (int)StatIndex.Attack;
                     i <= (int)StatIndex.SpDefense;
                     i++)
                {
                    StatIndex stat = (StatIndex)i;
                    sbyte modifier = NatureTable.GetModifier(nature, stat);

                    Assert.That(
                        modifier,
                        Is.InRange(-1, 1),
                        $"Nature: {nature}, Stat: {stat}");
                }
            }
        }

        [Test]
        public void AllNonNeutralNatures_ModifyExactlyTwoStats()
        {
            foreach (Nature nature in Enum.GetValues(typeof(Nature)))
            {
                int increased = 0;
                int decreased = 0;

                for (int i = (int)StatIndex.Attack;
                     i <= (int)StatIndex.SpDefense;
                     i++)
                {
                    sbyte modifier = NatureTable.GetModifier(
                        nature,
                        (StatIndex)i);

                    if (modifier == 1)
                        increased++;

                    if (modifier == -1)
                        decreased++;
                }

                bool isNeutral =
                    nature == Nature.Hardy ||
                    nature == Nature.Docile ||
                    nature == Nature.Serious ||
                    nature == Nature.Bashful ||
                    nature == Nature.Quirky;

                if (isNeutral)
                {
                    Assert.That(increased, Is.Zero, $"{nature}: increases");
                    Assert.That(decreased, Is.Zero, $"{nature}: decreases");
                }
                else
                {
                    Assert.That(increased, Is.EqualTo(1), $"{nature}: increases");
                    Assert.That(decreased, Is.EqualTo(1), $"{nature}: decreases");
                }
            }
        }

        [Test]
        public void NatureEnum_ContainsExactly25Natures()
        {
            Assert.That(
                Enum.GetValues(typeof(Nature)).Length,
                Is.EqualTo(25));
        }
    }
}
