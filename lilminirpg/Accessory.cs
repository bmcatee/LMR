using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Accessory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatStrength { get; set; }
        public int StatDexterity { get; set; }
        public int StatIntelligence { get; set; }
        public int StatLuck { get; set; }
        public int MoveSpeed { get; set; }
        public int AttackSpeed { get; set; }
        public string AccessoryPerk { get; set; }
    }
    public class AccessoryMethods
    {
        public class AccessoryList
        {
            public List<AccessoryList> playerAccessories { get; set; }
        }
        public static List<Accessory> FetchAccessories()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\AccessoriesList.json";

            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string json = sr.ReadToEnd();
            List<Accessory> PlayerAccessories = JsonSerializer.Deserialize<List<Accessory>>(json);

            return PlayerAccessories;
        }
        public static Accessory SetPlayerAccessory(Player currentplayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 4;

            List<Accessory> _listPlayerAccessories = AccessoryMethods.FetchAccessories();

            Console.WriteLine($"Name: {currentplayer.Name} || Class: {currentplayer.PlayerJob.Name} || Weapon: {currentplayer.WornWeapon.Name} || Accessory: {currentplayer.WornAccessory.Name}");
            Console.WriteLine("");
            userInterface.MenuLength = _listPlayerAccessories.Count;
            Console.WriteLine("Your class choices are:");
            Console.WriteLine("");
            for (int i = 0; i < _listPlayerAccessories.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerAccessories[i].Name}");
            }

            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
//                Console.WriteLine($"CursorOffset {userInterface.CursorOffset} | MenuTracker {userInterface.MenuTracker} | SelectedOption {userInterface.SelectedOption} | MenuInput {userInterface.MenuInput} | MenuLength {userInterface.MenuLength}");
            }
            if (userInterface.SelectedOption < _listPlayerAccessories.Count)
            {
                currentplayer.WornAccessory = _listPlayerAccessories[userInterface.SelectedOption];
            }
            else
            {
                UI.InvalidSelection();
            }
            return currentplayer.WornAccessory;
        }
    }
}
