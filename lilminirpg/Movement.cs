using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lilminirpg
{

    internal class Movement
    {
        private static int _playerPos = 0;

        public async static void PlayerPosition(int length)
        {
            Console.WriteLine($"length = {length} || _playerPos = {_playerPos}");

            for (int i = 0; i < length; ++i)
            {
                Console.WriteLine($"Player at position {_playerPos}, moving to {_playerPos+1} || Enemy on Current Tile: {QuestEngine.EnemiesOnScreen[_playerPos].CharacterName}");
                await PlayerMovement(1);
            }
            QuestEngine.CreateStageArray();

        }

        public async static Task PlayerMovement(int delay)
        {
            await Task.Delay(delay * 1000);
            ++_playerPos;
        }

    }
}
