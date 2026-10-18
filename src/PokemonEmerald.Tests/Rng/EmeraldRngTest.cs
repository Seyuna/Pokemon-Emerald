using System.Runtime;
using PokemonEmerald.Core.Rng;

namespace PokemonEmerald.Tests.Rng;

public class EmeraldRngTest
{
    [Test]
    public void Random2_DoesNotAffectRand()
    {
        var rng1 = new EmeraldRng(123);
        var rng2 = new EmeraldRng(123);

        var expected = rng1.Random();

        rng2.Random2();
        var actual = rng2.Random();
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}