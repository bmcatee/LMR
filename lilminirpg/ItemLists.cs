using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class ItemLists
    {
        public static string[,] MenuMain =
        {
                    {"0", "New Game", ""},
                    {"1", "Load Game", ""},
                    {"2", "Options", ""},
                    {"3", "Exit", ""}
        };

        // Class choices
        public static string[,] PlayerClasses =
        {
                    {"0", "Knight", "The classic."},
                    {"1", "Thief", "Fast and stabby."},
                    {"2", "Wizard", "Fireworks."},
                    {"3", "Adventurer", "Roaming for fun."},
                    {"4", "Monk", "Fists of punishment."}
        };

        // Weapon choices
        public static string[,] PlayerWeapons =
        {
                    {"0", "Short Sword", "A good, all-around weapon."},
                    {"1", "Claymore", "Slow but packs a punch."},
                    {"2", "Knife", "Fast and nimble."},
                    {"3", "Wand", "Does randomized magical damage."},
                    {"4", "Staff", "Excellent for defensive fighting."},
                    {"5", "Knuckle Wraps", "For those that like to brawl."}
        };

        // Accessory choices
        public static string[,] PlayerAccessories =
        {
                    {"0", "Shield", "A bit bulky, but keeps distance between You and Them."},
                    {"1", "Pocket Sand", "May cause the enemy to become Blinded."},
                    {"2", "Dancer's Shoes", "Makes it easier to dodge attacks."},
                    {"3", "Water Pendant", "Has a high chance of your attack inflicting Water damage."},
                    {"4", "Fire Ring", "Has a high chance of your attack inflicting Fire damage."},
                    {"5", "Lightning Brooch", "Has a high chance of your attack inflicting Lightning damage."}
        };
    }
}
