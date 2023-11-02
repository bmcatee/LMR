using System.Security.Cryptography.X509Certificates;

namespace lilminirpg
{
    internal class Program
    {
        public static void Main()
        {
            // Goto main menu
            UI.MenuTracker = "MenuMain";
            UI.MenuLength = ItemLists.MainMenu.GetLength(0);
            UI.MenuSelector();
        }
        public static void SaveGame(string charactername, string classname, string wornweapon, string wornaccessory)
        {
            string[] savedata = { $"{charactername}", $"{classname}", $"{wornweapon}", $"{wornaccessory}" };

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(savePath, "savefile01.txt")))
                foreach (string s in savedata)
                {
                    outputFile.WriteLine(s);
                }
            Console.WriteLine("Your data has been saved!");
            return;
        }
    }
}
