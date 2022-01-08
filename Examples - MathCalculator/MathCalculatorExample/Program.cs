using System;

namespace MathCalculatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            double number1, number2, result;
            char menuItem, symbol;
            DisplayHeader();

            //Prompt the user for two numbers
            number1 = GetSafeDouble("Enter the first number: ");

            number2 = GetSafeDouble("Enter the second number: ", true);

            //Display a menu
            do
            {
                DisplayMenu();
                do
                {

                    Console.Write("Option: ");

                    if (char.TryParse(Console.ReadLine(), out menuItem))
                    {
                        menuItem = char.ToUpper(menuItem);
                        if (menuItem != 'A' && menuItem != 'S' && menuItem != 'M' && menuItem != 'D' && menuItem != 'X')
                        {
                            Console.WriteLine("ERROR: Invalid option selected, please try again.");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Please only type one character.");
                        Console.WriteLine();
                    }

                } while (menuItem != 'A' && menuItem != 'S' && menuItem != 'M' && menuItem != 'D' && menuItem != 'X');

                if (menuItem != 'X')
                {
                    switch (menuItem)
                    {
                        case 'D':
                            result = number1 / number2;
                            symbol = '/';
                            break;
                        case 'S':
                            result = number1 - number2;
                            symbol = '-';
                            break;
                        case 'M':
                            result = number1 * number2;
                            symbol = '*';
                            break;
                        default:
                            result = number1 + number2;
                            symbol = '+';
                            break;

                    }

                    Console.WriteLine($"{number1} {symbol} {number2} = {result}");
                    Console.WriteLine();
                }

            } while (menuItem != 'X');
            Console.WriteLine("See ya later.");
            Console.ReadLine();




            // Display our results
        }
        /// <summary>
        /// Displays the menu items.
        /// </summary>
        private static void DisplayMenu()
        {
            Console.WriteLine("Select from the following options:");
            Console.WriteLine("\tA - Addition");
            Console.WriteLine("\tS - Subtraction");
            Console.WriteLine("\tM - Multiplication");
            Console.WriteLine("\tD - Division");
            Console.WriteLine("\tX - Exit");
        }

        /// <summary>
        /// Displays the header for the Math Calculator Program.
        /// </summary>
        private static void DisplayHeader()
        {
            //Title/Header Message
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "================================"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "Welcome to the Math Calculator!"));
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "================================"));
        }
        /// <summary>
        /// Prompts the user for a double input, displays error if not double. Will also display error if 0 is entered and notZero is true.
        /// </summary>
        /// <param name="prompt">The prompt displayed to the user.</param>
        /// <param name="notZero">true if double should not be 0.</param>
        /// <returns>A double from the users entry</returns>
        static double GetSafeDouble(string prompt, bool notZero = false)
        {
            double number;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    if (number == 0 && notZero)
                    {
                        Console.WriteLine("ERROR: Cannot enter 0 as you cannot divide by 0.");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: Not a number, please enter a number.");
                    Console.WriteLine();
                }
            } while (!isValid);
            return number;
        }
    }
}
