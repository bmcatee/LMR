using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Menus
    {

        public static void MenuGeneric(string menuTracker)
        {
            UI userInterface = new(0, "", "", 0);

            userInterface.MenuTracker = menuTracker;
            userInterface.MenuInput = "";
            Console.Clear();

            UI.UIHeaderGeneric();

            switch (userInterface.MenuTracker)
            {
                case "MenuMain":
                    userInterface.CursorOffset = 2;
                    userInterface.MenuLength = DataLists.MenuMain.GetLength(0);
                    for (int i = 0; i < DataLists.MenuMain.GetLength(0); ++i)
                    {
                        Console.WriteLine($"[{userInterface.CursorSymbol}] {DataLists.MenuMain[i, 0]}");
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
                    TestMenu();
                        break;
                default:
                    UI.InvalidSelection();
                    break;
            }
            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
            }
            MenuSelection(userInterface.SelectedOption);
        }

        public static void MenuSelection(int selectedoption)
        {
                switch(selectedoption)
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
                    Menus.TestMenu();
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
        }
        public static void TestMenu()
        {
            UI userInterface = new(0, "", "", 0);

            userInterface.CursorOffset = 2;
            userInterface.SelectedOption = 0;
            Console.Clear();
            userInterface.MenuInput = "";
            UI.UIHeaderGeneric();
            userInterface.MenuLength = DataLists.MenuTest.GetLength(0);
            for (int i = 0; i < DataLists.MenuTest.GetLength(0); ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {DataLists.MenuTest[i, 0]}");
            }
            UI.UIFooterGeneric();
            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
            }
            TestMenuSelection();
        }

        public static void TestMenuSelection()
        {
            UI userInterface = new(0, "", "", 0);

            if (userInterface.MenuInput != "Enter")
            {

            }
            else
            {
                switch (userInterface.SelectedOption)
                {
                    case 0:
                        QuestEngine.InitStageArray();
                        Console.ReadLine();
                        break;
                    case 1:
                        Program.PrintLists();
                        break;
                    case 2:
                        Program.PrintColorList();
                        break;
                    case 3:
                        Menus.MenuGeneric("MenuMain");
                        break;
                    default:
                        UI.InvalidSelection();
                        break;
                }
            }
        }
    }
}


