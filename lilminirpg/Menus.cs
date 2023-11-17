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

        public async static Task MenuGeneric(string menuTracker)
        {
            Player currentPlayer = new Player();
            UI userInterface = new();

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
//                    CharacterMaker.SetCharacterName();
                    break;
                case "MenuPlayerClass":
//                    currentPlayer.PlayerJob = JobMethods.SetPlayerJob(currentPlayer);
                    break;
                case "MenuPlayerWeapon":
//                    CharacterMaker.ChooseCharacterInfo(menuTracker);
                    break;
                case "MenuPlayerAccessory":
//                    CharacterMaker.ChooseCharacterInfo(menuTracker);
                    break;
                case "MenuTest":
                    await TestMenu();
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
            await MenuSelection(userInterface.SelectedOption);
        }

        public async static Task MenuSelection(int selectedoption)
        {
            switch (selectedoption)
            {
                case 0:
                    CharacterMaker _charactermaker = new CharacterMaker();
                    _charactermaker.MakeCharacter();
                    break;
                case 1:
                    SaveLoad.LoadGame();
                    MenuGeneric("MenuMain");
                    break;
                case 2:
                    UI.InvalidSelection();
                    break;
                case 3:
                    UI.InvalidSelection();
                    break;
                case 4:
                    await Menus.TestMenu();
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
        }
        public async static Task TestMenu()
        {
            UI userInterface = new();

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
            await TestMenuSelection(userInterface.SelectedOption);
        }

        public async static Task TestMenuSelection(int selectedoption)
        {
            switch (selectedoption)
            {
                case 0:
                    await QuestEngine.InitStageArray(SaveLoad.LoadGame());
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


