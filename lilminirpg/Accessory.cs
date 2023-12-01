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
        public int HealthPointsMax { get; set; } = 0;
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
        
        // Creates a list of accessories from the json
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
        // Sets an accessory to the player object; this should all be moved into the DB
        public async static Task<Player> SetPlayerAccessory(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 9;

            List<Accessory> _listPlayerAccessories = FetchAccessories();

            UI.UIHeaderGeneric();
            Console.WriteLine("");
            UI.UICharacterInfo(currentPlayer);

            if (CharacterMaker._characterCreation)
            {
                userInterface.MenuLength = _listPlayerAccessories.Count;
            }
            else
            {
                userInterface.MenuLength = _listPlayerAccessories.Count + 1;
            }

            Console.WriteLine("Please choose an Accessory:");
            Console.WriteLine("");
            for (int i = 0; i < _listPlayerAccessories.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerAccessories[i].Name}: {_listPlayerAccessories[i].Description}");
            }
            if (!CharacterMaker._characterCreation)
            {
                Console.WriteLine($"[ ] Return to Character Menu");
            }
            else
            {

            }

            UI.UIFooterGeneric();
            Console.WriteLine("");
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.PrintItemInfo(_listPlayerAccessories);
                userInterface.UIMovement();
            }
            if (userInterface.SelectedOption < _listPlayerAccessories.Count)
            {
                currentPlayer.WornAccessory = _listPlayerAccessories[userInterface.SelectedOption];
            }
            else if (userInterface.SelectedOption < _listPlayerAccessories.Count + 1)
            {
                await Menus.EditCharacterMenu();
            }
            else {
                string location = "AccessoryMenu";
                Program.LogException(userInterface.SelectedOption, location);
                UI.InvalidSelection();
            }
            if (CharacterMaker._characterCreation != true)
            {
                await SaveLoad.SaveGame(currentPlayer);
            }
            return currentPlayer;
        }
    }
}
