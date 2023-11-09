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
        public static int enemyCurrentHP = 0;

        public async static void PlayerPosition(int length)
        {
            Console.WriteLine($"length = {length} || _playerPos = {_playerPos}");

            for (int i = 0; i < length; ++i)
            {

                if (QuestEngine.EnemiesOnScreen[_playerPos + 1].CharacterName == "Empty Ground")
                {
                    Console.WriteLine($"Player at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {QuestEngine.EnemiesOnScreen[_playerPos + 1].CharacterName}");
                    await PlayerMovement(1);
                }
                else if (QuestEngine.EnemiesOnScreen[i].CharacterName != "Empty Ground")
                {
                    Console.WriteLine($"Player at position {_playerPos}, moving to {_playerPos + 1} || Next tile contains: {QuestEngine.EnemiesOnScreen[_playerPos + 1].CharacterName}");
                    Console.WriteLine($"Fight! The {QuestEngine.EnemiesOnScreen[_playerPos + 1].CharacterName} has {enemyCurrentHP} HP.");
             //       enemyCurrentHP = QuestEngine.EnemiesOnScreen[_playerPos].HealthPointsMax;
                    await PlayerAttack(1, enemyCurrentHP);
                }
            }
            QuestEngine.CreateStageArray();
        }

        public async static Task PlayerMovement(int delay)
        {
            await Task.Delay(delay * 1000);
            ++_playerPos;
        }

        public async static Task PlayerAttack(int delay, int enemyhp)
        {
            Console.WriteLine($"Current enemy HP: {enemyhp} - PlayerPos: {_playerPos}");

            if (enemyhp >= 1)
            {
                DiceRoller _diceRoller = new DiceRoller();
                enemyhp = enemyhp - (_diceRoller.RollDice(1, 5));
                Console.WriteLine($"You attack! The {QuestEngine.EnemiesOnScreen[_playerPos + 1].CharacterName} now has {enemyhp} HP.");
                await Task.Delay(delay * 1000);
               // PlayerAttack(1, enemyhp);
            }
            else if (enemyhp == 0) 
            {
                Console.WriteLine("You win!");
                await Task.Delay(delay * 1000);
              //  PlayerMovement(1);
            }
        }
    }
}
