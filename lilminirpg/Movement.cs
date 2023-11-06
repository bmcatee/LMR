using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class Movement
    {
        public async static void PlayerPosition(int length)
        {
            int PlayerPos = 0;
            while (Console.ReadLine() != "Enter")
            {
                for (int i = 0; i < length; ++i)
                {
                    await PlayerMovement(1);
                    ++PlayerPos;
                    Console.WriteLine($"Player at position {PlayerPos}");
                }
            }
            QuestEngine.CreateStageArray();

        }

        public async static Task PlayerMovement(int delay)
        {
            await Task.Delay(delay * 1000);
        }

    }
}
