using System;
using System.IO;

namespace ParallelArraysExample
{
    class Program
    {
        const string FILE_PATH = @"C:\ClassExamples\GradesRUs.txt";

        static void Main(string[] args)
        {
            const int SIZE = 10;
            string[] names = new string[SIZE];
            int[] grades = new int[SIZE];
            int listSize;
            int menuChoice;

            Console.WriteLine(" ***** Grades R Us ****** ");
            Console.WriteLine();

            listSize = ReadFile(names, grades);
            do
            {
                menuChoice = GetMenuChoice();

                switch (menuChoice)
                {
                    case 1:
                        if (listSize > (SIZE - 1))
                        {
                            Console.WriteLine("ERROR: List is full.");
                            Console.WriteLine();
                        }
                        else
                        {
                            listSize = AddRecord(names, grades, listSize);
                        }
                        break;
                    case 2:
                        DisplayRecords(names, grades, listSize);
                        break;
                    default:
                        WriteFile(names, grades, listSize);
                        Console.WriteLine("Thanks, have a nice day!");
                        Console.Write("Press any key to exit...");
                        Console.ReadLine();
                        break;
                }
            } while (menuChoice != 3);
        }

        private static void WriteFile(string[] names, int[] grades, int listSize)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FILE_PATH))
                {
                    for (int i = 0; i < listSize;i++)
                    {
                        writer.WriteLine($"{names[i]}|{grades[i]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File save failed for {FILE_PATH} \n\n {ex}");
                Console.WriteLine();
            }
        }

        private static void DisplayRecords(string[] names, int[] grades, int listSize)
        {
            Console.WriteLine(new string('*', 40));
            Console.WriteLine($"{"Student Names", -30}{"Grades", 10}");
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < listSize; i++)
            {
                Console.WriteLine($"{names[i], -30}{grades[i], 10}");
            }
            Console.WriteLine(new string('*', 40));
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        private static int AddRecord(string[] names, int[] grades, int listSize)
        {
            string studentName;
            int grade;

            do
            {
                Console.Write("Enter the student's name >> ");
                studentName = Console.ReadLine();
                if (studentName.Trim().Length < 1)
                {
                    Console.WriteLine("ERROR: Please enter a name.");
                    Console.WriteLine();
                }
            } while (studentName.Trim().Length < 1);

            grade = GetSafeInt("Enter the student's grade >> ");

            names[listSize] = studentName;
            grades[listSize] = grade;

            return ++listSize;
        }

        private static int GetMenuChoice()
        {
            int menuChoice;

            Console.WriteLine("\t 1. Enter a student and grade.");
            Console.WriteLine("\t 2. Display Grades");
            Console.WriteLine("\t 3. Exit");

            do
            {
                menuChoice = GetSafeInt("Selection [1-3] >>");
                if(menuChoice > 3 || menuChoice < 1)
                {
                    Console.WriteLine("ERROR: Please enter 1, 2, or 3.");
                    Console.WriteLine();
                }
            } while (menuChoice > 3 || menuChoice < 1);

            return menuChoice;
        }

        private static int ReadFile(string[] names, int[] grades, int listSize = 0)
        {
            if (File.Exists(FILE_PATH))
            {
                StreamReader reader = new StreamReader(FILE_PATH);

                try
                {
                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split('|');
                        names[listSize] = splitLine[0];
                        grades[listSize] = Convert.ToInt32(splitLine[1]);
                        listSize++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File read for {FILE_PATH} failed.\n\n {ex}");
                }
                finally
                {
                    reader.Close();
                }
            }
            else
            {
                Console.WriteLine($"File {FILE_PATH} does not exist.");
            }

            return listSize;
        }

        private static int GetSafeInt(string prompt)
        {
            int safeInt;
            bool isValid = false;
            do
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out safeInt))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("ERROR: Please enter a whole number.");
                    Console.WriteLine();
                }
            } while (!isValid);

            return safeInt;
        }
    }
}
