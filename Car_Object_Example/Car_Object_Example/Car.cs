using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    internal class Car
    {
        private string _make = null!;
        private string _model = null!;
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }

        public string Make
        {
            get { return _make; }
            set
            {
                if(value.Trim().Length >= 2)
                {
                    _make = value.Trim();
                }
                else
                {
                    throw new Exception("Invalid car make.");
                }
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (value.Trim().Length >= 2)
                {
                    _model = value.Trim();
                }
                else
                {
                    throw new Exception("Invalid car model.");
                }
            }
        }

        public Car(string make, string model, Engine engine, Transmission transmission)
        {
            Make = make;
            Model = model;
            Engine = engine;
            Transmission = transmission;
        }

        public string Honk()
        {
            return "Beep";
        }

        public override string ToString()
        {
            //String.Format("{0} {1}\n{2}\n{3}", Make, Model, Engine, Transmission);
            return $"{Make} {Model}\n{Engine}\n{Transmission}";
        }
    }
}
