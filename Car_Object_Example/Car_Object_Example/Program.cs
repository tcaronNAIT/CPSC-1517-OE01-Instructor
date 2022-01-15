using Car_Object_Example;
using System.Collections.Generic;

// Make a menu to create a car, update a car, delete a car, display a car's information, exit.

int menuOption;
List<Car> cars = new List<Car>();
string make, model, engine, transmission;

do
{
    Console.WriteLine("Select a Menu Item:");
    Console.WriteLine("\t1. Create Car");
    Console.WriteLine("\t2. Update Car");
    Console.WriteLine("\t3. Delete Car");
    Console.WriteLine("\t4. Display Car");
    Console.WriteLine("\t5. Exit");

    do
    {
        menuOption = Helper.GetSafeInt("Option >> ");
        if(menuOption > 5 || menuOption <= 0)
        {
            Console.WriteLine("ERROR: Invalid Option.");
            Console.WriteLine();
        }
    } while (menuOption > 5 || menuOption <= 0);


} while(menuOption != 5);