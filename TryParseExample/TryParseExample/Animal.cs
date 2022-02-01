using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseExample
{
    public class Animal
    {
        //fields
        private int _legs;
        private string _species = null!;

        //accessors
        public int Legs
        {
            get { return _legs; }
            set
            {
                if(value >= 0)
                {
                    _legs = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Animals cannot have negative legs.");
                }
            }
        }

        public string Species
        {
            get { return _species; }
            set
            {
                if(value.Length <= 0)
                {
                    throw new ArgumentNullException("Must provide a value for species.");
                }
                _species = value;
            }
        }

        public bool IsDomesticated { get; set; }

        //No need to include a constructor for the base class.

        //virtual methods can be changed by the derived classes (child classes)
        public virtual string Sound()
        {
            return "Blargh";
        }

        //Non virtual methods cannot be changed
        public void AnimalType()
        {
            Console.WriteLine($"This is a {Species}.");
        }
    }
}
