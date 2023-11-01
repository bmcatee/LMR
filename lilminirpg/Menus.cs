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
        ItemLists itemlists = new ItemLists();
        public int SelectedOption { get; set; }
        public string MenuInput { get; set; }
        public string MenuPrinter { get; set; }
        public char Cursor = ' ';
        
        public void MenuName()
        {

        }
        public void MenuClass()
        {
  
        }
        public void MenuWeapon()
        {

        }
        public void MenuAccessory()
        {

        }
        public void InvalidSelection()
        {
            Console.WriteLine("You have entered an invalid selection. Please try again.");
        }

        public void PrintMenu()
        {
            for (int i = 0; i < itemlists.PlayerClasses.GetLength(0); i++)
            {
                if (i == SelectedOption)
                {
                    Cursor = '*';
                }
                else
                {
                    Cursor = ' ';
                }
                Console.WriteLine($"[{Cursor}] {itemlists.PlayerClasses[i, 0]}: {itemlists.PlayerClasses[i, 1]}");
            }
        }

        public void SelectUp()
        {
            if (SelectedOption > 0)
            {
                Console.Clear();
                SelectedOption--;
            }
            else if (SelectedOption < 0)
            {
                Console.Clear();
                SelectedOption = itemlists.PlayerClasses.GetLength(0) - 1;
            }
        }
        
        public void SelectDown()
        {
            if (SelectedOption < itemlists.PlayerClasses.GetLength(0) - 1)
            {
                Console.Clear();
                SelectedOption++;
            }
            else if (SelectedOption > itemlists.PlayerClasses.GetLength(0) - 1)
            {
                Console.Clear();
                SelectedOption = 0;
            }
        }
        public int GetSelection()
        {
            return SelectedOption;
        }
    }
}

