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
            Console.Clear();
            UI.MenuTracker = menutracker;
            UI.MenuInput = "";
            UI.UIHeaderGeneric();
            if (menutracker == "MenuMain")
            {
                UI.CursorOffset = 2;
                UI.MenuLength = DataLists.MenuMain.GetLength(0);
                for (int i = 0; i < DataLists.MenuMain.GetLength(0); ++i)
                {
                    Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.MenuMain[i, 0]}");
                }
            }
            else if (menutracker == "MenuPlayerName")
            {
                CharacterMaker.SetCharacterName();
            }
            else if (menutracker == "MenuPlayerClass")
            {
                CharacterMaker.ChooseCharacterInfo(menutracker);
            }
            else if (menutracker == "MenuPlayerWeapon")
            {
                CharacterMaker.ChooseCharacterInfo(menutracker);
            }
            else if (menutracker == "MenuPlayerAccessory")
            {
                CharacterMaker.ChooseCharacterInfo(menutracker);
            }
            else if (menutracker == "MenuTest")
            {
                UI.InvalidSelection();
            }
            else
            {
                UI.InvalidSelection();
            }

            UI.UIFooterGeneric();
            while (UI.MenuInput != "Enter")
            {
                UI.PrintCursor();
                UI.UIMovement();
            }
            MenuSelection();
        }
        public static void MenuSelection()
        {
            if (UI.SelectedOption == 0 && UI.MenuInput == "Enter")
            {
                CharacterMaker _charactermaker = new CharacterMaker();
                _charactermaker.MakeCharacter();
            }
            else if (UI.SelectedOption == 1 && UI.MenuInput == "Enter")
            {
                SaveLoad.LoadGame();
            }
            else if (UI.SelectedOption == 2 && UI.MenuInput == "Enter")
            {
                UI.InvalidSelection();
            }
            else if (UI.SelectedOption == 3 && UI.MenuInput == "Enter")
            {
                UI.InvalidSelection();
            }
            else if (UI.SelectedOption == 4 && UI.MenuInput == "Enter")
            {
                // METHOD TESTS
                 QuestEngine.CreateStageArray();
                 Console.ReadKey();
                // QuestEngine.FillStageArray();
                // Movement.PlayerPosition(2);
                // Program.PrintLists();
                // EnemyMaker.MakeEnemy(1);
            }
        }
    }
}

