using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    public class Vehicle
    {
        private string _make = null!;
        private string _model = null!;
        //Ensure all wheels entries are positive numbers and less than or equal to 12
        //Wheels must also be entered as even number except allow for the number 3
        //If the vehicle has a Unicorn Transmission, only allow 4 wheels and if anything else is enter throw an error that starts with 'Unicorn Error - '
        private int _wheels;
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

        public int Wheels
        { 
            get { return _wheels; }
            set
            {
                if (value < 0 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("ERROR: Wheels must be positive and less than or equal to 12");
                }
                if (value % 2 != 0 && value != 3)
                {
                    throw new ArgumentOutOfRangeException("ERROR: Wheels must be even or 3");
                }
                _wheels = value;
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

        public double TowingCapacity
        {
            get { return Engine.Size * 100; }
        }

        public bool IsFord
        {
            get { return Make == "Ford"; }
        }

        public int Doors
        {
            get; private set;
        }

        public Vehicle(string make, string model, Engine engine, Transmission transmission, int wheels)
        {
            if(transmission.Type == Transmission.TypeName.Unicorn && wheels != 4)
            {
                throw new Exception("Unicorn Error - Unicorn Transmissions must have 4 wheels.");
            }
            Make = make;
            Model = model;
            Engine = engine;
            Transmission = transmission;
            Wheels = wheels;
        }

        public Vehicle()
        {
            Engine = new Engine();
            Transmission = new Transmission();
        }

        public void SetDoor(int Doors)
        {
            if(Doors >= 1)
            {
                this.Doors = Doors;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Doors", Doors, "A vehicle must have at least one door.");
            }
        }

        public string Honk()
        {
            return "Beep";
        }

        public void SetDoors(int doors)
        {
            if(doors == 0)
            {
                throw new ArgumentOutOfRangeException("doors", doors, "You need doors!");
            }
            else
            {
                Doors = doors;
            }
        }

        public string FileWrite()
        {
            return $"{Make},{Model},{Engine.Size},{Engine.HorsePower},{Engine.Cylinders},{Transmission.Type},{Transmission.Gears}";
        }
        public override string ToString()
        {
            //String.Format("{0} {1}\n{2}\n{3}", Make, Model, Engine, Transmission);
            return $"{Make} {Model}\n{Engine}\n{Transmission}";
        }
    }
}
