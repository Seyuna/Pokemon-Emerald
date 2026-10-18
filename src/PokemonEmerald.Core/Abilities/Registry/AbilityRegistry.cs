namespace PokemonEmerald.Core.Abilities.Registry
{
    public static class AbilityRegistry
    {
        private static readonly AbilityData[] Abilities = Create();
        private static AbilityData[] Create()
        {
            var data = new AbilityData[78];
            data[0] = new AbilityData { Id = AbilityId.None, Name = "-------", Description = "No special ability." };
            data[1] = new AbilityData { Id = AbilityId.Stench, Name = "STENCH", Description = "Helps repel wild POKéMON." };
            data[2] = new AbilityData { Id = AbilityId.Drizzle, Name = "DRIZZLE", Description = "Summons rain in battle." };
            data[3] = new AbilityData { Id = AbilityId.SpeedBoost, Name = "SPEED BOOST", Description = "Gradually boosts SPEED." };
            data[4] = new AbilityData { Id = AbilityId.BattleArmor, Name = "BATTLE ARMOR", Description = "Blocks critical hits." };
            data[5] = new AbilityData { Id = AbilityId.Sturdy, Name = "STURDY", Description = "Negates 1-hit KO attacks." };
            data[6] = new AbilityData { Id = AbilityId.Damp, Name = "DAMP", Description = "Prevents self-destruction." };
            data[7] = new AbilityData { Id = AbilityId.Limber, Name = "LIMBER", Description = "Prevents paralysis." };
            data[8] = new AbilityData { Id = AbilityId.SandVeil, Name = "SAND VEIL", Description = "Ups evasion in a sandstorm." };
            data[9] = new AbilityData { Id = AbilityId.Static, Name = "STATIC", Description = "Paralyzes on contact." };
            data[10] = new AbilityData { Id = AbilityId.VoltAbsorb, Name = "VOLT ABSORB", Description = "Turns electricity into HP." };
            data[11] = new AbilityData { Id = AbilityId.WaterAbsorb, Name = "WATER ABSORB", Description = "Changes water into HP." };
            data[12] = new AbilityData { Id = AbilityId.Oblivious, Name = "OBLIVIOUS", Description = "Prevents attraction." };
            data[13] = new AbilityData { Id = AbilityId.CloudNine, Name = "CLOUD NINE", Description = "Negates weather effects." };
            data[14] = new AbilityData { Id = AbilityId.CompoundEyes, Name = "COMPOUNDEYES", Description = "Raises accuracy." };
            data[15] = new AbilityData { Id = AbilityId.Insomnia, Name = "INSOMNIA", Description = "Prevents sleep." };
            data[16] = new AbilityData { Id = AbilityId.ColorChange, Name = "COLOR CHANGE", Description = "Changes type to foe's move." };
            data[17] = new AbilityData { Id = AbilityId.Immunity, Name = "IMMUNITY", Description = "Prevents poisoning." };
            data[18] = new AbilityData { Id = AbilityId.FlashFire, Name = "FLASH FIRE", Description = "Powers up if hit by fire." };
            data[19] = new AbilityData { Id = AbilityId.ShieldDust, Name = "SHIELD DUST", Description = "Prevents added effects." };
            data[20] = new AbilityData { Id = AbilityId.OwnTempo, Name = "OWN TEMPO", Description = "Prevents confusion." };
            data[21] = new AbilityData { Id = AbilityId.SuctionCups, Name = "SUCTION CUPS", Description = "Firmly anchors the body." };
            data[22] = new AbilityData { Id = AbilityId.Intimidate, Name = "INTIMIDATE", Description = "Lowers the foe's ATTACK." };
            data[23] = new AbilityData { Id = AbilityId.ShadowTag, Name = "SHADOW TAG", Description = "Prevents the foe's escape." };
            data[24] = new AbilityData { Id = AbilityId.RoughSkin, Name = "ROUGH SKIN", Description = "Hurts to touch." };
            data[25] = new AbilityData { Id = AbilityId.WonderGuard, Name = "WONDER GUARD", Description = "“Super effective” hits." };
            data[26] = new AbilityData { Id = AbilityId.Levitate, Name = "LEVITATE", Description = "Not hit by GROUND attacks." };
            data[27] = new AbilityData { Id = AbilityId.EffectSpore, Name = "EFFECT SPORE", Description = "Leaves spores on contact." };
            data[28] = new AbilityData { Id = AbilityId.Synchronize, Name = "SYNCHRONIZE", Description = "Passes on status problems." };
            data[29] = new AbilityData { Id = AbilityId.ClearBody, Name = "CLEAR BODY", Description = "Prevents ability reduction." };
            data[30] = new AbilityData { Id = AbilityId.NaturalCure, Name = "NATURAL CURE", Description = "Heals upon switching out." };
            data[31] = new AbilityData { Id = AbilityId.LightningRod, Name = "LIGHTNINGROD", Description = "Draws electrical moves." };
            data[32] = new AbilityData { Id = AbilityId.SereneGrace, Name = "SERENE GRACE", Description = "Promotes added effects." };
            data[33] = new AbilityData { Id = AbilityId.SwiftSwim, Name = "SWIFT SWIM", Description = "Raises SPEED in rain." };
            data[34] = new AbilityData { Id = AbilityId.Chlorophyll, Name = "CHLOROPHYLL", Description = "Raises SPEED in sunshine." };
            data[35] = new AbilityData { Id = AbilityId.Illuminate, Name = "ILLUMINATE", Description = "Encounter rate increases." };
            data[36] = new AbilityData { Id = AbilityId.Trace, Name = "TRACE", Description = "Copies special ability." };
            data[37] = new AbilityData { Id = AbilityId.HugePower, Name = "HUGE POWER", Description = "Raises ATTACK." };
            data[38] = new AbilityData { Id = AbilityId.PoisonPoint, Name = "POISON POINT", Description = "Poisons foe on contact." };
            data[39] = new AbilityData { Id = AbilityId.InnerFocus, Name = "INNER FOCUS", Description = "Prevents flinching." };
            data[40] = new AbilityData { Id = AbilityId.MagmaArmor, Name = "MAGMA ARMOR", Description = "Prevents freezing." };
            data[41] = new AbilityData { Id = AbilityId.WaterVeil, Name = "WATER VEIL", Description = "Prevents burns." };
            data[42] = new AbilityData { Id = AbilityId.MagnetPull, Name = "MAGNET PULL", Description = "Traps STEEL-type POKéMON." };
            data[43] = new AbilityData { Id = AbilityId.Soundproof, Name = "SOUNDPROOF", Description = "Avoids sound-based moves." };
            data[44] = new AbilityData { Id = AbilityId.RainDish, Name = "RAIN DISH", Description = "Slight HP recovery in rain." };
            data[45] = new AbilityData { Id = AbilityId.SandStream, Name = "SAND STREAM", Description = "Summons a sandstorm." };
            data[46] = new AbilityData { Id = AbilityId.Pressure, Name = "PRESSURE", Description = "Raises foe's PP usage." };
            data[47] = new AbilityData { Id = AbilityId.ThickFat, Name = "THICK FAT", Description = "Heat-and-cold protection." };
            data[48] = new AbilityData { Id = AbilityId.EarlyBird, Name = "EARLY BIRD", Description = "Awakens quickly from sleep." };
            data[49] = new AbilityData { Id = AbilityId.FlameBody, Name = "FLAME BODY", Description = "Burns the foe on contact." };
            data[50] = new AbilityData { Id = AbilityId.RunAway, Name = "RUN AWAY", Description = "Makes escaping easier." };
            data[51] = new AbilityData { Id = AbilityId.KeenEye, Name = "KEEN EYE", Description = "Prevents loss of accuracy." };
            data[52] = new AbilityData { Id = AbilityId.HyperCutter, Name = "HYPER CUTTER", Description = "Prevents ATTACK reduction." };
            data[53] = new AbilityData { Id = AbilityId.Pickup, Name = "PICKUP", Description = "May pick up items." };
            data[54] = new AbilityData { Id = AbilityId.Truant, Name = "TRUANT", Description = "Moves only every two turns." };
            data[55] = new AbilityData { Id = AbilityId.Hustle, Name = "HUSTLE", Description = "Trades accuracy for power." };
            data[56] = new AbilityData { Id = AbilityId.CuteCharm, Name = "CUTE CHARM", Description = "Infatuates on contact." };
            data[57] = new AbilityData { Id = AbilityId.Plus, Name = "PLUS", Description = "Powers up with MINUS." };
            data[58] = new AbilityData { Id = AbilityId.Minus, Name = "MINUS", Description = "Powers up with PLUS." };
            data[59] = new AbilityData { Id = AbilityId.Forecast, Name = "FORECAST", Description = "Changes with the weather." };
            data[60] = new AbilityData { Id = AbilityId.StickyHold, Name = "STICKY HOLD", Description = "Prevents item theft." };
            data[61] = new AbilityData { Id = AbilityId.ShedSkin, Name = "SHED SKIN", Description = "Heals the body by shedding." };
            data[62] = new AbilityData { Id = AbilityId.Guts, Name = "GUTS", Description = "Ups ATTACK if suffering." };
            data[63] = new AbilityData { Id = AbilityId.MarvelScale, Name = "MARVEL SCALE", Description = "Ups DEFENSE if suffering." };
            data[64] = new AbilityData { Id = AbilityId.LiquidOoze, Name = "LIQUID OOZE", Description = "Draining causes injury." };
            data[65] = new AbilityData { Id = AbilityId.Overgrow, Name = "OVERGROW", Description = "Ups GRASS moves in a pinch." };
            data[66] = new AbilityData { Id = AbilityId.Blaze, Name = "BLAZE", Description = "Ups FIRE moves in a pinch." };
            data[67] = new AbilityData { Id = AbilityId.Torrent, Name = "TORRENT", Description = "Ups WATER moves in a pinch." };
            data[68] = new AbilityData { Id = AbilityId.Swarm, Name = "SWARM", Description = "Ups BUG moves in a pinch." };
            data[69] = new AbilityData { Id = AbilityId.RockHead, Name = "ROCK HEAD", Description = "Prevents recoil damage." };
            data[70] = new AbilityData { Id = AbilityId.Drought, Name = "DROUGHT", Description = "Summons sunlight in battle." };
            data[71] = new AbilityData { Id = AbilityId.ArenaTrap, Name = "ARENA TRAP", Description = "Prevents fleeing." };
            data[72] = new AbilityData { Id = AbilityId.VitalSpirit, Name = "VITAL SPIRIT", Description = "Prevents sleep." };
            data[73] = new AbilityData { Id = AbilityId.WhiteSmoke, Name = "WHITE SMOKE", Description = "Prevents ability reduction." };
            data[74] = new AbilityData { Id = AbilityId.PurePower, Name = "PURE POWER", Description = "Raises ATTACK." };
            data[75] = new AbilityData { Id = AbilityId.ShellArmor, Name = "SHELL ARMOR", Description = "Blocks critical hits." };
            data[76] = new AbilityData { Id = AbilityId.Cacophony, Name = "CACOPHONY", Description = "Avoids sound-based moves." };
            data[77] = new AbilityData { Id = AbilityId.AirLock, Name = "AIR LOCK", Description = "Negates weather effects." };
            return data;
        }
        public static bool TryGet(AbilityId id, out AbilityData ability)
        {
            int i = (int)id;
            ability = i >= 0 && i < Abilities.Length ? Abilities[i] : null;
            return ability != null;
        }
        public static AbilityData Get(AbilityId id)
        {
            AbilityData ability;
            if (!TryGet(id, out ability)) throw new System.Collections.Generic.KeyNotFoundException("No ability definition for " + id);
            return ability;
        }
    }
}
