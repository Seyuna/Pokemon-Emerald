using System;
using PokemonEmerald.Core.Abilities;
using PokemonEmerald.Core.Items;
using PokemonEmerald.Core.Rng;
using PokemonEmerald.Core.Species.Experience;
using PokemonEmerald.Core.Species.Registry;

namespace PokemonEmerald.Core.Species
{
    public class PokemonFactory
    {
        private readonly EmeraldRng _rng;
        
        public PokemonFactory(EmeraldRng rng)
        {
            _rng = rng ?? throw new ArgumentNullException(nameof(rng));
        }

        public Pokemon CreateNew(SpeciesId species, byte level, uint originalTrainerId)
        {
            if (level is < 1 or > Config.MaxLevel)
                throw new ArgumentOutOfRangeException(nameof(level));
            
            if (!SpeciesRegistry.TryGet(species, out var speciesData) || speciesData == null)
                throw new ArgumentException($"Species {species} not found");

            var personality = _rng.Random32();
            var gender = GetGender(speciesData, personality);
            var nature = (Nature)PersonalityHelper.GetNature(personality);
            var ivs = GenerateIvs();
            var evs = Stats.Empty();
            
            var stats = GenerateStats(speciesData, ivs, evs, nature, level);

            var experience = ExperienceTable.GetExperience(speciesData.GrowthRate, level);

            var abilitySlot = speciesData.Ability2 != AbilityId.None
                ? PersonalityHelper.GetInitialAbilitySlot(personality)
                : (byte)0;
            
            return new Pokemon
            {
                CurrentHp = stats.Hp,
                Experience = experience,
                Friendship = speciesData.Friendship,
                Level = level,
                OriginalTrainerId = originalTrainerId,
                Personality = personality,
                Species = species,
                Status = 0,
                Stats = stats,
                Evs = evs,
                Ivs = ivs,
                AbilitySlot = abilitySlot,
                HeldItem = ItemId.None,
                Gender = gender
            };
        }

        private Stats GenerateIvs()
        {
            var ivEntry = _rng.Random();
            var hpIv = ivEntry & Config.MaxIv;
            var attackIv = (ivEntry & (Config.MaxIv << 5)) >> 5;
            var defenseIv = (ivEntry & (Config.MaxIv << 10)) >> 10;

            ivEntry = _rng.Random();
            var speedIv = ivEntry & Config.MaxIv;
            var spAttackIv = (ivEntry & (Config.MaxIv << 5)) >> 5;
            var spDefenseIv = (ivEntry & (Config.MaxIv << 10)) >> 10;

            return new Stats
            {
                Hp = (ushort)hpIv,
                Attack = (ushort)attackIv,
                Defense = (ushort)defenseIv,
                Speed = (ushort)speedIv,
                SpAttack = (ushort)spAttackIv,
                SpDefense = (ushort)spDefenseIv
            };
        }

        private static Gender GetGender(SpeciesData speciesData, uint personality)
        {
            var genderRatio = speciesData.GenderRatio;

            if (genderRatio == (byte)Gender.Male || genderRatio == (byte)Gender.Female || genderRatio == (byte)Gender.Genderless)
                return (Gender)genderRatio;

            var genderValue = PersonalityHelper.GetGenderValue(personality);
            
            return genderRatio > genderValue 
                ? Gender.Female 
                : Gender.Male;
        }

        private static Stats GenerateStats(SpeciesData speciesData, Stats ivs, Stats evs, Nature nature, byte level)
        {
            var hpStat = speciesData.Id == SpeciesId.Shedinja 
                ? 1
                : StatCalculator.Calculate(
                    speciesData.BaseHp, (byte)ivs.Hp, (byte)evs.Hp, level, StatIndex.Hp
                );

            return new Stats
            {
                Hp = (ushort)hpStat,
                Attack = (ushort)StatCalculator.Calculate(
                    speciesData.BaseAttack, (byte)ivs.Attack, (byte)evs.Attack, level, StatIndex.Attack, nature
                ),
                Defense = (ushort)StatCalculator.Calculate(
                    speciesData.BaseDefense, (byte)ivs.Defense, (byte)evs.Defense, level, StatIndex.Defense, nature
                ),
                SpAttack = (ushort)StatCalculator.Calculate(
                    speciesData.BaseSpAttack, (byte)ivs.SpAttack, (byte)evs.SpAttack, level, StatIndex.SpAttack, nature
                ),
                SpDefense = (ushort)StatCalculator.Calculate(
                    speciesData.BaseSpDefense, (byte)ivs.SpDefense, (byte)evs.SpDefense, level, StatIndex.SpDefense, nature
                ),
                Speed = (ushort)StatCalculator.Calculate(
                    speciesData.BaseSpeed, (byte)ivs.Speed, (byte)evs.Speed, level, StatIndex.Speed, nature
                )
            };
        }
    }
}