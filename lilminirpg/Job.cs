using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Job
    {
        public string? Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public int HealthPointsGrowth { get; set; } = 0;
        public int StrengthGrowth { get; set; } = 0;
        public int DexterityGrowth { get; set; } = 0;
        public int IntelligenceGrowth { get; set; } = 0;
        public int LuckGrowth { get; set; } = 0;
        public int MoveSpeed { get; set; } = 0;
        public int AttackSpeed { get; set; } = 0;
        public string? JobPerk { get; set; } = "";
        public string? JobAbility001 { get; set; } = "";
        public string? JobAbility002 { get; set; } = "";
        public string? JobAbility003 { get; set; } = "";
        public string? JobAbility004 { get; set; } = "";
        public string? JobAbility005 { get; set; } = "";
        public string? JobAbility006 { get; set; } = "";
        public string? JobAbility007 { get; set; } = "";
        public string? JobAbility008 { get; set; } = "";
        public string? JobAbility009 { get; set; } = "";
        public string? JobAbility010 { get; set; } = "";
    }
    public class JobMethods
    {
        public class PlayerJobList
        {
            public List<PlayerJobList>? playerJobs { get; set; }
        }
        public static List<Job> FetchPlayerJobs()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "JobsList.json";
            List<Job> playerJobs = new List<Job>();
            using (StreamReader sr = new StreamReader(Path.Combine(folder, filename)))
            {
                while (!sr.EndOfStream)
                {
                    string json = sr.ReadToEnd();
                    playerJobs = JsonSerializer.Deserialize<List<Job>>(json);
                }
            }
            return playerJobs;
        }
        // Sets the player's job - notably, if the player has gained XP, their XP will be reset but converted into GP
        public async static Task<Player> SetPlayerJob(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";

            List<Job> _listPlayerJobs = FetchPlayerJobs();

            UI.UIHeaderGeneric();
            Console.WriteLine("");
            UI.UICharacterInfo(currentPlayer);

            if (CharacterMaker._characterCreation == true)
            {
                userInterface.CursorOffset = 8;
                userInterface.MenuLength = _listPlayerJobs.Count;

                Console.WriteLine("Your Job choices are:");
                Console.WriteLine("");
            }
            else
            {
                userInterface.CursorOffset = 9;
                userInterface.MenuLength = _listPlayerJobs.Count + 1;

                Console.WriteLine("Your Job choices are: ");
                Console.WriteLine("(NOTE: Your level & XP will be reset to zero, but you will recieve Gold based on your gained XP!)");
                Console.WriteLine("");
            }

            for (int i = 0; i < _listPlayerJobs.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerJobs[i].Name}: {_listPlayerJobs[i].Description}");
            }
            if (!CharacterMaker._characterCreation)
            {
                Console.WriteLine($"[ ] Return to Character Menu");
            }
            UI.UIFooterGeneric();
            Console.WriteLine("");
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.PrintItemInfo(_listPlayerJobs);
                userInterface.UIMovement();
            }
            if (userInterface.SelectedOption < _listPlayerJobs.Count)
            {
                currentPlayer.PlayerJob = _listPlayerJobs[userInterface.SelectedOption];
                currentPlayer = CharacterMaker.SetLevelOne(currentPlayer);
            }
            else if (userInterface.SelectedOption < _listPlayerJobs.Count + 1)
            {
                await Menus.EditCharacterMenu();
            }
            else 
            { 
                string location = "JobsMenu";
                Program.LogException(userInterface.SelectedOption, location);
                UI.InvalidSelection();
            }
            if (CharacterMaker._characterCreation != true)
            {
                currentPlayer.GoldCurrent += currentPlayer.XPBanked;
                currentPlayer.XPBanked = 0;
                await SaveLoad.SaveGame(currentPlayer);
            }
            return currentPlayer;
        }
    }
}
