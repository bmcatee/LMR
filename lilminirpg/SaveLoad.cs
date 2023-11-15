using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lilminirpg
{
    public class SaveLoad
    {
        // Save game method
        public static void SaveGame(Player newPlayer)
        {
            string savedata = JsonSerializer.Serialize<Player>(newPlayer, new JsonSerializerOptions { WriteIndented = true });

            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_save_001.json";
            string savepath = folder + filename;
            //Console.WriteLine($"{folder} + {filename}");
            //Console.WriteLine($"{savepath}");
            //Console.ReadLine();
            File.WriteAllText(savepath, savedata);

            Console.WriteLine("");
            Console.WriteLine($"Your data has been saved to {Path.Combine(Directory.GetCurrentDirectory())}/{filename}!");        }

        [STAThread]
        public static void LoadGame()
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_save_001.json";
            string line;
            Console.Clear();
            Console.WriteLine("Now loading: lmr_save_001");
            Console.WriteLine("");

            StreamReader sr = new StreamReader(Path.Combine(folder, filename));


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

// TESTS
// Console.WriteLine($"{path} - {folder} - {filename} - {savepath}");
// Console.ReadLine();