using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingReal.Model
{
    public class Book : Item
    {
        public string Author { get; set; }
        public string Edition { get; set; }
        public string System { get; set; }
    }
}
