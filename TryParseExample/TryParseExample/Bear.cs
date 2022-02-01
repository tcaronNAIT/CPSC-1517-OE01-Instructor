using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseExample
{
    public class Bear : Animal
    {
        public Bear()
        {
            Legs = 2;
            Species = "Bears";
            IsDomesticated = false;
        }

        public override string Sound()
        {
            return "Roar";
        }
    }
}
