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
            public string Name { get; set; }
            public string Description { get; set; }
            public int HealthPointsGrowth { get; set; }
            public int StrengthGrowth { get; set; }
            public int DexterityGrowth { get; set; }
            public int IntelligenceGrowth { get; set; }
            public int LuckGrowth { get; set; }
            public int MoveSpeed { get; set; }
            public int AttackSpeed { get; set; }
            public string JobPerk { get; set; }
            public string JobAbility001 { get; set; }
            public string JobAbility002 { get; set; }
            public string JobAbility003 { get; set; }
            public string JobAbility004 { get; set; }
            public string JobAbility005 { get; set; }
            public string JobAbility006 { get; set; }
            public string JobAbility007 { get; set; }
            public string JobAbility008 { get; set; }
            public string JobAbility009 { get; set; }
            public string JobAbility010 { get; set; }
    }
    public class JobMethods
    {
        public class PlayerJobList
        {
            public List<PlayerJobList> playerJobs { get; set; }
        }
        public static List<Job> FetchPlayerJobs()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string folder = System.IO.Directory.GetCurrentDirectory();
            string filename = "\\ClassesList.json";

            StreamReader sr = new StreamReader(Path.Combine(folder, filename));
            string json = sr.ReadToEnd();
            List<Job> PlayerClasses = JsonSerializer.Deserialize<List<Job>>(json);

            return PlayerClasses;
        }
        public static Job SetPlayerJob(Player currentPlayer)
        {
            Console.Clear();
            UI userInterface = new();
            userInterface.SelectedOption = 0;
            userInterface.MenuInput = "";
            userInterface.CursorOffset = 4;

            List<Job> _listPlayerJobs = JobMethods.FetchPlayerJobs();

            Console.WriteLine($"Name: {currentPlayer.Name} || Class: {currentPlayer.PlayerJob.Name} || Weapon: {currentPlayer.WornWeapon.Name} || Accessory: {currentPlayer.WornAccessory.Name}");
            Console.WriteLine("");
            userInterface.MenuLength = _listPlayerJobs.Count;
            Console.WriteLine("Your class choices are:");
            Console.WriteLine("");

            for (int i = 0; i < _listPlayerJobs.Count; ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {_listPlayerJobs[i].Name}");
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
            return currentPlayer.PlayerJob;
        }
    }
}
