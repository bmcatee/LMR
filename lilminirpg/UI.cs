using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class UI
    {
        private static int consoleWindowTopRow = 0;
        private static int consoleWindowTopColumn = 0;

        public char CursorSymbol = ' ';
        public int SelectedOption { get; set; }
        public string MenuInput { get; set; }
        public string MenuTracker { get; set; }
        public int MenuLength { get; set; }
        public int CurrentCursorRow { get; set; }
        public int CurrentCursorColumn { get; set; }
        public int CursorOffset { get; set; }

        public UI()
        {

        }

        public static void WriteFromTop(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(consoleWindowTopColumn + x, consoleWindowTopRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        public void PrintCursor()
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            // Draws the cursor at the selected coordinates
            for (int i = 0; i < MenuLength; ++i)
            {
                if (i == SelectedOption)
                {
                    WriteFromTop("*", 1, (SelectedOption + CursorOffset));

                }
                else if (i != SelectedOption)
                {
                    WriteFromTop(" ", 1, (i + CursorOffset));
                }
            }
            Console.SetCursorPosition(CurrentCursorRow, CurrentCursorColumn);
            CurrentCursorRow = 0;
            CurrentCursorColumn = 0;
            Console.CursorVisible = false;
        }

        // Handles movement of menus
        public void UIMovement()
        {
            MenuInput = Console.ReadKey(true).Key.ToString();
            if (MenuInput == "UpArrow")
            {
                UISelectUp();
            }
            else if (MenuInput == "DownArrow")
            {
                UISelectDown();
            }
        }

        // Menu selection UP
        public void UISelectUp()
        {
            if (SelectedOption > 0)
            {
                PrintCursor();
                --SelectedOption;
            }
            else if (SelectedOption == 0)
            {
                PrintCursor();
                SelectedOption = MenuLength - 1;
            }
        }

        // Menu selection DOWN
        public void UISelectDown()
        {
            if (SelectedOption < MenuLength - 1)
            {
                PrintCursor();
                ++SelectedOption;
            }
            else if (SelectedOption == MenuLength - 1)
            {
                PrintCursor();
                SelectedOption = 0;
            }
        }

        // What the cursor looks like
        public void UICursor(int i)
        {
            if (i == SelectedOption)
            {
                CursorSymbol = '*';
            }
            else
            {
                CursorSymbol = ' ';
            }
        }

        // Choose selected menu item
        public int UIGetSelection()
        {
            return SelectedOption;
        }

        public void PrintItemInfo(List<Job> listPlayerJobs)
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            // Draws the cursor at the selected coordinates
            for (int i = 0; i < MenuLength; ++i)
            {
                if (i == SelectedOption)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"{listPlayerJobs[SelectedOption].Name} - HP GROWTH: {listPlayerJobs[SelectedOption].HealthPointsGrowth} || STR GROWTH: {listPlayerJobs[SelectedOption].StrengthGrowth} || DEX GROWTH: {listPlayerJobs[SelectedOption].DexterityGrowth} || INT GROWTH: {listPlayerJobs[SelectedOption].IntelligenceGrowth} || LUCK GROWTH: {listPlayerJobs[SelectedOption].LuckGrowth}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"{listPlayerJobs[SelectedOption].Name} - MOV: {listPlayerJobs[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerJobs[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"{listPlayerJobs[SelectedOption].Name} - PERK: Coming soon!", 1, (MenuLength + CursorOffset + 5));
                }
                else if (i != SelectedOption)
                {
                }
            }
            Console.SetCursorPosition(CurrentCursorRow, CurrentCursorColumn);
            CurrentCursorRow = 0;
            CurrentCursorColumn = 0;
            Console.CursorVisible = false;
        }
        public void PrintItemInfo(List<Weapon> listPlayerWeapons)
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            // Draws the cursor at the selected coordinates
            for (int i = 0; i < MenuLength; ++i)
            {
                if (i == SelectedOption)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 6));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 7));

                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name} - ATK TYPE: {listPlayerWeapons[SelectedOption].AttackType} || ELEMENT: {listPlayerWeapons[SelectedOption].ElementType}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name} - ATK STAT 1: {listPlayerWeapons[SelectedOption].AttackStat1} ({listPlayerWeapons[SelectedOption].AttackPercent1}%) || ATK STAT 2: {listPlayerWeapons[SelectedOption].AttackStat2} ({listPlayerWeapons[SelectedOption].AttackPercent2}%)", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name} - HP: {listPlayerWeapons[SelectedOption].HealthPointsMax} || STR: {listPlayerWeapons[SelectedOption].StatStrength} || DEX: {listPlayerWeapons[SelectedOption].StatDexterity} || INT: {listPlayerWeapons[SelectedOption].StatIntelligence} || LUCK: {listPlayerWeapons[SelectedOption].StatLuck}", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name} - MOV: {listPlayerWeapons[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerWeapons[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 6));
                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name} - PERK: Coming soon!", 1, (MenuLength + CursorOffset + 7));
                }
                else if (i != SelectedOption)
                {
                }
            }
            Console.SetCursorPosition(CurrentCursorRow, CurrentCursorColumn);
            CurrentCursorRow = 0;
            CurrentCursorColumn = 0;
            Console.CursorVisible = false;
        }
        public void PrintItemInfo(List<Accessory> listPlayerAccessories)
        {
            Console.CursorVisible = false;
            // Sets cursor position to 0
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            // Draws the cursor at the selected coordinates
            for (int i = 0; i < MenuLength; ++i)
            {
                if (i == SelectedOption)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"{listPlayerAccessories[SelectedOption].Name} - HP: {listPlayerAccessories[SelectedOption].HealthPointsMax} ||STR: {listPlayerAccessories[SelectedOption].StatStrength} || DEX: {listPlayerAccessories[SelectedOption].StatDexterity} || INT: {listPlayerAccessories[SelectedOption].StatIntelligence} || LUCK: {listPlayerAccessories[SelectedOption].StatLuck}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"{listPlayerAccessories[SelectedOption].Name} - MOV: {listPlayerAccessories[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerAccessories[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"{listPlayerAccessories[SelectedOption].Name} - PERK: Coming soon!", 1, (MenuLength + CursorOffset + 5));
                }
                else if (i != SelectedOption)
                {
                }
            }
            Console.SetCursorPosition(CurrentCursorRow, CurrentCursorColumn);
            CurrentCursorRow = 0;
            CurrentCursorColumn = 0;
            Console.CursorVisible = false;
        }

        // Header/footer
        public static void UIHeaderGeneric()
        {
            Console.WriteLine("Now playing: lil mini rpg");
            Console.WriteLine("");
        }
        public static void UICharacterInfo(Player currentPlayer)
        {
            string folder = Environment.CurrentDirectory;
            string filename = "\\lmr_save_001.json";
            string loadpath = folder + filename;

            if (File.Exists(loadpath))
            {
                Console.WriteLine($"Character: {currentPlayer.Name}, the Level {currentPlayer.CurrentLevel} {currentPlayer.PlayerJob.Name} || Weapon: {currentPlayer.WornWeapon.Name} || Accessory: {currentPlayer.WornAccessory.Name} || {currentPlayer.XPCurrent} XP, {currentPlayer.GoldCurrent} GP, max Stage: {currentPlayer.MaximumStage}");
                Console.WriteLine("");
            }
        }

    public static void UIFooterGeneric()
        {
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
        }

        // Default method for any invalid selections/bugs
        public static void InvalidSelection()
        {
            Console.WriteLine("You have entered an invalid selection. Please press enter to restart.");
            Console.ReadLine();
            Program.Main();
        }
    }
}
