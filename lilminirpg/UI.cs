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

        // Writes at a specific area in the console window
        public static void WriteFromTop(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(consoleWindowTopColumn + x, consoleWindowTopRow + y);
                Console.Write(s);
            }
            catch (Exception ex) when (Program.LogException(ex))
            {
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

        // The PrintItemInfo methods display information about the selected items in their respective menus
        public void PrintItemInfo(List<Job> listPlayerJobs)
        {
            Console.CursorVisible = false;
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            for (int i = 0; i < MenuLength; ++i)
            {
                if (SelectedOption < listPlayerJobs.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"{listPlayerJobs[SelectedOption].Name}", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"HP GROWTH: {listPlayerJobs[SelectedOption].HealthPointsGrowth} || STR GROWTH: {listPlayerJobs[SelectedOption].StrengthGrowth} || DEX GROWTH: {listPlayerJobs[SelectedOption].DexterityGrowth} || INT GROWTH: {listPlayerJobs[SelectedOption].IntelligenceGrowth} || LUCK GROWTH: {listPlayerJobs[SelectedOption].LuckGrowth}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"MOV: {listPlayerJobs[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerJobs[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"PERK: Coming soon!", 1, (MenuLength + CursorOffset + 5));
                }
                else if (SelectedOption >= listPlayerJobs.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
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
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            for (int i = 0; i < MenuLength; ++i)
            {
                if (SelectedOption < listPlayerWeapons.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 6));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 7));
                    WriteFromTop($"{listPlayerWeapons[SelectedOption].Name}", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"ATK TYPE: {listPlayerWeapons[SelectedOption].AttackType} || ELEMENT: {listPlayerWeapons[SelectedOption].ElementType}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"ATK STAT 1: {listPlayerWeapons[SelectedOption].AttackStat1} ({listPlayerWeapons[SelectedOption].AttackPercent1}%) || ATK STAT 2: {listPlayerWeapons[SelectedOption].AttackStat2} ({listPlayerWeapons[SelectedOption].AttackPercent2}%)", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"HP: {listPlayerWeapons[SelectedOption].HealthPointsMax} || STR: {listPlayerWeapons[SelectedOption].StatStrength} || DEX: {listPlayerWeapons[SelectedOption].StatDexterity} || INT: {listPlayerWeapons[SelectedOption].StatIntelligence} || LUCK: {listPlayerWeapons[SelectedOption].StatLuck}", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"MOV: {listPlayerWeapons[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerWeapons[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 6));
                    WriteFromTop($"PERK: Coming soon!", 1, (MenuLength + CursorOffset + 7));
                }
                else if (SelectedOption >= listPlayerWeapons.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 6));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 7));
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
            CurrentCursorRow = Console.CursorLeft;
            CurrentCursorColumn = Console.CursorTop;
            Console.SetCursorPosition(consoleWindowTopColumn, consoleWindowTopRow);

            for (int i = 0; i < MenuLength; ++i)
            {
                if (SelectedOption < listPlayerAccessories.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
                    WriteFromTop($"{listPlayerAccessories[SelectedOption].Name}:", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"HP: {listPlayerAccessories[SelectedOption].HealthPointsMax} ||STR: {listPlayerAccessories[SelectedOption].StatStrength} || DEX: {listPlayerAccessories[SelectedOption].StatDexterity} || INT: {listPlayerAccessories[SelectedOption].StatIntelligence} || LUCK: {listPlayerAccessories[SelectedOption].StatLuck}", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"MOV: {listPlayerAccessories[SelectedOption].MoveSpeed} || ATK SPD: {listPlayerAccessories[SelectedOption].AttackSpeed}", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"PERK: Coming soon!", 1, (MenuLength + CursorOffset + 5));
                }
                else if (SelectedOption >= listPlayerAccessories.Count)
                {
                    Console.WriteLine("");
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 2));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 3));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 4));
                    WriteFromTop($"                                                                                                                                                                                                                                                                                  ", 1, (MenuLength + CursorOffset + 5));
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
            Console.WriteLine("+~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~+\n| little        mini        rpg |\n+~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~+");
        }
        public static void UICharacterInfo(Player currentPlayer)
        {
            if (currentPlayer.Name != "" || currentPlayer.PlayerJob.Name != "" || currentPlayer.WornWeapon.Name != "" || currentPlayer.WornAccessory.Name != "")
            {
                Console.WriteLine($"Character: {currentPlayer.Name}, the Level {currentPlayer.CurrentLevel} {currentPlayer.PlayerJob.Name} || Weapon: {currentPlayer.WornWeapon.Name} || Accessory: {currentPlayer.WornAccessory.Name} || {currentPlayer.XPCurrent} XP, {currentPlayer.GoldCurrent} GP, max Stage: {currentPlayer.MaximumStage}");
                Console.WriteLine("");
            }
        }

    public static void UIFooterGeneric()
        {
            Console.WriteLine("");
            Console.WriteLine("Use the arrow keys + Enter to make your selection");
        }

        // Default method for any invalid selections/bugs
        public async static void InvalidSelection()
        {
            Console.WriteLine("You have entered an invalid selection. Please press enter to restart.");
            Console.ReadLine();
            await Program.Main();
        }
    }
}
