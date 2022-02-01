using TryParseExample;

const string FILE_PATH = @"C:\ClassExamples\CatsList.txt";

Cat myCat = new Cat(3, "Bob");

Bear myBear = new Bear();

Unicorn myUnicorn = new Unicorn();

Console.WriteLine($"A cat says {myCat.Sound()}");
Console.WriteLine($"A bear says {myBear.Sound()}");
Console.WriteLine($"An unicorn says {myUnicorn.Sound()}");

//If done as if statement (much more code to write)
if (myUnicorn.IsDomesticated)
{
    Console.WriteLine("A unicorn is domesticated");
}
else
{
    if (myUnicorn.Legs == 4)
    {
        Console.WriteLine("A unicorn is not demesticated and has 4 legs");
    }
    else
    {
        Console.WriteLine("A unicorn is not domesticated and has unknown leg count.");
    }
}
//Conditional Operator Example
Console.WriteLine(String.Format("A unicorn is {0}", myUnicorn.IsDomesticated ? "domesticated" : myUnicorn.Legs == 4 ? "not domesticated and has 4 legs" : "not domesticated and has unknown leg count"));

Cat newCat = null;

if (Cat.TryParse("4,Muffins", out newCat))
{
    Console.WriteLine(newCat.Sound());
    Console.WriteLine(newCat.Name);
}
else
{
    Console.WriteLine("Cat creation failed.");
}

