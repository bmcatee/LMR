using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public static class Menus
    {
        public static void MainMenu()
        {
            for (int i = 0; i < ItemLists.MenuMain.GetLength(0); ++i)
            {
                UI.UICursor(i);
                Console.WriteLine($"[{UI.CursorSymbol}] {ItemLists.MenuMain[i, 1]}");
            }


        }
        public static void MenuGeneric(string menutracker)
        {
            UI.MenuInput = "";
            while (UI.MenuInput != "Enter")
            {
                Console.Clear();
                UI.UIHeaderGeneric();

                if (menutracker == "MenuMain")
                {
                    MainMenu();
                }
                else if (menutracker == "MenuPlayerName")
                {
                    CharacterMaker.SetCharacterName();
                }
                else if (menutracker == "MenuPlayerClass")
                {
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else if (menutracker == "MenuPlayerWeapon")
                {
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else if (menutracker == "MenuPlayerAccessory")
                {
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else
                {
                    Menus.InvalidSelection();
                }

                UI.UIFooterGeneric();
                UI.UIMovement();
            }
            
            if (UI.SelectedOption == 0 && UI.MenuInput == "Enter")
            {
                CharacterMaker _charactermaker = new CharacterMaker();
                _charactermaker.MakeCharacter();
            }
            else if (UI.SelectedOption != 0 && UI.MenuInput == "Enter")
            {
                Menus.InvalidSelection();
            }
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

