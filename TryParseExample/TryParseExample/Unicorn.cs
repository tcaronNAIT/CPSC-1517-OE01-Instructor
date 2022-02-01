using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseExample
{
    public class Unicorn : Animal
    {
        public bool IsReal = false;
        public Unicorn()
        {
            Legs = 4;
            Species = "Unicorn";
            IsDomesticated = false;
        }
    }
}
