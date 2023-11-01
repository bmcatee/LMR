using System.Security.Cryptography.X509Certificates;

namespace lilminirpg
{
    internal class Program
    {
        public static void Main()
        {
            // game start
            // quit
            {
                var _player = new Player();
                var itemlists = new ItemLists();
                var menus = new Menus();
                var ui = new UI();

                // Begin character creation
                while (ui.MenuInput != "Escape")
                {
                    // Set character name

                    Console.CursorVisible = true;
                    Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
                    _player.CharacterName = Console.ReadLine();

                    ui.SelectedOption = 0;
                    ui.MenuInput = "";

                    // Character class
                    while (ui.MenuInput != "Enter")
                    {
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.WriteLine($"Name: {_player.CharacterName}");
                        Console.WriteLine("");
                        Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");
                        Console.WriteLine("Your class choices are:");
                        Console.WriteLine("");

                        for (int i = 0; i < itemlists.PlayerClasses.GetLength(0); i++)
                        {
                            if (i == ui.SelectedOption)
                            {
                                ui.Cursor = '*';
                            }
                            else
                            {
                                ui.Cursor = ' ';
                            }
                            Console.WriteLine($"[{ui.Cursor}] {itemlists.PlayerClasses[i, 0]}: {itemlists.PlayerClasses[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        ui.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (ui.MenuInput == "UpArrow")
                        {
                            ui.SelectUp();
                        }
                        else if (ui.MenuInput == "DownArrow")
                        {
                            ui.SelectDown();
                        }
                    }
                    if (ui.SelectedOption < itemlists.PlayerClasses.GetLength(0))
                    {
                        _player.ClassName = itemlists.PlayerClasses[ui.SelectedOption, 0];
                    }
                    else
                    {
                        menus.InvalidSelection();
                    }

                    // Set player weapon
                    ui.SelectedOption = 0;
                    ui.MenuInput = "";

                    while (ui.MenuInput != "Enter")
                    {
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName}");
                        Console.WriteLine("");
                        Console.WriteLine("Now please choose a weapon:");
                        Console.WriteLine("");

                        for (int i = 0; i < itemlists.PlayerWeapons.GetLength(0); i++)
                        {
                            if (i == ui.SelectedOption)
                            {
                                ui.Cursor = '*';
                            }
                            else
                            {
                                ui.Cursor = ' ';
                            }
                            Console.WriteLine($"[{ui.Cursor}] {itemlists.PlayerWeapons[i, 0]}: {itemlists.PlayerWeapons[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        ui.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (ui.MenuInput == "UpArrow")
                        {
                            ui.SelectUp();
                        }
                        else if (ui.MenuInput == "DownArrow")
                        {
                            ui.SelectDown();
                        }
                    }
                    if (ui.SelectedOption < itemlists.PlayerWeapons.GetLength(0))
                    {
                        _player.WornWeapon = itemlists.PlayerWeapons[ui.SelectedOption, 0];
                    }
                    else
                    {
                        menus.InvalidSelection();
                    }

                    ui.SelectedOption = 0;
                    ui.MenuInput = "";
                    while (ui.MenuInput != "Enter")
                    {
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon}");
                        Console.WriteLine("");
                        Console.WriteLine("Now please choose an accessory.");
                        Console.WriteLine("");
                        for (int i = 0; i < itemlists.PlayerAccessories.GetLength(0); i++)
                        {

                            if (i == ui.SelectedOption)
                            {
                                ui.Cursor = '*';
                            }
                            else
                            {
                                ui.Cursor = ' ';
                            }
                            Console.WriteLine($"[{ui.Cursor}] {itemlists.PlayerAccessories[i, 0]}: {itemlists.PlayerAccessories[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        ui.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (ui.MenuInput == "UpArrow")
                        {
                            ui.SelectUp();
                        }
                        else if (ui.MenuInput == "DownArrow")
                        {
                            ui.SelectDown();
                        }
                        if (ui.SelectedOption < itemlists.PlayerAccessories.GetLength(0))
                        {
                            _player.WornAccessory = itemlists.PlayerAccessories[ui.SelectedOption, 0];
                        }
                        else
                        {
                            menus.InvalidSelection();
                        }
                    }
                    Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon} || Accessory: {_player.WornAccessory}");
                    return;
                }
            }
        }
    }
}
