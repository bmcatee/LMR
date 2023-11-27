using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class DiceRoller
    {

        Accessory _accessory = new Accessory();
        public static int RollDice(int min, int max)
        {
            var random = new Random();
            int roll = random.Next(min, max);
            return roll;
        }

        public static int DamageRoller(Player player)
        {

            int BaseDamageDealt = BaseDamageRoll(player.WornWeapon.AttackStat1, player.WornWeapon.AttackPercent1) + BaseDamageRoll(player.WornWeapon.AttackStat2, player.WornWeapon.AttackPercent2);
            int TotalDamageDealt = BonusDamageRoll(BaseDamageDealt);

            int BaseDamageRoll(string attackType, int amount)
            {
                int damagedealt = 0;
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
                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }

            int BonusDamageRoll(int basedamage)
            {
                int damagedealt = 0;
                int damageMod = RollDice(0, 99);
                switch (damageMod)
                {
                    case int n when (n < 26):
                        // Min damage
                        damagedealt = basedamage + (RollDice(1, 25 * basedamage / 100));
                        break;
                    case int n when (n > 25 && n < 51):
                        // Max damage
                        damagedealt = basedamage + (RollDice(1, 50 * basedamage / 100));
                        break;
                    case int n when (n > 50 && n < 76):
                        // Crit success damage
                        damagedealt = basedamage + (RollDice(1, 75 * basedamage / 100));
                        break;
                    case int n when (n > 75):
                        // Crit failure damage
                        damagedealt = basedamage - (RollDice(1, 50 * basedamage / 100));
                        break;
                }
                if (damagedealt == 0)
                {
                    damagedealt = 1;
                }
                return damagedealt;
            }

            return TotalDamageDealt;
        }
        public static int DamageRoller(Enemy enemy)
        {
            int BaseDamageDealt = BaseDamageRoll(enemy.AttackStat1, enemy.AttackPercent1) + BaseDamageRoll(enemy.AttackStat2, enemy.AttackPercent2);
            int TotalDamageDealt = BonusDamageRoll(BaseDamageDealt);

            int BaseDamageRoll(string attackType, int amount)
            {
                int damagedealt = 0;
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
                int damageMod = RollDice(0, 99);
                switch (damageMod)
                {
                    case int n when (n < 26):
                        // Min damage
                        damagedealt = basedamage + (RollDice(1, 25 * basedamage / 100));
                        break;
                    case int n when (n > 25 && n < 51):
                        // Max damage
                        damagedealt = basedamage + (RollDice(1, 50 * basedamage / 100));
                        break;
                    case int n when (n > 50 && n < 76):
                        // Crit success damage
                        damagedealt = basedamage + (RollDice(1, 75 * basedamage / 100));
                        break;
                    case int n when (n > 75):
                        // Crit failure damage
                        damagedealt = basedamage - (RollDice(1, 50 * basedamage / 100));
                        break;
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



