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
            cars.Add(myCar);
            Console.WriteLine("Car Created");
            break;
    }

} while(menuOption != 5);

Car CreateCar()
{
    string make, model;
    Engine engine;
    Transmission transmission;
    Car myCar = null!;
    bool isError = false;

    try
    {
        make = Helper.GetSafeString("Enter the make of the car >> ");
        model = Helper.GetSafeString("Enter the model of the car >> ");
        Console.WriteLine();
        Console.WriteLine("Engine Specifications:");
        engine = GetEngine();
        Console.WriteLine();
        Console.WriteLine("Transmission Specifications:");
        transmission = GetTransmission();
        Console.WriteLine();

        myCar = new Car(make, model, engine, transmission);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    return myCar;
}

Transmission GetTransmission()
{
    Transmission transmission;
    int gears, type;

    type = GetTransmissionType();
    gears = Helper.GetSafeInt("Enter the number of gears >> ");
    transmission = new Transmission((Transmission.TypeName)type, gears);

    return transmission;
}

int GetTransmissionType()
{
    bool isValid = false;
    int option;
    int number;

    do
    {
        number = 1;
        Console.WriteLine("Select a Transmission Type:");
        foreach(Transmission.TypeName typeString in Enum.GetValues(typeof(Transmission.TypeName)))
        {
            Console.WriteLine($"\t{number}. {typeString}");
            number++;
        }

        option = Helper.GetSafeInt("Option >> ");
        if(option <= 0 || option > Enum.GetValues(typeof(Transmission.TypeName)).Length)
        {
            Console.WriteLine($"ERROR: Invalid option, please choose between 1 and {Enum.GetNames(typeof(Transmission.TypeName)).Length}.");
            Console.WriteLine();
        }
        else
        {
            isValid = true;
        }

    } while (!isValid);

    return option - 1;
}

Engine GetEngine()
{
    Engine engine;
    int cyclinders, horsepower;
    double size;

    cyclinders = Helper.GetSafeInt("Enter the number of cylinders >>");
    horsepower = Helper.GetSafeInt("Enter the car's horsepower >>");
    size = Helper.GetSafeDouble("Enter the size of the engine >> ");

    engine = new Engine(size, horsepower, cyclinders);

    return engine;
}

/*Console.WriteLine("Engine Test");
TestEngineClass();

static void TestEngineClass()
{
    try
    {
        Engine newEngine;

        //good engine
        newEngine = new Engine(1.0, 24, 0);
        Console.WriteLine("Engine with 0 cylinders works");
        newEngine = new Engine(1.0, 24, 6);
        Console.WriteLine("Engine with 6 cylinders works");

        //bad engines
        //Bad Size
        //newEngine = new Engine(0, 24, 6);
        //Negative Horsepower
        //newEngine = new Engine(1.0, -1, 6);
        //Bad Cylinders
        //newEngine = new Engine(1.0, 24, 7);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
*/

/*int[] intArray = new int[4];

intArray[0] = 1;
intArray[1] = 2;
intArray[2] = 45;
intArray[3] = 78;

foreach(int value in intArray)
{
    Console.WriteLine($"The value is {value}");
}*/