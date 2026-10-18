using PokemonEmerald.Core.Abilities;
using PokemonEmerald.Core.Species;
using PokemonEmerald.Core.Species.Registry;

namespace PokemonEmerald.Tests.Species;

[TestFixture]
public class SpeciesRegistryTest
{
    [TestCase(SpeciesId.Bulbasaur)]
    [TestCase(SpeciesId.Chikorita)]
    [TestCase(SpeciesId.Treecko)]
    public void Get_ValidSpecies_ReturnSpeciesData(
        SpeciesId speciesId)
    {
        var species = SpeciesRegistry.Get(speciesId);

        Assert.That(species, Is.Not.Null);
        Assert.That(speciesId, Is.EqualTo(species.Id));

    }

    [Test]
    public void Get_InvalidSpecies_ThrowsException()
    {
        var invalidId = (SpeciesId)99999;
        
        Assert.Throws<KeyNotFoundException>(
            () => SpeciesRegistry.Get(invalidId));
    }
    
    [Test]
    public void Bulbasaur_HasCorrectBaseStats()
    {
        SpeciesData species =
            SpeciesRegistry.Get(SpeciesId.Bulbasaur);

        Assert.Multiple(() =>
        {
            Assert.That(species.BaseHp, Is.EqualTo(45));
            Assert.That(species.BaseAttack, Is.EqualTo(49));
            Assert.That(species.BaseDefense, Is.EqualTo(49));
            Assert.That(species.BaseSpeed, Is.EqualTo(45));
            Assert.That(species.BaseSpAttack, Is.EqualTo(65));
            Assert.That(species.BaseSpDefense, Is.EqualTo(65));
        });
    }
}