using PokemonEmerald.Core.Abilities;
using PokemonEmerald.Core.Abilities.Registry;

namespace PokemonEmerald.Tests.Abilities
{
    [TestFixture]
    public class AbilityRegistryTests
    {
        [Test]
        public void AbilityEnum_HasOriginalEmeraldCount()
        {
            Assert.That(Enum.GetValues(typeof(AbilityId)).Length, Is.EqualTo(78));
        }

        [Test]
        public void EveryAbilityId_HasMatchingDefinition()
        {
            for (int id = 0; id < 78; id++)
            {
                AbilityData ability;
                bool found = AbilityRegistry.TryGet((AbilityId)id, out ability);

                Assert.That(found, Is.True, "Missing ability ID " + id);
                Assert.That(ability, Is.Not.Null, "Null ability at ID " + id);
                Assert.That(ability.Id, Is.EqualTo((AbilityId)id), "Wrong ID at " + id);
                Assert.That(AbilityRegistry.Get((AbilityId)id), Is.SameAs(ability),
                    "Get and TryGet returned different objects at ID " + id);
            }
        }

        [TestCase(-1)]
        [TestCase(78)]
        [TestCase(999)]
        public void TryGet_InvalidId_ReturnsFalseAndNull(int id)
        {
            AbilityData ability;
            bool found = AbilityRegistry.TryGet((AbilityId)id, out ability);
            Assert.That(found, Is.False);
            Assert.That(ability, Is.Null);
        }

        [TestCase(-1)]
        [TestCase(78)]
        [TestCase(999)]
        public void Get_InvalidId_ThrowsKeyNotFoundException(int id)
        {
            Assert.Throws<KeyNotFoundException>(() => AbilityRegistry.Get((AbilityId)id));
        }

        [Test]
        public void EveryRealAbility_HasDisplayMetadata()
        {
            // ID 0 is ABILITY_NONE, which is a special placeholder.
            for (int id = 1; id < 78; id++)
            {
                AbilityData ability = AbilityRegistry.Get((AbilityId)id);
                Assert.That(ability.Name, Is.Not.Null.And.Not.Empty,
                    "Missing name at ability ID " + id);
                Assert.That(ability.Description, Is.Not.Null.And.Not.Empty,
                    "Missing description at ability ID " + id);
            }
        }

        [TestCase(AbilityId.Stench, "STENCH")]
        [TestCase(AbilityId.Overgrow, "OVERGROW")]
        [TestCase(AbilityId.Intimidate, "INTIMIDATE")]
        [TestCase(AbilityId.Levitate, "LEVITATE")]
        public void Get_KnownAbility_HasExpectedName(AbilityId id, string expectedName)
        {
            AbilityData ability = AbilityRegistry.Get(id);
            Assert.That(ability.Id, Is.EqualTo(id));
            Assert.That(ability.Name, Is.EqualTo(expectedName));
        }

        [Test]
        public void AbilityIds_UseOriginalNumericValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That((int)AbilityId.None, Is.EqualTo(0));
                Assert.That((int)AbilityId.Stench, Is.EqualTo(1));
                Assert.That((int)AbilityId.Overgrow, Is.EqualTo(65));
            });
        }
    }
}
