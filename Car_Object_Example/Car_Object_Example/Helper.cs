using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    internal class Helper
    {
        public static int GetSafeInt(string prompt)
        {
            int safeInt;
            bool isValid = false;

            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out safeInt))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Must provide a whole number.");
                    Console.WriteLine();
                }
            } while (!isValid);

            return safeInt;
        }
    }
}
