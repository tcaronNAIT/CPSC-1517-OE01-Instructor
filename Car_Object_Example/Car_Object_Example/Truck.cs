using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    internal class Truck : Vehicle
    {
        private int _wheels;

        public int Wheels
        { 
            get { return _wheels; } 
            private set { _wheels = value; } 
        }

        public Truck(string model, string make, Engine engine, Transmission transmission)
        {
            Wheels = 4;
            Model = model;
            Make = make;
            Engine = engine;
            Transmission = transmission;
        }
    }
}
