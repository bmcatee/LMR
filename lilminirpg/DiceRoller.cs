using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class DiceRoller
    {
        public int RollDice(int min, int max)
        {        
            var random = new Random();
            int roll = random.Next(min, max);
            return roll;
        }
    }
}
