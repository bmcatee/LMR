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
        public static void MenuGeneric(string menuTracker)
        {
            Console.Clear();
            UI.MenuTracker = menuTracker;
            UI.MenuInput = "";
            UI.UIHeaderGeneric();

            switch (menuTracker)
            {
                case "MenuMain":
                    UI.CursorOffset = 2;
                    UI.MenuLength = DataLists.MenuMain.GetLength(0);
                    for (int i = 0; i < DataLists.MenuMain.GetLength(0); ++i)
                    {
                        Console.WriteLine($"[{UI.CursorSymbol}] {DataLists.MenuMain[i, 0]}");
                    }
                    break;
                case "MenuPlayerName":
                    CharacterMaker.SetCharacterName();
                    break;
                case "MenuPlayerClass":
                    CharacterMaker.ChooseCharacterInfo(menuTracker);
                    break;
                case "MenuPlayerWeapon":
                    CharacterMaker.ChooseCharacterInfo(menuTracker);
                    break;
                case "MenuPlayerAccessory":
                    CharacterMaker.ChooseCharacterInfo(menuTracker);
                    break;
                case "MenuTest":
                    UI.InvalidSelection();
                    break;
                default:
                    UI.InvalidSelection();
                    break;
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
            if (UI.MenuInput != "Enter")
            {
                
            }
            else
            {
                switch(UI.SelectedOption)
                {
                    case 0:
                        CharacterMaker _charactermaker = new CharacterMaker();
                        _charactermaker.MakeCharacter();
                        break;
                    case 1:
                        SaveLoad.LoadGame();
                        break;
                     case 2:
                        UI.InvalidSelection();
                        break;
                     case 3:
                        UI.InvalidSelection();
                        break;
                     case 4:
                        // METHOD TESTS
                        QuestEngine.InitStageArray();
                        Console.ReadKey();
                        // QuestEngine.FillStageArray();
                        // Movement.PlayerPosition(2);
                        // Program.PrintLists();
                        // EnemyMaker.MakeEnemy(1);
                        // Program.PrintColorList();
                        break;
                    default:
                        UI.InvalidSelection();
                        break;
                }
            }
        }
    }
}

