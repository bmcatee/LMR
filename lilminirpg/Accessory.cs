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
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int StatStrength { get; set; } = 0;
        public int StatDexterity { get; set; } = 0;
        public int StatIntelligence { get; set; } = 0;
        public int StatLuck { get; set; } = 0;
        public int MoveSpeed { get; set; } = 0;
        public int AttackSpeed { get; set; } = 0;
        public string? AccessoryPerk { get; set; } = "";
    }
    public class AccessoryMethods
    {
        public class AccessoryList
        {
            public List<AccessoryList>? PlayerAccessories { get; set; }
        }
        public static List<Accessory> FetchAccessories()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "AccessoriesList.json";
            List<Accessory> playerAccessories = new List<Accessory>();
            using (StreamReader sr = new StreamReader(Path.Combine(folder, filename)))
            {
                while (!sr.EndOfStream)
                {
                    string json = sr.ReadToEnd();
                    playerAccessories = JsonSerializer.Deserialize<List<Accessory>>(json);
                }
            }
            return playerAccessories;
        }
        public static Accessory SetPlayerAccessory(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 4;

            List<Accessory> _listPlayerAccessories = FetchAccessories();

            UI.UICharacterInfo(currentPlayer);

            userInterface.MenuLength = _listPlayerAccessories.Count;
            Console.WriteLine("Please choose an Accessory:");
            Console.WriteLine("");
            for (int i = 0; i < _listPlayerAccessories.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerAccessories[i].Name}: {_listPlayerAccessories[i].Description}");
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
                currentPlayer.WornAccessory = _listPlayerAccessories[userInterface.SelectedOption];
            }
            else
            {
                UI.InvalidSelection();
            }
            if (CharacterMaker._characterCreation != true)
            {
                SaveLoad.SaveGame(currentPlayer);
            }
            return currentPlayer.WornAccessory;
        }
    }
}
