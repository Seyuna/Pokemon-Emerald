using PokemonEmerald.Core.Rng;
using PokemonEmerald.Core.Species;

namespace PokemonEmerald.Tests.Species;

public class PersonalityTests
{
    private EmeraldRng _rng1;
    private EmeraldRng _rng2;

    private PokemonFactory _factory1;
    private PokemonFactory _factory2;
    
    [SetUp]
    public void SetUp()
    {
        _rng1 = new EmeraldRng(12345);
        _rng2 = new EmeraldRng(12345);
        
        _factory1 = new PokemonFactory(_rng1);
        _factory2 = new PokemonFactory(_rng2);
    }
    
    [Test]
    public void Personality_SameForSameSeed()
    {
        var mon1 = _factory1.CreateNew(SpeciesId.Bulbasaur, 5, 0);
        var mon2 = _factory2.CreateNew(SpeciesId.Bulbasaur, 5, 0);
        
        Assert.That(mon1.Personality, Is.EqualTo(mon2.Personality));
    }


    [Test]
    public void Personality_SameNatureFromSameSeed()
    {
        var mon1 = _factory1.CreateNew(SpeciesId.Bulbasaur, 5, 0);
        var mon2 = _factory2.CreateNew(SpeciesId.Bulbasaur, 5, 0);

        var nature1 = (Nature)PersonalityHelper.GetNature(mon1.Personality);
        var nature2 = (Nature)PersonalityHelper.GetNature(mon2.Personality);
        
        Assert.That(nature1, Is.EqualTo(nature2));
    }
}