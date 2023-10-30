using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lilminirpg
{
    internal class Player : Character
    {
        public string ClassName { get; set; }
        public int XPCurrent { get; set; }
        public int XPToLevel { get; set; }
        public string WornClothing { get; set; }
        public string WornAccessory { get; set; }
    }
}
