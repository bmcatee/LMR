using lilminirpg;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    public class Menus
    {
        // This is a little bit of a mess ngl
        // I may port this to Godot or Unity so refactoring the menus hasn't been a top priority atm
        // Anyway - this is the main menu, essentially
        public async static Task MenuGeneric(string menuTracker)
        {
            Player currentPlayer = SaveLoad.LoadGame();
            UI userInterface = new();

            userInterface.MenuTracker = menuTracker;
            userInterface.MenuInput = "";
            Console.Clear();
            UI.UIHeaderGeneric();
            Console.WriteLine("");

            switch (userInterface.MenuTracker)
            {
                case "MenuMain":
                    userInterface.CursorOffset = 4;
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
                    string location = "MenuGeneric" + $" {userInterface.MenuTracker}";
                    Program.LogException(userInterface.SelectedOption, location);
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
        // And this is the menu selection method
        public async static Task MenuSelection(int selectedoption)
        {
            Player currentPlayer = SaveLoad.LoadGame();

            switch (selectedoption)
            {
                case 0:
                    if (currentPlayer.Name != "" && currentPlayer.PlayerJob.Name != "" && currentPlayer.WornWeapon.Name != "" && currentPlayer.WornAccessory.Name != "")
                    {
                        QuestEngine.InitStageArray(SaveLoad.LoadGame());
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
                    if (currentPlayer.Name != "" && currentPlayer.PlayerJob.Name != "" && currentPlayer.WornWeapon.Name != "" && currentPlayer.WornAccessory.Name != "")
                    {
                        Player loadedPlayer = SaveLoad.LoadGame();
                        Console.Clear();
                        Console.WriteLine($"Player {loadedPlayer.Name} loaded.");
                        DataLists.PrintCharacterInfo(loadedPlayer);
                        Console.WriteLine("");
                        Console.WriteLine($"Press Enter to continue.");
                        Console.ReadLine();
                        await MenuGeneric("MenuMain");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please make a character first!");
                        Console.WriteLine("Press Enter to return to the main menu.");
                        Console.ReadLine();
                        await MenuGeneric("MenuMain");
                    }
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
                    Console.Clear();
                    DataLists.HowToPlay();
                    Console.ReadLine();
                    await MenuGeneric("MenuMain");
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                case 6:
                    await Menus.TestMenu();
                    break;
                default:
                    string location = "MenuSelection";
                    Program.LogException(selectedoption, location);
                    UI.InvalidSelection();
                    break;
            }
        }

        // Test/debug menu
        public async static Task TestMenu()
        {
            UI userInterface = new();
            Player currentPlayer = SaveLoad.LoadGame();

            userInterface.CursorOffset = 4;
            userInterface.SelectedOption = 0;
            Console.Clear();
            userInterface.MenuInput = "";
            UI.UIHeaderGeneric();
            Console.WriteLine("");
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
                    QuestEngine.InitStageArray(SaveLoad.LoadGame());
                    Console.ReadLine();
                    break;
                case 1:
                    Player loadedPlayer = SaveLoad.LoadGame();
                    Console.Clear();
                    Console.WriteLine($"Player {loadedPlayer.Name} loaded.");
                    DataLists.PrintCharacterInfo(loadedPlayer);
                    Console.WriteLine("");
                    Console.WriteLine($"Press Enter to continue.");
                    Console.ReadLine();
                    await MenuGeneric("MenuTest");
                    break;
                case 2:
                    Program.PrintColorList();
                    break;
                case 3:
                    await MenuGeneric("MenuMain");
                    break;
                 default:
                    string location = "TestMenu";
                    Program.LogException(selectedoption, location);
                    UI.InvalidSelection();
                    break;
            }
        }

        // Edit character menu; sets job/weapon/accessory and name
        public async static Task EditCharacterMenu()
        {
            UI userInterface = new();
            Player currentPlayer = SaveLoad.LoadGame();

            userInterface.CursorOffset = 4;
            userInterface.SelectedOption = 0;
            Console.Clear();
            userInterface.MenuInput = "";
            UI.UIHeaderGeneric();
            Console.WriteLine("");
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
                    string location = "EditCharacterMenu";
                    Program.LogException(selectedoption, location);
                    UI.InvalidSelection();
                    break;
            }
        }
    }
}


