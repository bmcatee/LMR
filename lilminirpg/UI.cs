using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class UI
    {
        public static char CursorSymbol = ' ';
        public static int SelectedOption { get; set; }
        public static string MenuInput { get; set; }
        public static string MenuTracker { get; set; }
        public static int MenuLength { get; set; }

        // Handles movement of menus
        public static void UIMovement()
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
        public static void UISelectUp()
        {
            if (SelectedOption > 0)
            {
                Console.Clear();
                --SelectedOption;
            }
            else if (SelectedOption == 0)
            {
                Console.Clear();
                SelectedOption = MenuLength - 1;
            }
        }

        // Menu selection DOWN
        public static void UISelectDown()
        {
            if (SelectedOption < MenuLength - 1)
            {
                Console.Clear();
                ++SelectedOption;
            }
            else if (SelectedOption == MenuLength - 1)
            {
                Console.Clear();
                SelectedOption = 0;
            }
        }

        // What the cursor looks like
        public static void UICursor(int i)
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
        public static int UIGetSelection()
        {
            return SelectedOption;
        }

        public static void UIHeaderGeneric()
        {
            Console.WriteLine("Now playing: lil mini rpg");
            Console.WriteLine("");
        }

        public static void UIFooterGeneric()
        {
            Console.WriteLine("");
            Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
//            Console.WriteLine($"UI.CursorSymbol = {UI.CursorSymbol} || UI.MenuTracker = {UI.MenuTracker} || UI.SelectedOption = {UI.SelectedOption} || UI.MenuInput = {UI.MenuInput} || UI.MenuLength = {UI.MenuLength}");
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
