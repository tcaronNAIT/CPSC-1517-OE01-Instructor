using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Object_Example
{
    internal class Helper
    {
        internal static int GetSafeInt(string prompt)
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

        internal static string GetSafeString(string prompt)
        {
            string safeString;

            do
            {
                Console.Write(prompt);
                safeString = Console.ReadLine().Trim();
                if (safeString.Length <= 0)
                {
                    Console.WriteLine("ERROR: Must provide a value.");
                    Console.WriteLine();
                }
            } while (string.IsNullOrWhiteSpace(safeString));

            return safeString;
        }

        internal static double GetSafeDouble(string prompt)
        {
            double safeDouble;
            bool isValid = false;

            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out safeDouble))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Must provide a number.");
                    Console.WriteLine();
                }
            } while (!isValid);

            return safeDouble;
        }
    }
}
