using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lilminirpg
{
    public class DataLists
    {
        public static string[,] MenuMain =
        {
                    {"Play Game"},
                    {"Make New Character"},
                    {"Load Character"},
                    {"Edit Character & Equipment"},
                    {"Exit"},
                    {"Debug Menu"}
        };

        public static string[,] MenuTest =
        {
                    {"InitStageArray"},
                    {"Check Player Status"},
                    {"PrintLists"},
                    {"PrintColorList"},
                    {"Exit to Main Menu"}
        };

        public static string[,] MenuEdit =
        {   
                    {"Change Character Name"},
                    {"Change Job"},
                    {"Change Weapon"},
                    {"Change Accessory"},
                    {"Exit to Main Menu"}
        };


        public class Clothing
        {
            // coming soon
        }

        // Enemies
        public static string[,] EnemiesList =
        {
            // Key:
            // Name, Desc,
            // HPMax, STR, AttackSpeed,
            // MonsterPerk1, MonsterPerk2, MonsterPerk3,
            // Gold, XP,
            // MonsterFamily, MonsterEnvironment, MonsterRank
            // ^^^ are used for populating stages;
            // MF is an overall 'grouping' of monsters, IE: "all slimes"
            // ME is the type of environment they prefer (lava, ice, desert, forest, etc)
            // MR is how far into the game they should appear (EX: rank 1 monsters do not spawn in the first ~50 stages)
            // Total Elements: 13
        {
                    "Empty Ground", "",
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
                    "8", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "A.Slime", "Aqua - Classicly adorable ankle-melter.",
                    "12", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "S.Slime", "Shock - Classicly adorable ankle-melter.",
                    "7", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "L.Slime", "Lava - Classicly adorable ankle-melter.",
                    "8", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "R.Slime", "Rock - Classicly adorable ankle-melter.",
                    "6", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "D.Slime", "Demon - Classicly adorable ankle-melter.",
                    "15", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "H.Slime", "Holy - Classicly adorable ankle-melter.",
                    "20", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Fighter", "Small, but not harmless.",
                    "8", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Defender", "Small, but not harmless.",
                    "15", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Spellcaster", "Loves it when things go boom.",
                    "4", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Beasttamer", "Loves it when things go boom.",
                    "6", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Berserker", "Loves it when things go boom.",
                    "7", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        {
                    "Goblin Thief", "Loves it when things go boom.",
                    "4", "1", "5",
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
                    "9", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Wasp", "Stays aloft and away from melee attacks.",
                    "2", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Flying Squirrel", "Stays aloft and away from melee attacks.",
                    "4", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Locust", "Stays aloft and away from melee attacks.",
                    "3", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Pixie", "Stays aloft and away from melee attacks.",
                    "8", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Wyrm", "Stays aloft and away from melee attacks.",
                    "12", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Minotaur", "Big and brutally strong.",
                    "25", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Bear", "Big and brutally strong.",
                    "20", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Bird Bear", "Big and brutally strong.",
                    "22", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Golem", "Big and brutally strong.",
                    "30", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Living Doll", "Big and brutally strong.",
                    "9", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Moai Head", "Big and brutally strong.",
                    "18", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Racoon", "Big and brutally strong.",
                    "6", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Evil Clown", ". . . ",
                    "7", "1", "1",
                    "0", "0", "0",
                    "5", "10",
                    "1", "1", "1"
        },
        {
                    "Fish", "Just floppin' around.",
                    "4", "1", "5",
                    "0", "0", "0",
                    "0", "10",
                    "1", "1", "1"
        },
        };
    }
}
