using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class Enemy : Character
    {
        public int MonsterAttackInterval { get; set; }
        public int MonsterPerk1 { get; set; }
        public int MonsterPerk2 { get; set; }
        public int MonsterPerk3 { get; set; }
        public int GoldDropped { get; set; }
        public int XPDropped { get; set; }
        public int MonsterGroup { get; set; }
        public int MonsterRank { get; set; }


    }
}
