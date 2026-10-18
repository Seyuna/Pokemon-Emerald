using PokemonEmerald.Core.Items;
using PokemonEmerald.Core.Rng;
using PokemonEmerald.Core.Species;
using PokemonEmerald.Core.Species.Experience;
using PokemonEmerald.Core.Species.Registry;

namespace PokemonEmerald.Tests.Species
{
    [TestFixture]
    public class PokemonFactoryTests
    {
        private const ushort Seed = 12345;
        private const uint TrainerId = 123456789u;

        private EmeraldRng _rng;
        private PokemonFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _rng = new EmeraldRng(Seed);
            _factory = new PokemonFactory(_rng);
        }

        [Test]
        public void CreateNew_ShouldInitializeBasicData()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.Multiple(() =>
            {
                Assert.That(pokemon.Species,
                    Is.EqualTo(SpeciesId.Treecko));
                Assert.That(pokemon.Level, Is.EqualTo(5));
                Assert.That(pokemon.OriginalTrainerId,
                    Is.EqualTo(TrainerId));
                Assert.That(pokemon.Status, Is.EqualTo(0));
            });
        }

        [Test]
        public void CreateNew_ShouldDeriveNatureFromPersonality()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            var expected = (Nature)(pokemon.Personality % 25);

            Assert.That(pokemon.Nature, Is.EqualTo(expected));
        }

        [Test]
        public void CreateNew_ShouldGenerateValidIvs()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.Multiple(() =>
            {
                Assert.That(pokemon.Ivs.Hp, Is.InRange(0, 31));
                Assert.That(pokemon.Ivs.Attack, Is.InRange(0, 31));
                Assert.That(pokemon.Ivs.Defense, Is.InRange(0, 31));
                Assert.That(pokemon.Ivs.Speed, Is.InRange(0, 31));
                Assert.That(pokemon.Ivs.SpAttack, Is.InRange(0, 31));
                Assert.That(pokemon.Ivs.SpDefense, Is.InRange(0, 31));
            });
        }

        [Test]
        public void CreateNew_ShouldInitializeEvsToZero()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.Multiple(() =>
            {
                Assert.That(pokemon.Evs.Hp, Is.Zero);
                Assert.That(pokemon.Evs.Attack, Is.Zero);
                Assert.That(pokemon.Evs.Defense, Is.Zero);
                Assert.That(pokemon.Evs.Speed, Is.Zero);
                Assert.That(pokemon.Evs.SpAttack, Is.Zero);
                Assert.That(pokemon.Evs.SpDefense, Is.Zero);
            });
        }

        [Test]
        public void CreateNew_ShouldCalculateStatsUsingGeneratedIvs()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.That(
                SpeciesRegistry.TryGet(
                    SpeciesId.Treecko, out var speciesData),
                Is.True);

            Assert.That(speciesData, Is.Not.Null);

            var hp = StatCalculator.Calculate(
                speciesData!.BaseHp,
                (byte)pokemon.Ivs.Hp,
                0,
                pokemon.Level,
                StatIndex.Hp);

            var attack = StatCalculator.Calculate(
                speciesData.BaseAttack,
                (byte)pokemon.Ivs.Attack,
                0,
                pokemon.Level,
                StatIndex.Attack,
                pokemon.Nature);

            var defense = StatCalculator.Calculate(
                speciesData.BaseDefense,
                (byte)pokemon.Ivs.Defense,
                0,
                pokemon.Level,
                StatIndex.Defense,
                pokemon.Nature);

            var speed = StatCalculator.Calculate(
                speciesData.BaseSpeed,
                (byte)pokemon.Ivs.Speed,
                0,
                pokemon.Level,
                StatIndex.Speed,
                pokemon.Nature);

            var spAttack = StatCalculator.Calculate(
                speciesData.BaseSpAttack,
                (byte)pokemon.Ivs.SpAttack,
                0,
                pokemon.Level,
                StatIndex.SpAttack,
                pokemon.Nature);

            var spDefense = StatCalculator.Calculate(
                speciesData.BaseSpDefense,
                (byte)pokemon.Ivs.SpDefense,
                0,
                pokemon.Level,
                StatIndex.SpDefense,
                pokemon.Nature);

            Assert.Multiple(() =>
            {
                Assert.That(pokemon.Stats.Hp, Is.EqualTo(hp));
                Assert.That(pokemon.Stats.Attack, Is.EqualTo(attack));
                Assert.That(pokemon.Stats.Defense, Is.EqualTo(defense));
                Assert.That(pokemon.Stats.Speed, Is.EqualTo(speed));
                Assert.That(pokemon.Stats.SpAttack, Is.EqualTo(spAttack));
                Assert.That(pokemon.Stats.SpDefense, Is.EqualTo(spDefense));
            });
        }

        [Test]
        public void CreateNew_ShouldStartWithFullHp()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.That(pokemon.CurrentHp,
                Is.EqualTo(pokemon.Stats.Hp));
        }

        [TestCase((byte)1)]
        [TestCase((byte)5)]
        [TestCase((byte)50)]
        [TestCase((byte)100)]
        public void CreateNew_ShouldInitializeExperience(
            byte level)
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, level, TrainerId);

            Assert.That(
                SpeciesRegistry.TryGet(
                    SpeciesId.Treecko, out var speciesData),
                Is.True);

            Assert.That(speciesData, Is.Not.Null);

            var expected = ExperienceTable.GetExperience(
                speciesData!.GrowthRate, level);

            Assert.That(pokemon.Experience, Is.EqualTo(expected));
        }

        [Test]
        public void CreateNew_ShouldInitializeSpeciesFriendship()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.That(
                SpeciesRegistry.TryGet(
                    SpeciesId.Treecko, out var speciesData),
                Is.True);

            Assert.That(speciesData, Is.Not.Null);

            Assert.That(pokemon.Friendship,
                Is.EqualTo(speciesData!.Friendship));
        }

        [Test]
        public void CreateNew_ShouldConsumeFourRandomCalls()
        {
            var referenceRng = new EmeraldRng(Seed);

            _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            // Two calls for personality.
            referenceRng.Random();
            referenceRng.Random();

            // Two calls for IVs.
            referenceRng.Random();
            referenceRng.Random();

            Assert.That(_rng.Random(),
                Is.EqualTo(referenceRng.Random()));
        }

        [Test]
        public void CreateNew_ShouldUseProvidedTrainerId()
        {
            var first = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            var second = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.Multiple(() =>
            {
                Assert.That(first.OriginalTrainerId,
                    Is.EqualTo(TrainerId));
                Assert.That(second.OriginalTrainerId,
                    Is.EqualTo(TrainerId));
            });
        }

        [Test]
        public void CreateNew_TrainerIdShouldNotAffectRngResults()
        {
            var firstFactory = new PokemonFactory(
                new EmeraldRng(Seed));

            var secondFactory = new PokemonFactory(
                new EmeraldRng(Seed));

            var first = firstFactory.CreateNew(
                SpeciesId.Treecko, 5, 123u);

            var second = secondFactory.CreateNew(
                SpeciesId.Treecko, 5, 456u);

            Assert.Multiple(() =>
            {
                Assert.That(first.Personality,
                    Is.EqualTo(second.Personality));

                Assert.That(first.Ivs.Hp,
                    Is.EqualTo(second.Ivs.Hp));
                Assert.That(first.Ivs.Attack,
                    Is.EqualTo(second.Ivs.Attack));
                Assert.That(first.Ivs.Defense,
                    Is.EqualTo(second.Ivs.Defense));
                Assert.That(first.Ivs.Speed,
                    Is.EqualTo(second.Ivs.Speed));
                Assert.That(first.Ivs.SpAttack,
                    Is.EqualTo(second.Ivs.SpAttack));
                Assert.That(first.Ivs.SpDefense,
                    Is.EqualTo(second.Ivs.SpDefense));
            });
        }

        [Test]
        public void CreateNew_WithUnknownSpecies_ShouldThrow()
        {
            Assert.That(
                () => _factory.CreateNew(
                    (SpeciesId)int.MaxValue,
                    5,
                    TrainerId),
                Throws.TypeOf<ArgumentException>());
        }
        
        [TestCase((byte)1)]
        [TestCase((byte)5)]
        [TestCase((byte)50)]
        [TestCase((byte)100)]
        public void CreateNew_Shedinja_ShouldAlwaysHaveOneHp(byte level)
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Shedinja, level, TrainerId);

            Assert.Multiple(() =>
            {
                Assert.That(pokemon.Stats.Hp, Is.EqualTo(1));
                Assert.That(pokemon.CurrentHp, Is.EqualTo(1));
                Assert.That(pokemon.Level, Is.EqualTo(level));
            });
        }
        
        [TestCase(SpeciesId.NidoranM, Gender.Male)]
        [TestCase(SpeciesId.NidoranF, Gender.Female)]
        [TestCase(SpeciesId.Magnemite, Gender.Genderless)]
        public void CreateNew_FixedGenderSpecies_ShouldHaveExpectedGender(
            SpeciesId species,
            Gender expected)
        {
            var pokemon = _factory.CreateNew(species, 5, TrainerId);

            Assert.That(pokemon.Gender, Is.EqualTo(expected));
        }
        
        [Test]
        public void CreateNew_ShouldCalculateShinyFromPersonalityAndTrainerId()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            var expected = PersonalityHelper.IsShiny(
                pokemon.Personality,
                pokemon.OriginalTrainerId);

            Assert.That(pokemon.IsShiny, Is.EqualTo(expected));
        }
        
        [Test]
        public void CreateNew_ShouldInitializeHeldItemToNone()
        {
            var pokemon = _factory.CreateNew(
                SpeciesId.Treecko, 5, TrainerId);

            Assert.That(pokemon.HeldItem, Is.EqualTo(ItemId.None));
        }
        
        [TestCase((byte)0)]
        [TestCase((byte)101)]
        public void CreateNew_WithInvalidLevel_ShouldThrow(byte level)
        {
            Assert.That(
                () => _factory.CreateNew(
                    SpeciesId.Treecko, level, TrainerId),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
