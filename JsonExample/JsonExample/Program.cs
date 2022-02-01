using JsonExample;
using System.Collections.Generic;
using System.Text.Json;

const string FILE_PATH = @"C:\ClassExamples\StudentList.txt";

List<Student> students = new List<Student>();
students = ReadJson();

Student studentBob = new Student("Bob", "Smith", "bob@test.ca", 1234567);

Console.WriteLine($"{studentBob.FirstName} {studentBob.LastName}");

Class class1 = new Class("Intro to App Dev", "Learning more app dev", "CPSC1517");

studentBob.AddClass(class1);

students.Add(studentBob);

Student studentFred = new Student("Fred", "Random", "fred@random.com", 234567);

studentFred.AddClass(class1);

Class class2 = new Class("Intro to Database", "Learn about database", "DMIT1508");

studentFred.AddClass(class2);

students.Add(studentFred);

Console.WriteLine(students[1].FirstName);

WriteJson(students);

static void WriteJson(List<Student> students)
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string studentJson = JsonSerializer.Serialize(students, options);
    try
    {
        File.WriteAllText(FILE_PATH, studentJson);
        Console.WriteLine("Students saved.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error is writing to file: \n{ex.Message}");
    }
}

static List<Student> ReadJson()
{
    List<Student> students = null!;
    //get the text from the file
    try
    {
        string jsonString = File.ReadAllText(FILE_PATH);
        //deserialize the objects 
        students = JsonSerializer.Deserialize<List<Student>>(jsonString);
    }
    catch (Exception ex)
    {
        students = new List<Student>();
        Console.WriteLine($"Error is reading file: \n{ex.Message}");
    }
    return students;
}


