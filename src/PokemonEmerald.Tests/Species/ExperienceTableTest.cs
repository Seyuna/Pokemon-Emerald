using PokemonEmerald.Core;
using PokemonEmerald.Core.Species;
using PokemonEmerald.Core.Species.Experience;

namespace PokemonEmerald.Tests.Species;

public class ExperienceTableTest
{
    [TestCase((byte)5, 237u)]
    [TestCase((byte)15, 5737u)]
    [TestCase((byte)25, 23437u)]
    [TestCase((byte)50, 125000u)]
    [TestCase((byte)75, 326531u)]
    [TestCase((byte)100, 600000u)]
    public void Erratic_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.Erratic);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase((byte)5, 100u)]
    [TestCase((byte)15, 2700u)]
    [TestCase((byte)25, 12500u)]
    [TestCase((byte)50, 100000u)]
    [TestCase((byte)75, 337500u)]
    [TestCase((byte)100, 800000u)]
    public void Fast_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.Fast);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase((byte)5, 125u)]
    [TestCase((byte)15, 3375u)]
    [TestCase((byte)25, 15625u)]
    [TestCase((byte)50, 125000u)]
    [TestCase((byte)75, 421875u)]
    [TestCase((byte)100, 1000000u)]
    public void MediumFast_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.MediumFast);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [TestCase((byte)5, 135u)]
    [TestCase((byte)15, 2035u)]
    [TestCase((byte)25, 11735u)]
    [TestCase((byte)50, 117360u)]
    [TestCase((byte)75, 429235u)]
    [TestCase((byte)100, 1059860u)]
    public void MediumSlow_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.MediumSlow);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    
    [TestCase((byte)5, 156u)]
    [TestCase((byte)15, 4218u)]
    [TestCase((byte)25, 19531u)]
    [TestCase((byte)50, 156250u)]
    [TestCase((byte)75, 527343u)]
    [TestCase((byte)100, 1250000u)]
    public void Slow_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.Slow);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    
    [TestCase((byte)5, 65u)]
    [TestCase((byte)15, 1957u)]
    [TestCase((byte)25, 12187u)]
    [TestCase((byte)50, 142500u)]
    [TestCase((byte)75, 582187u)]
    [TestCase((byte)100, 1640000u)]
    public void Fluctuating_CorrectExperienceNeeded(byte level, uint expected)
    {
        var actual = ExperienceCalculator.CalculateExperience(level, GrowthRate.Fluctuating);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void EperienceTable_MatchesCalculator()
    {
        foreach (GrowthRate growthRate in Enum.GetValues(typeof(GrowthRate)))
        {
            for (byte level = 0; level <= Config.MaxLevel; level++)
            {
                var expected = ExperienceCalculator.CalculateExperience(level, growthRate);
                var actual = ExperienceTable.GetExperience(growthRate, level);
                
                Assert.That(actual, Is.EqualTo(expected), $"{expected} should be {actual}");
            }
        }
    }
    
    [TestCase(0u, 0)]
    [TestCase(1u, 1)]
    [TestCase(7u, 1)]
    [TestCase(8u, 2)]
    [TestCase(27u, 3)]
    [TestCase(999999u, 99)]
    [TestCase(1000000u, 100)]
    [TestCase(1500000u, 100)]
    public void GetLevelByExperience_MediumFast_ReturnsCorrectLevel(
        uint experience,
        byte expectedLevel)
    {
        byte actual = ExperienceTable.GetLevelByExperience(
            GrowthRate.MediumFast,
            experience);

        Assert.That(actual, Is.EqualTo(expectedLevel));
    }
    
    [Test]
    public void GetLevelByExperience_AllGrowthRates_MatchExperienceTable()
    {
        foreach (GrowthRate growthRate in Enum.GetValues(typeof(GrowthRate)))
        {
            for (byte level = 1; level <= Config.MaxLevel; level++)
            {
                uint experience = ExperienceTable.GetExperience(
                    growthRate,
                    level);

                byte actual = ExperienceTable.GetLevelByExperience(
                    growthRate,
                    experience);

                Assert.That(
                    actual,
                    Is.EqualTo(level),
                    $"GrowthRate: {growthRate}, Level: {level}");
            }
        }
    }
}