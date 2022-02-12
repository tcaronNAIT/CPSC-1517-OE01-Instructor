using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    public class Vehicle
    {
        //Private Fields are ALWAYS camelCASE and start with a _
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
                if(string.IsNullOrWhiteSpace(value))
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
                if (string.IsNullOrWhiteSpace(value))
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

        //Properties are ALWAYS PascalCase
        public double TowingCapacity
        {
            get { return Engine.Size * 100; }
        }

        public bool IsFord
        {
            get { return Make == "Ford"; }
        }

        //Parameters are always and I mean ALWAYS camelCase
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

        public string Honk()
        {
            return "Beep";
        }

        public string FileWrite()
        {
            return $"{Make},{Model},{Engine.Size},{Engine.HorsePower},{Engine.Cylinders},{Transmission.Type},{Transmission.Gears}";
        }
        public override string ToString()
        {
            //String.Format("{0} {1}\n{2}\n{3}", Make, Model, Engine, Transmission);
            return $"{Make},{Model},{Engine.Size},{Engine.HorsePower},{Engine.Cylinders},{Transmission.Type},{Transmission.Gears},{Wheels}";
        }

        public static Vehicle Parse(string text)
        {
            string[] values = text.Split(',');
            if(values.Length != 8)
            {
                throw new FormatException($"String was not in the expected format. Incorrect number of values provided. {text}");
            }
            return new Vehicle(values[0],
                                values[1],
                                new Engine(double.Parse(values[2]), 
                                            int.Parse(values[3]), 
                                            int.Parse(values[4])), 
                                new Transmission((Transmission.TypeName)Enum.Parse(typeof(Transmission.TypeName), values[5]),
                                                  int.Parse(values[6])),
                                int.Parse(values[7]));
        }

        public static bool TryParse(string text, out Vehicle result)
        {
            bool valid = false;
            result = null;
            try
            {
                result = Parse(text);
                valid = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"TryPase failed: {ex.Message}");
            }
            return valid;
        }
    }
}
