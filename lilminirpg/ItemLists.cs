using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class ItemLists
    {
        public static string[,] MainMenu =
        {
                    {"New Game",""},
                    {"Load Game",""},
                    {"Options",""},
                    {"Exit","" }
        };
        // Class choices
        public static string[,] PlayerClasses =
        {
                    {"Knight", "The classic."},
                    {"Thief", "Fast and stabby."},
                    {"Wizard", "Fireworks."},
                    {"Adventurer", "Roaming for fun."},
                    {"Monk", "Fists of punishment."}
        };

        // Weapon choices
        public static string[,] PlayerWeapons =
        {
                    {"Short Sword", "A good, all-around weapon."},
                    {"Claymore", "Slow but packs a punch."},
                    {"Knife", "Fast and nimble."},
                    {"Wand", "Does randomized magical damage."},
                    {"Staff", "Excellent for defensive fighting."},
                    {"Knuckle Wraps", "For those that like to brawl."}
        };


        // Accessory choices
        public static string[,] PlayerAccessories =
        {
                    {"Shield", "A bit bulky, but keeps distance between You and Them."},
                    {"Pocket Sand", "May cause the enemy to become Blinded."},
                    {"Dancer's Shoes", "Makes it easier to dodge attacks."},
                    {"Water Pendant", "Has a high chance of your attack inflicting Water damage."},
                    {"Fire Ring", "Has a high chance of your attack inflicting Fire damage."},
                    {"Lightning Brooch", "Has a high chance of your attack inflicting Lightning damage."}
        };
    }
}
