using lilminirpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Menus
    {

        public async static Task MenuGeneric(string menuTracker)
        {
            Player currentPlayer = SaveLoad.LoadGame();
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
                case "MenuEdit":
                    EditCharacterMenu();
                    break;
                case "MenuTest":
                    await TestMenu();
                    break;
                case "MenuPlayerName":
                    CharacterMaker.SetCharacterName(currentPlayer);
                    break;
                case "MenuPlayerClass":
                    JobMethods.SetPlayerJob(currentPlayer);
                    break;
                case "MenuPlayerWeapon":
                    WeaponMethods.SetPlayerWeapon(currentPlayer);
                    break;
                case "MenuPlayerAccessory":
                    AccessoryMethods.SetPlayerAccessory(currentPlayer);
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
            UI.UIFooterGeneric();
            UI.UICharacterInfo(currentPlayer);
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
                    await QuestEngine.InitStageArray(SaveLoad.LoadGame());
                    break;
                case 1:
                    CharacterMaker _charactermaker = new CharacterMaker();
                    _charactermaker.MakeCharacter();
                    break;
                case 2:
                    SaveLoad.LoadGame();
                    MenuGeneric("MenuMain");
                    break;
                case 3:
                    EditCharacterMenu();
                    break;
                case 4:
                    UI.InvalidSelection();
                    break;
                case 5:
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
            Player currentPlayer = SaveLoad.LoadGame();

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
            UI.UICharacterInfo(currentPlayer);

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
        public static void EditCharacterMenu()
        {
            UI userInterface = new();
            Player currentPlayer = SaveLoad.LoadGame();

            userInterface.CursorOffset = 2;
            userInterface.SelectedOption = 0;
            Console.Clear();
            userInterface.MenuInput = "";
            UI.UIHeaderGeneric();
            userInterface.MenuLength = DataLists.MenuEdit.GetLength(0);
            for (int i = 0; i < DataLists.MenuEdit.GetLength(0); ++i)
            {
                Console.WriteLine($"[{userInterface.CursorSymbol}] {DataLists.MenuEdit[i, 0]}");
            }
            UI.UIFooterGeneric();
            UI.UICharacterInfo(currentPlayer);

            while (userInterface.MenuInput != "Enter")
            {
                userInterface.PrintCursor();
                userInterface.UIMovement();
            }
            EditMenuSelection(userInterface.SelectedOption);
        }

        public static void EditMenuSelection(int selectedoption)
        {
            Player currentPlayer = SaveLoad.LoadGame();
            switch (selectedoption)
            {
                case 0:
                    currentPlayer = CharacterMaker.SetCharacterName(currentPlayer);
                    EditCharacterMenu();
                    break;
                case 1:
                    currentPlayer.PlayerJob = JobMethods.SetPlayerJob(currentPlayer);
                    EditCharacterMenu();
                    break;
                case 2:
                    currentPlayer.WornWeapon = WeaponMethods.SetPlayerWeapon(currentPlayer);
                    EditCharacterMenu();
                    break;
                case 3:
                    currentPlayer.WornAccessory = AccessoryMethods.SetPlayerAccessory(currentPlayer);
                    EditCharacterMenu();
                    break;
                case 4:
                    Menus.MenuGeneric("MenuMain");
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
        }
    }
}


