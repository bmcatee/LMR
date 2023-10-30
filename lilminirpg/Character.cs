using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class Character
    {
        public string CharacterName { get; set; }
        public int HealthPointsMax { get; set; }
        public int HealthPointsCurrent { get; set; }
        public int StatStrength { get; set; }
        public string WornWeapon { get; set; }

    }
}
