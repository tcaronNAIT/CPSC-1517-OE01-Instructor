// See https://aka.ms/new-console-template for more information
using January_12__2022_Examples;

string Whatever = "      sadasdsa      ";

Console.WriteLine(Whatever);
Console.WriteLine(Whatever.Length);
Console.WriteLine(Whatever.Trim());
Console.WriteLine(Whatever.Trim().Length);
Console.WriteLine(Something());

Cat nullCat = new Cat();
Cat sillyCat = new Cat("Panda", 0, "Black and White");

Console.Write("Enter the cat's name: ");
nullCat.Name = Console.ReadLine();

Console.WriteLine(nullCat.Name);
Console.WriteLine(sillyCat.Name);

static string Something()
{
    return "A new string";
}
