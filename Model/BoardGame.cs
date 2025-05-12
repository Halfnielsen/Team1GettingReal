using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model
{
    public class BoardGame : Item
    {
        public string Edition { get; set; }
        public int MinPlayers { get; set; }
        public int MaxPlayers { get; set; }

    }
}
