namespace PokemonEmerald.Core.Species
{
    public static class PersonalityHelper
    {
        public static byte GetNature(uint personality)
        {
            return (byte)(personality % 25);
        }

        public static byte GetGenderValue(uint personality)
        {
            return (byte)(personality & 0xFF);
        }

        public static byte GetInitialAbilitySlot(uint personality)
        {
            return (byte)(personality & 1);
        }

        public static bool EvolvesIntoSilcoon(uint personality)
        {
            return personality % 10 < 5;
        }

        public static bool IsShiny(uint personality, uint otId)
        {
            var value =
                (personality & 0xFFFF) ^
                (personality >> 16) ^
                (otId & 0xFFFF) ^
                (otId >> 16);

            return value < Config.ShinyChance;
        }
    }
}