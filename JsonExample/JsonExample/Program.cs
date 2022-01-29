using JsonExample;
using System.Text.Json;

const string FILE_PATH = @"C:\ClassExamples\StudentList.txt";

List<Student> students = new List<Student>();
students = ReadJson();

/*Student studentBob = new Student("Bob", "Smith", "bob@test.ca", 1234567);

Console.WriteLine($"{studentBob.FirstName} {studentBob.LastName}");

Class class1 = new Class("Intro to App Dev", "Learning more app dev", "CPSC1517");

studentBob.AddClass(class1);

students.Add(studentBob);

Student studentFred = new Student("Fred", "Random", "fred@random.com", 234567);

studentFred.AddClass(class1);

Class class2 = new Class("Intro to Database", "Learn about database", "DMIT1508");

studentFred.AddClass(class2);

students.Add(studentFred);*/

Console.WriteLine(students[1].FirstName);

WriteJson(students);

static void WriteJson(List<Student> students)
{
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string studentJson = JsonSerializer.Serialize(students, options);

    File.WriteAllText(FILE_PATH, studentJson);
    Console.WriteLine("Students saved.");
}

static List<Student> ReadJson()
{
    //get the text from the file
    string studentJson = File.ReadAllText(FILE_PATH);
    //convert or deserialize the text back into students (into an instance of the class)
    //this is broken, try and fix if you can!
    List<Student> students = JsonSerializer.Deserialize<List<Student>>(studentJson);
    return students;
}


