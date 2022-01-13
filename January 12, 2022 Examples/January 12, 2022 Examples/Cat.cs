using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace January_12__2022_Examples
{
    class Cat
    {
        private string _name = null!;
        private int _age;
        private string _colour = null!;

        public string Name
        {
            get { return _name; }
            set
            {
                if(value.Trim().Length > 0)
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Invalid name.");
                }
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if(value >= 0)
                {
                    _age = value;
                }
                else
                {
                    throw new Exception("Age must be 0 or more.");
                }
            }
        }

        public string Colour
        {
            get { return _colour; }
            set 
            {
                if (value.Trim().Length > 0)
                {
                    _colour = value;
                }
                else
                {
                    throw new Exception("Invalid colour.");
                }
            }
        }

        public Cat(string name, int age, string colour)
        {
            Name = name;
            Age = age;
            Colour = colour;
        }

        public Cat()
        {

        }
    }
}
