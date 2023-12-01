using lilminirpg;
using System.Collections;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace lilminirpg
{
    internal class Program
    { 
        public async static Task Main()
        {
            Console.WriteLine("Initializing database, please wait.");
            // Goto main menu
            try
            {
                using (var ctx = new PlayerMethods.PlayerContext())
                {
                    if (ctx.Players.Any() == false)
                    {
                        await SaveLoad.AddNewPlayerToDB();
                    }
                    await Menus.MenuGeneric("MenuMain");
                }
            }
            catch (Exception ex) when (LogException(ex))
            {
            }
        }

        // Error logging methods
        public static bool LogException(Exception e)
        {
            string savedata = $"\n\n{DateTimeOffset.Now} - {e.ToString()} \n\t In the log routine, caught {e.GetType()} \n\t Message: {e.Message}";
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_error_log.log";
            string savepath = folder + filename;
            File.AppendAllText(savepath, savedata);
            return false;
        }
        public static bool LogException(int o, string e)
        {
            string savedata = $"\n\n{DateTimeOffset.Now} - {e.ToString()} \n\t Error - Related string: {e}; Related int: {o}";
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_error_log.log";
            string savepath = folder + filename;
            File.AppendAllText(savepath, savedata);
            return false;
        }

        // Prints character information
        public static void PrintLists(Player currentPlayer)
        {

        }

        // Prints pretty colors
        public async static void PrintColorList()
        {
            ConsoleColor[] consoleColors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.WriteLine("List of available " + "Console Colors:");

            for (int i = 0; i < consoleColors.Length; ++i)
            {
                Console.ForegroundColor = consoleColors[i];
                Console.WriteLine($"Hello, World: {consoleColors[i]}");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            await Menus.TestMenu();
        }
    }
}