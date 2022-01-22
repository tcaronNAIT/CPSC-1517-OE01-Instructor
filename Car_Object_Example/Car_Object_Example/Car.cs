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
                if(value.Trim().Length <= 0)
                {
                    throw new ArgumentNullException("Make", "Make is not specified or is empty.");
                }
                if (value.Trim().Length < 2 && value.Trim().Length > 0)
                {
                    throw new ArgumentOutOfRangeException("Make", value, "Make cannot be less than 2 characters long.");
                }
                _make = value.Trim();
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                if (value.Trim().Length <= 0)
                {
                    throw new ArgumentNullException("Model", "Model is not specified or is empty.");
                }
                if (value.Trim().Length < 2 && value.Trim().Length > 0)
                {
                    throw new ArgumentOutOfRangeException("Model", value, "Model cannot be less than 2 characters long.");
                }
                _model = value.Trim();
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
