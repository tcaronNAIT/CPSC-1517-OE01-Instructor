using System;

namespace Objects_July14_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;

            number = 1;

            Random keyGen = new Random();

            Dog doggie = new Dog("Bowser", 1, "green");

            Dog fido = new Dog("Fido", 8, "white");

            Dog defaultDog = new Dog();

            Console.WriteLine($"{doggie.GetName()} is {doggie.GetAge()} year(s) old and is the colour(s) {doggie.GetColour()}.");

            doggie.SetAge(5);
            doggie.SetName("Cookie");
            doggie.SetColour("black, white, and brown");
            Console.WriteLine();
            Console.WriteLine($"{doggie.GetName()} is {doggie.GetAge()} year(s) old and is the colour(s) {doggie.GetColour()}.");
            Console.WriteLine();
            Console.WriteLine($"The default dog is named {defaultDog.GetName()} is {defaultDog.GetAge()} year(s) old and is the colour(s) {defaultDog.GetColour()}.");

            //Console.WriteLine(doggie.Colour);

        }
    }
}
