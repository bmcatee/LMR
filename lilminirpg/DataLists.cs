using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class DataLists
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

        // Enemies
        public static string[,] EnemiesList =
{
                    // Key:
                        // ID#, Name, Desc,
                        // HPMax, STR, MonsterAttackInterval,
                        // MonsterPerk1, MonsterPerk2, MonsterPerk3,
                        // Gold, XP,
                        // MonsterFamily, MonsterEnvironment, MonsterRank
                    // MonsterFamily, MonsterEnvironment, & MonsterRank are used for populating stages;
                    // MF is an overall 'grouping' of monsters, IE: "all slimes"
                    // ME is the type of environment they prefer (lava, ice, desert, forest, etc)
                    // MR is how far into the game they should appear (EX: rank 1 monsters do not spawn in the first ~50 stages)
                    // Total Elements: 8
                    
        {
                    "0", "Slime", "Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10", 
                    "1", "1", "1"
        },

        {
                    "1", "Goblin Fighter", "Small, but not harmless.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"        },

        {
                    "2", "Harpy", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },

        {
                    "3", "Minotaur", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },

        {
                    "4", "Evil Clown", ". . . ",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },

        {
                    "5", "Fish", "Just floppin' around.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },

        {
                    "6", "Pink Slime", "Disorients their foes.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },

        {
                    "7", "Goblin Spellcaster", "Loves it when things go boom.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        }

        };
    }
}
