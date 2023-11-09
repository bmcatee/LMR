using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class SaveLoad
    {
        // Save game method
        public static void SaveGame(string characterName, string className, string wornWeapon, string wornAccessory)
        {
            string[] savedata = { $"{characterName}", $"{className}", $"{wornWeapon}", $"{wornAccessory}" };
            string folder = "C:\\Users\\bmcat\\Documents\\Projects\\lilminirpg\\";
            string filename = "lmr_save_001.txt";
            string savepath = folder + filename;
            using (StreamWriter outputFile = new StreamWriter(savepath))
                foreach (string s in savedata)
                {
                    outputFile.WriteLine(s);
                }
            Console.WriteLine("");
            Console.WriteLine("Your data has been saved! Press Enter to continue.");
            Console.ReadLine();
            UI.MenuInput = "";
        }

        [STAThread]
        public static void LoadGame()
        {
            string line;
            Console.Clear();
            Console.WriteLine("Now loading: lmr_save_001");
            Console.WriteLine("");

            StreamReader sr = new StreamReader("C:\\Users\\bmcat\\Documents\\Projects\\lilminirpg\\lmr_save_001.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine($"{line}");
                line = sr.ReadLine();
            }
            sr.Close();

            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Menus.MenuGeneric("MenuMain");
        }
    }
}

