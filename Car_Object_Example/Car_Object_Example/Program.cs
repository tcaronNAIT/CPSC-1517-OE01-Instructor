using Car_Object_Example;
using System.Collections.Generic;

// Make a menu to create a car, update a car, delete a car, display a car's information, exit.
const string FILE_PATH = @"C:\ClassExamples\CarList.txt";

int menuOption, carOption;
List<Vehicle> cars = ReadList();

do
{
    Console.WriteLine("Select a Menu Item:");
    Console.WriteLine("\t1. Create Car");
    Console.WriteLine("\t2. Update Car");
    Console.WriteLine("\t3. Delete Car");
    Console.WriteLine("\t4. Display Car");
    Console.WriteLine("\t5. Exit");

    menuOption = Helper.GetSafeInt("Option >> ", 1, 5);

    switch (menuOption)
    {
        case 1:
            Vehicle myCar = CreateCar();
            if (myCar != null)
            {
                cars.Add(myCar);
                Console.WriteLine("Car Created");
            }
            else
            {
                Console.WriteLine("Car was not create, please try again.");
            }
            break;
        case 2:
            if (cars.Count > 0)
            {
                UpdateCar(cars);
            }
            else
            {
                Console.WriteLine("No cars to display.");
            }
            break;
        case 3:
            if (cars.Count > 0)
            {
                carOption = DisplayCarMenu(cars);
                cars.RemoveAt(carOption - 1);
            }
            else
            {
                Console.WriteLine("No cars to display.");
            }
            break;
        case 4:
            if (cars.Count > 0)
            {
                carOption = DisplayCarMenu(cars);
                Console.WriteLine(cars[carOption - 1].ToString());
            }
            else
            {
                Console.WriteLine("No cars to display.");
            }
            break;
        default:
            if (cars.Count > 0)
            {
                SaveList(cars);
                Console.WriteLine("All vehicles saved, goodbye");
            }
            break;
    }

} while (menuOption != 5);

static void SaveList(List<Vehicle> cars)
{
    try
    {
        //using statement method, no need to close StreamWriter, it is automatically closed for you.
        using (StreamWriter writer = new StreamWriter(FILE_PATH))
        {
            foreach (Vehicle car in cars)
            {
                writer.WriteLine(car.FileWrite());
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"File save failed for {FILE_PATH} \n\n {ex.Message}");
        Console.WriteLine();
    }

    //Without using, we must make sure we close the StreamWriter, or our file will never write (basically it does not save).
    /*if(File.Exists(FILE_PATH))
    {
        StreamWriter writer = new StreamWriter(FILE_PATH);
        try
        {

            foreach (Vehicle car in cars)
            {
                writer.WriteLine($"{car.Make}|{car.Model}|{car.Engine.Size}|{car.Engine.HorsePower}|{car.Engine.Cylinders}|{car.Transmission.Type}|{car.Transmission.Gears}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: File could not be written.");
        }
        finally
        {
            writer.Close();
        }
    }
    else
    {
        Console.WriteLine($"File save failed for {FILE_PATH} \n\n {ex.Message}");
    }*/
}

static List<Vehicle> ReadList()
{
    List<Vehicle> cars = new List<Vehicle>();
    string make, model;
    Engine engine;
    Transmission transmission;

    if (File.Exists(FILE_PATH))
    {
        StreamReader reader = new StreamReader(FILE_PATH);

        try
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] splitLine = line.Split(',');
                make = splitLine[0];
                model = splitLine[1];
                engine = new Engine(double.Parse(splitLine[2]), int.Parse(splitLine[3]), int.Parse(splitLine[4]));
                transmission = new Transmission((Transmission.TypeName)Enum.Parse(typeof(Transmission.TypeName), splitLine[5]), int.Parse(splitLine[6]));
                cars.Add(new Vehicle(make, model, engine, transmission));
                //cars.Add(new Vehicle(splitLine[0], splitLine[1], new Engine(double.Parse(splitLine[2]), int.Parse(splitLine[3]), int.Parse(splitLine[4])), new Transmission((Transmission.TypeName)Enum.Parse(typeof(Transmission.TypeName), splitLine[5]), int.Parse(splitLine[6])));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: File could not be read due to an exception: \n {ex.Message}");
        }
        finally
        {
            reader.Close();
        }
    }
    else
    {
        File.Create(FILE_PATH).Close();
        Console.WriteLine($"ERROR: File did not exist, file {FILE_PATH} was created.");
    }

    return cars;
}

static int DisplayCarMenu(List<Vehicle> cars)
{
    int carOption, option = 1;

    Console.WriteLine("Select a car:");
    foreach (Vehicle car in cars)
    {
        Console.WriteLine($"\t{option}. {car.Make} {car.Model}");
        option++;
    }
    carOption = Helper.GetSafeInt("Option >> ", 1, cars.Count);


    return carOption;
}

static Vehicle CreateCar()
{
    string make, model;
    Engine engine;
    Transmission transmission;
    Vehicle myCar = null!;

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

        myCar = new Vehicle(make, model, engine, transmission);
    }
    catch (ArgumentOutOfRangeException aor)
    {
        Console.WriteLine(aor.Message);
    }
    catch (ArgumentNullException ane)
    {
        Console.WriteLine(ane.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    return myCar;
}

static Transmission GetTransmission()
{
    Transmission transmission;
    int gears, type;

    type = GetTransmissionType();
    gears = Helper.GetSafeInt("Enter the number of gears >> ");
    transmission = new Transmission((Transmission.TypeName)type, gears);

    return transmission;
}

static int GetTransmissionType()
{
    bool isValid = false;
    int option;
    int number;

    do
    {
        number = 1;
        Console.WriteLine("Select a Transmission Type:");
        foreach (Transmission.TypeName typeString in Enum.GetValues(typeof(Transmission.TypeName)))
        {
            Console.WriteLine($"\t{number}. {typeString}");
            number++;
        }

        option = Helper.GetSafeInt("Option >> ");
        if (option <= 0 || option > Enum.GetValues(typeof(Transmission.TypeName)).Length)
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

static void UpdateCar(List<Vehicle> cars)
{
    string make, model;
    Engine engine;
    Transmission transmission;
    int carPart;
    int carOption = DisplayCarMenu(cars);
    carPart = SelectPart(cars[carOption - 1]);

    switch (carPart)
    {
        case 1:
            make = Helper.GetSafeString("Enter the make of the car >> ");
            cars[carOption - 1].Make = make;
            model = Helper.GetSafeString("Enter the model of the car >> ");
            cars[carOption - 1].Model = model;
            break;
        case 2:
            Console.WriteLine("Engine Specifications:");
            engine = GetEngine();
            cars[carOption - 1].Engine = engine;
            break;
        case 3:
            Console.WriteLine("Transmoission Specifications");
            transmission = GetTransmission();
            cars[carOption - 1].Transmission = transmission;
            break;
        default:
            Console.WriteLine("Incorrect selection.");
            break;
    }
}



static int SelectPart(Vehicle car)
{
    Console.WriteLine(car.ToString());
    Console.WriteLine("Select the part you want to update.");
    Console.WriteLine("1. Model and Make of Car");
    Console.WriteLine("2. Transmission");
    Console.WriteLine("3. Engine");
    return Helper.GetSafeInt("Enter the car part from the options which you want to update >> ", 1, 3);
}

static Engine GetEngine()
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

//Casting Example
/*
double number = 1.0;

int number1;

//Parse will not work
number1 = int.Parse(number);

//Cast the value
number1 = (int)number;
*/