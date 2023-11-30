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
        public async static Task<Player> SetPlayerAccessory(Player currentPlayer)
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
            else
            {
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
