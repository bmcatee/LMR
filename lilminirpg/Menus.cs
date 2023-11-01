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
        public int selectedoption { get; set; }
        public string menuinput { get; set; }
        public char cursor = ' ';
        
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
    }
}

