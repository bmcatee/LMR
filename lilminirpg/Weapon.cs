using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Weapon
    {
            public string Name { get; set; }
            public string Description { get; set; }
            public string AttackType { get; set; }
            public string ElementType { get; set; }
            public string AttackStat1 { get; set; }
            public string AttackStat2 { get; set; }
            public int StatStrength { get; set; }
            public int StatDexterity { get; set; }
            public int StatIntelligence { get; set; }
            public int StatLuck { get; set; }
            public int MoveSpeed { get; set; }
            public int AttackSpeed { get; set; }
            public string WeaponPerk { get; set; }
    }
    public class WeaponMethods
    {
        public class WeaponList
        {
            public List<WeaponList> playerWeapons { get; set; }
        }

        public static List<Weapon> FetchWeapons()
        {
            //C:\Users\bmcat\Documents\Projects\lilminirpg\lilminirpg\lilminirpg\json
            string folder = Environment.CurrentDirectory;
            string filename = "\\WeaponsList.json";

            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string json = sr.ReadToEnd();
            List<Weapon> PlayerWeapons = JsonSerializer.Deserialize<List<Weapon>>(json);
            return PlayerWeapons;
        }
        public static Weapon SetPlayerWeapon(Player currentplayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 4;

            List<Weapon> _listPlayerWeapons = WeaponMethods.FetchWeapons();

            Console.WriteLine($"Name: {currentplayer.Name} || Class: {currentplayer.PlayerJob.Name} || Weapon: {currentplayer.WornWeapon.Name} || Accessory: {currentplayer.WornAccessory.Name}");
            Console.WriteLine("");
            userInterface.MenuLength = _listPlayerWeapons.Count;
            Console.WriteLine("Your class choices are:");
            Console.WriteLine("");

            for (int i = 0; i < _listPlayerWeapons.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerWeapons[i].Name}");
            }

            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
//                Console.WriteLine($"CursorOffset {userInterface.CursorOffset} | MenuTracker {userInterface.MenuTracker} | SelectedOption {userInterface.SelectedOption} | MenuInput {userInterface.MenuInput} | MenuLength {userInterface.MenuLength}");
            }
            if (userInterface.SelectedOption < _listPlayerWeapons.Count)
            {
                currentplayer.WornWeapon = _listPlayerWeapons[userInterface.SelectedOption];
            }
            else
            {
                UI.InvalidSelection();
            }
            return currentplayer.WornWeapon;
        }
    }
}

