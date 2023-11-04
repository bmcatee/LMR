using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class EnemyLists
    {
        public Enemy _enemy = new Enemy();

        public static string[,] EnemiesList =
{
                    // Key: ID#, Name, Desc, HPMax, STR, Gold, XP, MonsterGroup
                    // MonsterGroup is used for populating stages
                    // Total Elements: 8
                    {"0", "Slime", "Classicly adorable ankle-melter.", "5", "1", "5", "10", "1"},
                    {"1", "Goblin Fighter", "Small, but not harmless.", "5", "1", "5", "10", "1"},
                    {"2", "Harpy", "Stays aloft and away from melee attacks.", "5", "1", "5", "10", "1"},
                    {"3", "Minotaur", "Big and brutally strong.", "5", "1", "5", "10", "1"},
                    {"4", "Evil Clown", ". . . ", "5", "1", "5", "10", "1"},
                    {"5", "Fish", "Just floppin' around.", "5", "1", "5", "10", "1"},
                    {"6", "Pink Slime", "Disorients their foes.", "5", "1", "5", "10", "1"},
                    {"7", "Goblin Spellcaster", "Loves it when things go boom.", "5", "1", "5", "10", "1"}
        };

    }
}
