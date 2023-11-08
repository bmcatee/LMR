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
                    {"New Game"},
                    {"Load Game"},
                    {"Options"},
                    {"Exit"},
                    {"Test QE"}
        };

        // Class choices
        public static string[,] PlayerClasses =
        {
                    {"Knight", "The classic."},
                    {"Thief", "Fast and stabby."},
                    {"Wizard", "Fireworks."},
                    {"Adventurer", "Roaming for fun."},
                    {"Monk", "Fists of punishment."},
//                    {"5", "Warrior", "High attack, low health."}
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

        // Enemies
        public static string[,] EnemiesList =
        {
            // Key:
            // Name, Desc,
            // HPMax, STR, AttackSpeed,
            // MonsterPerk1, MonsterPerk2, MonsterPerk3,
            // Gold, XP,
            // MonsterFamily, MonsterEnvironment, MonsterRank
            // MonsterFamily, MonsterEnvironment, & MonsterRank are used for populating stages;
            // MF is an overall 'grouping' of monsters, IE: "all slimes"
            // ME is the type of environment they prefer (lava, ice, desert, forest, etc)
            // MR is how far into the game they should appear (EX: rank 1 monsters do not spawn in the first ~50 stages)
            // Total Elements: 8

        {
                "Dummy", "",
                "0", "0", "0",
                "0", "0", "0",
                "0", "0",
                "0", "0", "0"
        },
        {
                    "G.Slime", "Green - Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "R.Slime", "Red - Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "A.Slime", "Aqua - Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "S.Slime", "Shock - Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "L.Slime", "Lava - Classicly adorable ankle-melter.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "R.Slime", "Rock - Classicly adorable ankle-melter.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "D.Slime", "Demon - Classicly adorable ankle-melter.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "H.Slime", "Holy - Classicly adorable ankle-melter.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Fighter", "Small, but not harmless.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Defender", "Small, but not harmless.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Spellcaster", "Loves it when things go boom.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Beasttamer", "Loves it when things go boom.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Berserker", "Loves it when things go boom.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Thief", "Loves it when things go boom.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Harpy", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Dire Eagle", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Wasp", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Flying Squirrel", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Locust", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Pixie", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Wyrm", "Stays aloft and away from melee attacks.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Minotaur", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Bear", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Bird Bear", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Golem", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Living Doll", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Moai Head", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Racoon", "Big and brutally strong.",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Evil Clown", ". . . ",
                    "5", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Fish", "Just floppin' around.",
                    "5", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },





        };
    }
}
