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
                    await EditCharacterMenu();
                    break;
                case "MenuTest":
                    await TestMenu();
                    break;
                case "MenuPlayerName":
                    await CharacterMaker.SetCharacterName(currentPlayer);
                    break;
                case "MenuPlayerClass":
                    await JobMethods.SetPlayerJob(currentPlayer);
                    break;
                case "MenuPlayerWeapon":
                    await WeaponMethods.SetPlayerWeapon(currentPlayer);
                    break;
                case "MenuPlayerAccessory":
                    await AccessoryMethods.SetPlayerAccessory(currentPlayer);
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

            // CHANGE THIS TO CHECK THE DB INSTEAD
            //string folder = Environment.CurrentDirectory;
            //string filename = "\\lmr_save_001.json";
            //string loadpath = folder + filename;
            Player currentPlayer = SaveLoad.LoadGame();

            switch (selectedoption)
            {
                case 0:
                    if (currentPlayer.Name != "" || currentPlayer.PlayerJob.Name != "" || currentPlayer.WornWeapon.Name != "" || currentPlayer.WornAccessory.Name != "")
                    {
                        QuestEngine.InitStageArray(SaveLoad.LoadGame());
                        //Console.ReadLine();
                    }
                    else
                    {
                        await CharacterMaker.MakeCharacter();
                    }
                    break;
                case 1:
                    await CharacterMaker.MakeCharacter();
                    break;
                case 2:
                    SaveLoad.LoadGame();
                    await MenuGeneric("MenuMain");
                    break;
                case 3:
                    if (currentPlayer.Name != "" || currentPlayer.PlayerJob.Name != "" || currentPlayer.WornWeapon.Name != "" || currentPlayer.WornAccessory.Name != "")
                    {
                        await EditCharacterMenu();
                    }
                    else
                    {
                        await CharacterMaker.MakeCharacter();
                    }
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
            switch (selectedoption + 5)
            {
                case 0:
                    QuestEngine.InitStageArray(SaveLoad.LoadGame());
                    Console.ReadLine();
                    break;
                case 1:
                    Console.WriteLine("Not implemented yet");
                    break;
                case 2:
                    await Program.PrintLists();
                    break;
                case 3:
                    Program.PrintColorList();
                    break;
                case 4:
                    await MenuGeneric("MenuMain");
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
        }
        public async static Task EditCharacterMenu()
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
            await EditMenuSelection(userInterface.SelectedOption);
        }

        public async static Task EditMenuSelection(int selectedoption)
        {
            Player currentPlayer = SaveLoad.LoadGame();
            switch (selectedoption)
            {
                case 0:
                    currentPlayer = await CharacterMaker.SetCharacterName(currentPlayer);
                    await EditCharacterMenu();
                    break;
                case 1:
                    currentPlayer = await JobMethods.SetPlayerJob(currentPlayer);
                    await EditCharacterMenu();
                    break;
                case 2:
                    currentPlayer = await WeaponMethods.SetPlayerWeapon(currentPlayer);
                    await EditCharacterMenu();
                    break;
                case 3:
                    currentPlayer = await AccessoryMethods.SetPlayerAccessory(currentPlayer);
                    await EditCharacterMenu();
                    break;
                case 4:
                    await MenuGeneric("MenuMain");
                    break;
                default:
                    UI.InvalidSelection();
                    break;
            }
        }
    }
}


