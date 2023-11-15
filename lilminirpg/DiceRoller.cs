using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class DiceRoller
    {
        public int RollDice(int min, int max)
        {
            var random = new Random();
            int roll = random.Next(min, max);
            return roll;
        }

        public int DamageRoller(Player player)
        {
            int totalStr = player.StatStrength + player.WornWeapon.StatStrength;
            int totalDex = player.StatDexterity + player.WornWeapon.StatDexterity;
            int totalInt = player.StatIntelligence + player.WornWeapon.StatIntelligence;

            string attackStat1 = player.WornWeapon.AttackStat1;
            string attackStat2 = player.WornWeapon.AttackStat2;

            int BaseDamageDealt = BaseDamageRoll(player.WornWeapon.AttackStat1, 60) + BaseDamageRoll(player.WornWeapon.AttackStat2, 40);
            int TotalDamageDealt = BonusDamageRoll(BaseDamageDealt);

            int BaseDamageRoll(string attackType, int amount)
            {
                int damagedealt = 0;
                switch (attackType)
                {
                    case "Strength":
                        damagedealt = totalStr / amount;
                        break;
                    case "Dexterity":
                        damagedealt = totalDex / amount;
                        break;
                    case "Intelligence":
                        damagedealt = totalInt / amount;
                        break;
                }
                return damagedealt;
            }

            int BonusDamageRoll(int basedamage)
            {
                int damagedealt = 0;
                int damageMod = RollDice(0, 99);
                switch (damageMod)
                {
                    case int n when (n > 26):
                        // Min damage
                        damagedealt = basedamage + 20;
                        break;
                    case int n when (n > 25 && n < 51):
                        // Max damage
                        damagedealt = basedamage + 80;
                        break;
                    case int n when (n > 50 && n < 76):
                        // Crit success damage
                        damagedealt = basedamage - 20;
                        break;
                    case int n when (n > 75):
                        // Crit failure damage
                        damagedealt = basedamage - 80;
                        break;
                }
                return damagedealt;
            }

            return TotalDamageDealt;
        }
    }
 }



