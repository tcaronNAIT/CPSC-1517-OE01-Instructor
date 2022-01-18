using Car_Object_Example;
using System.Collections.Generic;

// Make a menu to create a car, update a car, delete a car, display a car's information, exit.

int menuOption;
List<Car> cars = new List<Car>();

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

    switch(menuOption)
    {
        case 1:
            Car myCar = CreateCar();
            break;
    }

} while(menuOption != 5);

Car CreateCar()
{
    string make, model, engine, transmission;
    Car myCar = null;
    bool isError = false;

    try
    {
        make = Helper.GetSafeString("Enter the make of the car >> ");
        model = Helper.GetSafeString("Enter the model of the car >> ");
    }
    catch (Exception ex)
    {

    }

    return myCar;
}