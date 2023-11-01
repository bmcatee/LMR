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
                int selectedoption = 0;
                string menuinput = null;
                char cursor = ' ';
                var _player = new Player();
                var playerClasses = new ItemLists().PlayerClasses;
                var playerWeapons = new ItemLists().PlayerWeapons;
                var playerAccessories = new ItemLists().PlayerAccessories;
                var menus = new Menus();

                // Begin character creation
                while (menuinput != "Escape")
                {
                    // Set character name

                    Console.CursorVisible = true;
                    Console.WriteLine("Welcome new player! Please enter your character's name:");
                    _player.CharacterName = Console.ReadLine();
                    Console.Clear();
                    selectedoption = 0;
                    menuinput = "";
                    cursor = ' ';


                    // Character class
                    while (menuinput != "Enter")
                    {
                        Console.CursorVisible = false;
                        Console.WriteLine($"Hello {_player.CharacterName}! Next you will choose your class, a weapon, and an accessory.");
                        Console.WriteLine("Your class choices are:");
                        for (int i = 0; i < playerClasses.GetLength(0); i++)
                        {
                                if (i == selectedoption)
                                {
                                    cursor = '*';
                                }
                                else
                                {
                                    cursor = ' ';
                                }
                                Console.WriteLine($"[{cursor}] {playerClasses[i, 0]}: {playerClasses[i, 1]}");

                        }
                        menuinput = Console.ReadKey(true).Key.ToString();
                        if (menuinput == "UpArrow")
                        {
                            Console.Clear();
                            selectedoption--;
                            if (selectedoption < 0)
                            {
                                selectedoption = playerClasses.Length - 1;
                            }
                        }
                        else if (menuinput == "DownArrow")
                        {
                            Console.Clear();
                            selectedoption++;
                            if (selectedoption > playerClasses.Length - 1)
                            {
                                selectedoption = 0;
                            }
                        }
                    }
                    if (selectedoption == 0)
                    {
                        _player.ClassName = playerClasses[0,0];
                    }
                    else if (selectedoption == 1)
                    {
                        _player.ClassName = playerClasses[1,0];
                    }
                    else if (selectedoption == 2)
                    {
                        _player.ClassName = playerClasses[2,0];
                    }
                    else if (selectedoption == 3)
                    {
                        _player.ClassName = playerClasses[3,0];
                    }
                    else if (selectedoption == 4)
                    {
                        _player.ClassName = playerClasses[4,0];
                    }
                    else
                    {
                        menus.InvalidSelection();
                    }
                    
                    // Set player weapon
                    selectedoption = 0;
                    menuinput = "";

                    while (menuinput != "Enter")
                    {
                        Console.CursorVisible = false;
                        Console.Clear();
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName}");
                        Console.WriteLine("Now please choose a weapon:");
                        for (int i = 0; i < playerWeapons.GetLength(0); i++)
                        {
                            if (i == selectedoption)
                            {
                                cursor = '*';
                            }
                            else
                            {
                                cursor = ' ';
                            }
                            Console.WriteLine($"[{cursor}] {playerWeapons[i, 0]}: {playerWeapons[i, 1]}");
                        }
                        menuinput = Console.ReadKey(true).Key.ToString();
                        if (menuinput == "UpArrow")
                        {
                            Console.Clear();
                            selectedoption--;
                            if (selectedoption < 0)
                            {
                                selectedoption = playerWeapons.Length - 1;
                            }
                        }
                        else if (menuinput == "DownArrow")
                        {
                            Console.Clear();
                            selectedoption++;
                            if (selectedoption > playerWeapons.Length - 1)
                            {
                                selectedoption = 0;
                            }
                        }
                        if (selectedoption == 0)
                        {
                            _player.WornWeapon = playerWeapons[0, 0];
                        }
                        else if (selectedoption == 1)
                        {
                            _player.WornWeapon = playerWeapons[1, 0];
                        }
                        else if (selectedoption == 2)
                        {
                            _player.WornWeapon = playerWeapons[2, 0];
                        }
                        else if (selectedoption == 3)
                        {
                            _player.WornWeapon = playerWeapons[3, 0];
                        }
                        else if (selectedoption == 4)
                        {
                            _player.WornWeapon = playerWeapons[4, 0];
                        }
                        else if (selectedoption == 5)
                        {
                            _player.WornWeapon = playerWeapons[5, 0];
                        }
                        else
                        {
                            menus.InvalidSelection();
                        }
                    }

                    selectedoption = 0;
                    menuinput = "";
                    while (menuinput != "Enter")
                    {
                        Console.CursorVisible = false;
                        Console.Clear();
                        Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon}");
                        Console.WriteLine("Now please choose an accessory.");
                        for (int i = 0; i < playerAccessories.GetLength(0); i++)
                        {

                            if (i == selectedoption)
                            {
                                cursor = '*';
                            }
                            else
                            {
                                cursor = ' ';
                            }
                            Console.WriteLine($"[{cursor}] {playerAccessories[i, 0]}: {playerAccessories[i, 1]}");
                        }
                        menuinput = Console.ReadKey(true).Key.ToString();
                        if (menuinput == "UpArrow")
                        {
                            Console.Clear();
                            selectedoption--;
                            if (selectedoption < 0)
                            {
                                selectedoption = playerAccessories.Length - 1;
                            }
                        }
                        else if (menuinput == "DownArrow")
                        {
                            Console.Clear();
                            selectedoption++;
                            if (selectedoption > playerAccessories.Length - 1)
                            {
                                selectedoption = 0;
                            }
                        }
                        if (selectedoption == 0)
                        {
                            _player.WornAccessory = playerAccessories[0, 0];
                        }
                        else if (selectedoption == 1)
                        {
                            _player.WornAccessory = playerAccessories[1, 0];
                        }
                        else if (selectedoption == 2)
                        {
                            _player.WornAccessory = playerAccessories[2, 0];
                        }
                        else if (selectedoption == 3)
                        {
                            _player.WornAccessory = playerAccessories[3, 0];
                        }
                        else if (selectedoption == 4)
                        {
                            _player.WornAccessory = playerAccessories[4, 0];
                        }
                        else if (selectedoption == 5)
                        {
                            _player.WornAccessory = playerAccessories[5, 0];
                        }
                        else
                        {
                            menus.InvalidSelection();
                        }
                    }
                    Console.WriteLine($"Name: {_player.CharacterName} || Class: {_player.ClassName} || Weapon: {_player.WornWeapon} || Accessory: {_player.WornAccessory}");
                }
            }
        }
    }
}
