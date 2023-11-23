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
        public static Job SetPlayerJob(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 4;

            List<Job> _listPlayerJobs = JobMethods.FetchPlayerJobs();

            UI.UICharacterInfo(currentPlayer);

            userInterface.MenuLength = _listPlayerJobs.Count;
            Console.WriteLine("Your Job choices are:");
            Console.WriteLine("");

            for (int i = 0; i < _listPlayerJobs.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerJobs[i].Name}: {_listPlayerJobs[i].Description}");
            }
            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
                //                Console.WriteLine($"CursorOffset {userInterface.CursorOffset} | MenuTracker {userInterface.MenuTracker} | SelectedOption {userInterface.SelectedOption} | MenuInput {userInterface.MenuInput} | MenuLength {userInterface.MenuLength}");
            }
            if (userInterface.SelectedOption < _listPlayerJobs.Count)
            {
                currentPlayer.PlayerJob = _listPlayerJobs[userInterface.SelectedOption];
            }
            else
            {
                UI.InvalidSelection();
            }
            if (CharacterMaker._characterCreation != true)
            {
                SaveLoad.SaveGame(currentPlayer);
            }
            return currentPlayer.PlayerJob;
        }
    }
}
