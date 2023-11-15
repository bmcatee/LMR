using System;
using System.Collections.Generic;
using System.Linq;
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
                    {"New Game"},
                    {"Load Game"},
                    {"Options"},
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
        public class PlayerClass
        {
            public List<PlayerClass> playerClasses { get; set; }
        }
        public class PlayerClassInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string StrengthGrowth { get; set; }
            public int DexterityGrowth { get; set; }
            public int IntelligenceGrowth { get; set; }
            public int MoveSpeed { get; set; }
            public int AttackSpeed { get; set; }
            public string ClassPerk { get; set; }
            public string ClassAbility001 { get; set; }
            public string ClassAbility002 { get; set; }
            public string ClassAbility003 { get; set; }
            public string ClassAbility004 { get; set; }
            public string ClassAbility005 { get; set; }
            public string ClassAbility006 { get; set; }
            public string ClassAbility007 { get; set; }
            public string ClassAbility008 { get; set; }
            public string ClassAbility009 { get; set; }
            public string ClassAbility010 { get; set; }
        }
        public class PlayerWeapon
        {
            public List<PlayerWeapon> playerWeapons { get; set; }
        }
        public class PlayerWeaponList
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string AttackType { get; set; }
            public string ElementType { get; set; }
            public string AttackStat1 { get; set; }
            public string AttackStat2 { get; set; }
            public string AttackStat3 { get; set; }
            public int StatStrength { get; set; }
            public int StatDexterity { get; set; }
            public int StatIntelligence { get; set; }
            public int MoveSpeed { get; set; }
            public int AttackSpeed { get; set; }
            public string WeaponPerk { get; set; }
        }
        public class PlayerAccessory
        {
            public List<PlayerAccessory> playerAccessories { get; set; }
        }
        public class PlayerAccessoryInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int StatStrength { get; set; }
            public int StatDexterity { get; set; }
            public int StatIntelligence { get; set; }
            public int MoveSpeed { get; set; }
            public int AttackSpeed { get; set; }
            public string AccessoryPerk { get; set; }
        }

        public class Clothing
        {
            // coming soon
        }


        // Class choices
        public List <PlayerClassInfo> PlayerClasses()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\ClassesList.json";
            List<PlayerClassInfo> PlayerClasses = JsonSerializer.Deserialize<List<PlayerClassInfo>>(folder);
            Console.WriteLine($"{PlayerClasses}");
            Console.ReadLine();

            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string line;

            //line = sr.ReadLine();
            //while (line != null)
            //{
            //    Console.WriteLine($"{line}");
            //    line = sr.ReadLine();
            //}
            //sr.Close();
            //Console.ReadLine();
            return PlayerClasses;
        }

        // Weapon choices
        public List<PlayerWeaponList> WeaponList()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\WeaponsList.json";
            List<PlayerWeaponList> PlayerWeapons = new List<PlayerWeaponList>();
            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string line;

            using (StreamReader r = new StreamReader(Path.Combine(folder, filename)))
            {
                string json = r.ReadToEnd();
                PlayerWeapons = JsonSerializer.Deserialize<List<PlayerWeaponList>>(json);
            }

            //line = sr.ReadLine();
            //while (line != null)
            //{
            //    Console.WriteLine($"{line}");
            //    line = sr.ReadLine();
            //}
            //sr.Close();
            //Console.ReadLine();
            return PlayerWeapons;
        }


        // Accessory choices
        public List<PlayerAccessoryInfo> AccessoryList()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\AccessoriesList.json";
            List<PlayerAccessoryInfo> PlayerAccessories = new List<PlayerAccessoryInfo>();
            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string line;

            using (StreamReader r = new StreamReader(Path.Combine(folder, filename)))
            {
                string json = r.ReadToEnd();
                PlayerAccessories = JsonSerializer.Deserialize<List<PlayerAccessoryInfo>>(json);
            }

            //line = sr.ReadLine();
            //while (line != null)
            //{
            //    Console.WriteLine($"{line}");
            //    line = sr.ReadLine();
            //}
            //sr.Close();
            //Console.ReadLine();
            return PlayerAccessories;
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
        };
     }
}
