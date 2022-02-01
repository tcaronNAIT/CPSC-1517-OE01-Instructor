using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryParseExample
{
    public class Cat : Animal
    {
        private string _name = null!;

        public string Name
        {
            get { return _name; }
            set 
            {
                if (value.Trim().Length <= 0)
                {
                    throw new ArgumentNullException("A name must be provided.");
                }
                _name = value;
            }
        }
        public Cat(int legs, string name)
        {
            Legs = legs;
            Species = "Cat";
            IsDomesticated = true;
            Name = name;
        }

        public override string Sound()
        {
            return "Meow";
        }

        public static Cat Parse(string text)
        {
            string[] parts = text.Split(',');
            if (parts.Length != 2)
            {
                throw new System.FormatException("Input string is not in the correct CSV format for the Cat object.");
            }

            int legs = int.Parse(parts[0]);
            string name = parts[1];

            return new Cat(legs, name);
        }

        public static bool TryParse(string text, out Cat newCat)
        {
            //Set a false value to return if fails
            bool valid = false;

            //program a try/catch to try and Parse the text into a cat
            // If parse is successful then set the cat to newCat to out to the user
            // and if successful set the false value to true and return to the users

            //If parse is not successful then set the out variable to null and do change the false return
            try
            {
                newCat = Parse(text);
                valid = true;
            }
            catch
            {
                newCat = null;
            }
            return valid;
            


        }
    }
}
