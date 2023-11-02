using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal static class UI
    {
        public static char Cursor = ' ';
        public static int SelectedOption { get; set; }
        public static string MenuInput { get; set; }
        public static string MenuTracker { get; set; }

        public static int MenuLength { get; set; }

        // Menu selection UP
        public static void SelectUp()
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
        public static void SelectDown()
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

        // Choose selected menu item
        public static int GetSelection()
        {
            return SelectedOption;
        }

        // Tracks which menu is being accessed; used primarily in character creator
        // May not be needed once each character making section is seperated out?
        public static void MenuSelector(string menutracker)
        {
            MenuTracker = menutracker;

            if (MenuTracker == "MenuMain")
            {
                Menus.MenuMain();
            }
            else if (MenuTracker == "MenuPlayerName")
            {
                
            }
            else if (MenuTracker == "MenuPlayerClass")
            {
                Menus.MenuPlayerClass();
            }
            else if (MenuTracker == "MenuWeapon")
            {
                Menus.MenuPlayerWeapon();
            }
            else if (MenuTracker == "MenuAccessory")
            {
                Menus.MenuPlayerAccessory();
            }
        }
    }
}
