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

                // Begin character creation
                while (menus.MenuInput != "Escape")
                {
                    // Set character name

                    Console.CursorVisible = true;
                    Console.WriteLine("Welcome new player! Please type your character's name and press Enter:");
                    _player.CharacterName = Console.ReadLine();
                  
                    menus.SelectedOption = 0;
                    menus.MenuInput = "";

                    // Character class
                    while (menus.MenuInput != "Enter")
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
                            if (i == menus.SelectedOption)
                            {
                                menus.Cursor = '*';
                            }
                            else
                            {
                                menus.Cursor = ' ';
                            }
                            Console.WriteLine($"[{menus.Cursor}] {itemlists.PlayerClasses[i, 0]}: {itemlists.PlayerClasses[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        menus.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (menus.MenuInput == "UpArrow")
                        {
                            menus.SelectUp();
                        }
                        else if (menus.MenuInput == "DownArrow")
                        {
                            menus.SelectDown();
                        }
                    }
                    if (menus.SelectedOption < itemlists.PlayerClasses.GetLength(0))
                    {
                        _player.ClassName = itemlists.PlayerClasses[menus.SelectedOption, 0];
                    }
                    else
                    {
                        menus.InvalidSelection();
                    }

                    // Set player weapon
                    menus.SelectedOption = 0;
                    menus.MenuInput = "";

                    while (menus.MenuInput != "Enter")
                    {
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName}");
                        Console.WriteLine("");
                        Console.WriteLine("Now please choose a weapon:");
                        Console.WriteLine("");

                        for (int i = 0; i < itemlists.PlayerWeapons.GetLength(0); i++)
                        {
                            if (i == menus.SelectedOption)
                            {
                                menus.Cursor = '*';
                            }
                            else
                            {
                                menus.Cursor = ' ';
                            }
                            Console.WriteLine($"[{menus.Cursor}] {itemlists.PlayerWeapons[i, 0]}: {itemlists.PlayerWeapons[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        menus.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (menus.MenuInput == "UpArrow")
                        {
                            menus.SelectUp();
                        }
                        else if (menus.MenuInput == "DownArrow")
                        {
                            menus.SelectDown();
                        }
                    }
                    if (menus.SelectedOption < itemlists.PlayerWeapons.GetLength(0))
                    {
                        _player.WornWeapon = itemlists.PlayerWeapons[menus.SelectedOption, 0];
                    }
                    else
                    {
                        menus.InvalidSelection();
                    }

                    menus.SelectedOption = 0;
                    menus.MenuInput = "";
                    while (menus.MenuInput != "Enter")
                    {
                        Console.Clear();
                        Console.CursorVisible = false;
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon}");
                        Console.WriteLine("");
                        Console.WriteLine("Now please choose an accessory.");
                        Console.WriteLine("");
                        for (int i = 0; i < itemlists.PlayerAccessories.GetLength(0); i++)
                        {

                            if (i == menus.SelectedOption)
                            {
                                menus.Cursor = '*';
                            }
                            else
                            {
                                menus.Cursor = ' ';
                            }
                            Console.WriteLine($"[{menus.Cursor}] {itemlists.PlayerAccessories[i, 0]}: {itemlists.PlayerAccessories[i, 1]}");
                        }
                        Console.WriteLine("");
                        Console.WriteLine("(Use the arrow keys + Enter to make your selection)");
                        menus.MenuInput = Console.ReadKey(true).Key.ToString();
                        if (menus.MenuInput == "UpArrow")
                        {
                            menus.SelectUp();
                        }
                        else if (menus.MenuInput == "DownArrow")
                        {
                            menus.SelectDown();
                        }
                        if (menus.SelectedOption < itemlists.PlayerAccessories.GetLength(0))
                        {
                            _player.WornAccessory = itemlists.PlayerAccessories[menus.SelectedOption, 0];
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
