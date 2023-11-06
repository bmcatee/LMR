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
        public static void MenuGeneric(string menutracker)
        {
            UI.MenuTracker = menutracker;
            UI.MenuInput = "";
            while (UI.MenuInput != "Enter")
            {
                Console.Clear();
                UI.UIHeaderGeneric();

                if (menutracker == "MenuMain")
                {
                    UI.MenuLength = DataLists.MenuMain.GetLength(0);
                    for (int i = 0; i < DataLists.MenuMain.GetLength(0); ++i)
                    {
                        UI.UICursor(i);
                        Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.MenuMain[i, 1]}");
                    }
                }
                else if (menutracker == "MenuPlayerName")
                {
                    CharacterMaker.SetCharacterName();
                }
                else if (menutracker == "MenuPlayerClass")
                {
                    UI.MenuLength = DataLists.PlayerClasses.GetLength(0);
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else if (menutracker == "MenuPlayerWeapon")
                {
                    UI.MenuLength = DataLists.PlayerWeapons.GetLength(0);
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else if (menutracker == "MenuPlayerAccessory")
                {
                    UI.MenuLength = DataLists.PlayerAccessories.GetLength(0);
                    CharacterMaker.SetCharacterInfo(menutracker);
                }
                else
                {
                    UI.InvalidSelection();
                }

                UI.UIFooterGeneric();
                UI.UIMovement();
            }
            
            if (UI.SelectedOption == 0 && UI.MenuInput == "Enter")
            {
                CharacterMaker _charactermaker = new CharacterMaker();
                _charactermaker.MakeCharacter();
            }
            else if (UI.SelectedOption == 1 && UI.MenuInput == "Enter")
            {
                SaveLoad.LoadGame();
            }
            else if (UI.SelectedOption != 0 && UI.MenuInput == "Enter")
            {
                UI.InvalidSelection();
            }
        }
    }
}

