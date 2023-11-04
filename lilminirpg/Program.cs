using lilminirpg;
using System.Security.Cryptography.X509Certificates;

namespace lilminirpg
{
    internal class Program
    {
        public static void Main()
        {
            // METHOD TESTS
            // QuestEngine.CreateStageArray();

            // Goto main menu
            UI.UIMenuSelector("MenuMain");
        }
    

        // Save game method
        public static void SaveGame(string charactername, string classname, string wornweapon, string wornaccessory)
        {
            string[] savedata = { $"{charactername}", $"{classname}", $"{wornweapon}", $"{wornaccessory}" };

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(savePath, "savefile01.txt")))
                foreach (string s in savedata)
                {
                    outputFile.WriteLine(s);
                }
            Console.WriteLine("");
            Console.WriteLine("Your data has been saved! Press Enter to continue.");
            Console.ReadLine();
            UI.MenuInput = "";
            UI.UIMenuSelector("MenuMain");
        }
    }
}

// TESTS

// Console.WriteLine($"Doop!");
// Console.ReadLine();
// Console.WriteLine($"UI.CursorSymbol = {UI.CursorSymbol} || UI.MenuTracker = {UI.MenuTracker} || UI.SelectedOption = {UI.SelectedOption} || UI.MenuInput = {UI.MenuInput} || UI.MenuLength = {UI.MenuLength}");
// Console.WriteLine($"Doop! {characterCreation} + {characterCreationStage}");
// Console.WriteLine($"local menutracker = {menutracker}");
// Console.ReadLine();
