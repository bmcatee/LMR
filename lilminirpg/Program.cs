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
            string savedata = $"{DateTimeOffset.Now} - {e.ToString()} \n\t In the log routine, caught {e.GetType()} \n\t Message: {e.Message}";
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_error_log.log";
            string savepath = folder + filename;
            File.AppendAllText(savepath, savedata);
            return false;
        }
        public static bool LogException(int o, string e)
        {
            string savedata = $"{DateTimeOffset.Now} - {e.ToString()} \n\t Error - Related string: {e}; Related int: {o}";
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_error_log.log";
            string savepath = folder + filename;
            File.AppendAllText(savepath, savedata);
            return false;
        }

        // Prints character information
        public async static Task PrintLists(Player currentPlayer)
        {
            Console.WriteLine($"{currentPlayer.Name} the Level {currentPlayer.CurrentLevel} {currentPlayer.PlayerJob.Name}");
            Console.WriteLine($"Maximum HP: {currentPlayer.HealthPointsMax}");
            Console.WriteLine($"Current XP: {currentPlayer.XPCurrent} - XP to Level: {currentPlayer.XPToLevel - currentPlayer.XPCurrent} - Banked XP {currentPlayer.XPBanked}");
            Console.WriteLine($"Total GP: {currentPlayer.GoldCurrent} - Current Stage: {currentPlayer.CurrentStage} - Highest Stage Reached: {currentPlayer.MaximumStage}");
            Console.WriteLine("");
            Console.WriteLine($"Total STR: {currentPlayer.StatStrength} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatStrength} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatStrength} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatStrength + currentPlayer.WornWeapon.StatStrength + currentPlayer.WornAccessory.StatStrength} (total)");
            Console.WriteLine($"Total DEX: {currentPlayer.StatDexterity} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatDexterity} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatDexterity} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatDexterity + currentPlayer.WornWeapon.StatDexterity + currentPlayer.WornAccessory.StatDexterity} (total)");
            Console.WriteLine($"Total INT: {currentPlayer.StatIntelligence} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatIntelligence} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatIntelligence} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatIntelligence + currentPlayer.WornWeapon.StatIntelligence + currentPlayer.WornAccessory.StatIntelligence} (total)");
            Console.WriteLine($"Total LUK: {currentPlayer.StatLuck} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.StatLuck} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.StatLuck} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.StatLuck + currentPlayer.WornWeapon.StatLuck + currentPlayer.WornAccessory.StatLuck} (total)");
            Console.WriteLine($"Growth: {currentPlayer.PlayerJob.StrengthGrowth} STR - {currentPlayer.PlayerJob.DexterityGrowth} DEX - {currentPlayer.PlayerJob.IntelligenceGrowth} INT - {currentPlayer.PlayerJob.LuckGrowth} LUK");
            Console.WriteLine("");
            Console.WriteLine($"MOV SPD: {currentPlayer.PlayerJob.MoveSpeed} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.MoveSpeed} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.MoveSpeed} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.PlayerJob.MoveSpeed - currentPlayer.WornWeapon.MoveSpeed - currentPlayer.WornAccessory.MoveSpeed} (total) - (remember lower speed is better!)");
            Console.WriteLine($"ATK SPD: {currentPlayer.PlayerJob.AttackSpeed} ({currentPlayer.PlayerJob.Name} base) + {currentPlayer.WornWeapon.AttackSpeed} ({currentPlayer.WornWeapon.Name}) + {currentPlayer.WornAccessory.AttackSpeed} ({currentPlayer.WornAccessory.Name}) = {currentPlayer.PlayerJob.AttackSpeed - currentPlayer.WornWeapon.AttackSpeed - currentPlayer.WornAccessory.AttackSpeed} (total) - (remember lower speed is better!)");
            Console.WriteLine("");
            Console.WriteLine($"Weapon: {currentPlayer.WornWeapon.Name} - Attack Type: {currentPlayer.WornWeapon.AttackType} damage - Elemental Type: {currentPlayer.WornWeapon.ElementType} - Attacks with {currentPlayer.WornWeapon.AttackStat1}/{currentPlayer.WornWeapon.AttackPercent1}% & {currentPlayer.WornWeapon.AttackStat2}/{currentPlayer.WornWeapon.AttackPercent2}% - Perk: Not Yet Implemented!");
            Console.WriteLine("");
            Console.WriteLine($"Accessory: {currentPlayer.WornAccessory.Name} - Perk: Not Yet Implemented");
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
            Console.WriteLine($"Press Enter to continue");
            Console.ReadLine();
            await Menus.TestMenu();
        }
    }
}