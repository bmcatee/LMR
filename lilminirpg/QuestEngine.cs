using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class QuestEngine
    {
        public static void FillArray()
        {
            int[] CurrentGameScreen = new int[10];
            for (int i = 0; i < CurrentGameScreen.Length; ++i) 
            { 
                CurrentGameScreen[i] = i; 
            }
        }
    }
}
