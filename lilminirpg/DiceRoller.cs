using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class DiceRoller
    {
        // Basic dice roller
        public static int RollDice(int min, int max)
        {
            var random = new Random();
            try
            {
                int roll = random.Next(min, max);
                return roll;
            }
            catch (Exception ex) when (Program.LogException(ex))
            {
                return -1;
            }
        }

        // Rolls damage for the player
        public static int DamageRoller(Player player)
        {
            // This is the base damage, gathered from the player's combined Job+Weapon+Accessory stats
            int BaseDamageDealt = BaseDamageRoll(player.WornWeapon.AttackStat1, player.WornWeapon.AttackPercent1) + BaseDamageRoll(player.WornWeapon.AttackStat2, player.WornWeapon.AttackPercent2);
            // This is the final damage, after receiving any bonus modifiers
            int TotalDamageDealt = BonusDamageRoll(BaseDamageDealt);

            int BaseDamageRoll(string attackType, int amount)
            {
                int damagedealt = 0;
                try
                {
                    switch (attackType)
                    {
                        case "StatStrength":
                            damagedealt = amount * (player.StatStrength + player.WornWeapon.StatStrength + player.WornAccessory.StatStrength) / 100;
                            break;
                        case "StatDexterity":
                            damagedealt = amount * (player.StatDexterity + player.WornWeapon.StatDexterity + player.WornAccessory.StatStrength) / 100;
                            break;
                        case "StatIntelligence":
                            damagedealt = amount * (player.StatIntelligence + player.WornWeapon.StatIntelligence + player.WornAccessory.StatStrength) / 100;
                            break;
                    }
                }
                catch (Exception ex) when (Program.LogException(ex))
                {
                }
                // Damage is always set to 1 at a minimum to help keep the dice roller happy
                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }

            int BonusDamageRoll(int basedamage)
            {
                // The odds of landing success/failure here will eventually be determined by the character's stats vs. the enemy's stats; for now it's just a hardcoded coin flip
                int damagedealt = 0;
                // 'newint' is a failsafe against getting any exception errors in the dice roller; it's hacky and I don't like it but it works
                int newint = 0;
                int damageMod = RollDice(0, 99);
                try
                {
                    switch (damageMod)
                    {
                        case int n when (n < 26):
                            // Min damage
                            newint = 25 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage + (RollDice(1, newint));
                            break;
                        case int n when (n > 25 && n < 51):
                            // Max damage
                            newint = 50 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage + (RollDice(1, newint));
                            break;
                        case int n when (n > 50 && n < 76):
                            // Crit success damage
                            newint = 75 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage + (RollDice(1, newint));
                            break;
                        case int n when (n > 75):
                            // Crit failure damage
                            newint = 50 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage - (RollDice(1, newint));
                            break;
                        default:
                            string location = "EditCharacterMenu";
                            Program.LogException(damageMod, location);
                            UI.InvalidSelection();
                            break;
                    }
                }
                catch (Exception ex) when (Program.LogException(ex))
                {
                }

                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }
            return TotalDamageDealt;
        }

        // Same as above, but for enemies
        public static int DamageRoller(Enemy enemy)
        {
            int BaseDamageDealt = BaseDamageRoll(enemy.AttackStat1, enemy.AttackPercent1) + BaseDamageRoll(enemy.AttackStat2, enemy.AttackPercent2);
            int TotalDamageDealt = BonusDamageRoll(BaseDamageDealt);

            int BaseDamageRoll(string attackType, int amount)
            {
                int damagedealt = 0;
                try 
                { 
                switch (attackType)
                {
                    case "StatStrength":
                        damagedealt = amount * enemy.StatStrength / 100;
                        break;
                    case "StatDexterity":
                        damagedealt = amount * enemy.StatDexterity / 100;
                        break;
                    case "StatIntelligence":
                        damagedealt = amount * enemy.StatIntelligence / 100;
                        break;
                }
                }
                catch (Exception ex) when (Program.LogException(ex))
                {
                }
                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }

            int BonusDamageRoll(int basedamage)
            {
                if (basedamage == 0)
                {
                    basedamage = 1;
                }
                int damagedealt = 0;
                int newint = 0;
                int damageMod = RollDice(0, 99);
                try
                { 
                switch (damageMod)
                {
                    case int n when (n < 26):
                            // Min damage
                            newint = 25 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                        damagedealt = basedamage + (RollDice(1, newint));
                        break;
                    case int n when (n > 25 && n < 51):
                            // Max damage
                            newint = 50 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage + (RollDice(1, newint));
                        break;
                    case int n when (n > 50 && n < 76):
                            // Crit success damage
                            newint = 75 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage + (RollDice(1, newint));
                        break;
                    case int n when (n > 75):
                            // Crit failure damage
                            newint = 50 * basedamage / 100;
                            if (newint == 0)
                            {
                                newint = 1;
                            }
                            damagedealt = basedamage - (RollDice(1, newint));
                        break;
                }
                }
                catch (Exception ex) when (Program.LogException(ex))
                {
                }
                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }

            return TotalDamageDealt;
        }
    }
}



