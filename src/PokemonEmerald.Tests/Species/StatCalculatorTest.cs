using PokemonEmerald.Core.Species;

namespace PokemonEmerald.Tests.Species;

public class StatCalculatorTest
{
    [TestCase(5, 45, 0, 0,  19)]
    [TestCase(50, 45, 0, 0,  105)]
    [TestCase(100, 45, 0, 0,  200)]
    [TestCase(5, 45, 31, 0,  21)]
    [TestCase(50, 45, 31, 0,  120)]
    [TestCase(100, 45, 31, 0,  231)]
    [TestCase(5, 45, 31, 252,  24)]
    [TestCase(50, 45, 31, 252,  152)]
    [TestCase(100, 45, 31, 252,  294)]
    public void Hp_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Hp);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  9)]
    [TestCase(50, 49, 0, 0,  54)]
    [TestCase(100, 49, 0, 0,  103)]
    [TestCase(5, 49, 31, 0,  11)]
    [TestCase(50, 49, 31, 0,  69)]
    [TestCase(100, 49, 31, 0,  134)]
    [TestCase(5, 49, 31, 252,  14)]
    [TestCase(50, 49, 31, 252,  101)]
    [TestCase(100, 49, 31, 252,  197)]
    public void Attack_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Attack);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  9)]
    [TestCase(50, 49, 0, 0,  54)]
    [TestCase(100, 49, 0, 0,  103)]
    [TestCase(5, 49, 31, 0,  11)]
    [TestCase(50, 49, 31, 0,  69)]
    [TestCase(100, 49, 31, 0,  134)]
    [TestCase(5, 49, 31, 252,  14)]
    [TestCase(50, 49, 31, 252,  101)]
    [TestCase(100, 49, 31, 252,  197)]
    public void Defense_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Defense);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 45, 0, 0,  9)]
    [TestCase(50, 45, 0, 0,  50)]
    [TestCase(100, 45, 0, 0,  95)]
    [TestCase(5, 45, 31, 0,  11)]
    [TestCase(50, 45, 31, 0,  65)]
    [TestCase(100, 45, 31, 0,  126)]
    [TestCase(5, 45, 31, 252,  14)]
    [TestCase(50, 45, 31, 252,  97)]
    [TestCase(100, 45, 31, 252,  189)]
    public void Speed_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Speed);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  11)]
    [TestCase(50, 65, 0, 0,  70)]
    [TestCase(100, 65, 0, 0,  135)]
    [TestCase(5, 65, 31, 0,  13)]
    [TestCase(50, 65, 31, 0,  85)]
    [TestCase(100, 65, 31, 0,  166)]
    [TestCase(5, 65, 31, 252,  16)]
    [TestCase(50, 65, 31, 252,  117)]
    [TestCase(100, 65, 31, 252,  229)]
    public void SpAttack_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpAttack);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  11)]
    [TestCase(50, 65, 0, 0,  70)]
    [TestCase(100, 65, 0, 0,  135)]
    [TestCase(5, 65, 31, 0,  13)]
    [TestCase(50, 65, 31, 0,  85)]
    [TestCase(100, 65, 31, 0,  166)]
    [TestCase(5, 65, 31, 252,  16)]
    [TestCase(50, 65, 31, 252,  117)]
    [TestCase(100, 65, 31, 252,  229)]
    public void SpDefense_Calculate(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpDefense);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  9)]
    [TestCase(50, 49, 0, 0,  59)]
    [TestCase(100, 49, 0, 0,  113)]
    public void Attack_CalculateGoodNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Attack, Nature.Adamant);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  8)]
    [TestCase(50, 49, 0, 0,  48)]
    [TestCase(100, 49, 0, 0,  92)]
    public void Attack_CalculateBadNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Attack, Nature.Modest);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  9)]
    [TestCase(50, 49, 0, 0,  59)]
    [TestCase(100, 49, 0, 0,  113)]
    public void Defense_CalculateGoodNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Defense, Nature.Bold);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 49, 0, 0,  8)]
    [TestCase(50, 49, 0, 0,  48)]
    [TestCase(100, 49, 0, 0,  92)]
    public void Defense_CalculateBadNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Defense, Nature.Lonely);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 45, 0, 0,  9)]
    [TestCase(50, 45, 0, 0,  55)]
    [TestCase(100, 45, 0, 0,  104)]
    public void Speed_CalculateGoodNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Speed, Nature.Hasty);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 45, 0, 0,  8)]
    [TestCase(50, 45, 0, 0,  45)]
    [TestCase(100, 45, 0, 0,  85)]
    public void Speed_CalculateBadNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.Speed, Nature.Brave);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  12)]
    [TestCase(50, 65, 0, 0,  77)]
    [TestCase(100, 65, 0, 0,  148)]
    public void SpAttack_CalculateGoodNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpAttack, Nature.Mild);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  9)]
    [TestCase(50, 65, 0, 0,  63)]
    [TestCase(100, 65, 0, 0,  121)]
    public void SpAttack_CalculateBadNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpAttack, Nature.Adamant);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  12)]
    [TestCase(50, 65, 0, 0,  77)]
    [TestCase(100, 65, 0, 0,  148)]
    public void SpDefense_CalculateGoodNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpDefense, Nature.Gentle);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(5, 65, 0, 0,  9)]
    [TestCase(50, 65, 0, 0,  63)]
    [TestCase(100, 65, 0, 0,  121)]
    public void SpDefense_CalculateBadNature(byte level, byte baseStat, byte iv, byte ev, int expected)
    {
        var actual = StatCalculator.Calculate(baseStat, iv, ev, level, StatIndex.SpDefense, Nature.Naughty);
        Assert.That(actual, Is.EqualTo(expected));
    }
}