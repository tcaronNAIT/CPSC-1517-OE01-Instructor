using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExample
{
    public class Student
    {
        private string _firstName = null!;
        private string _lastName = null!;
        private string _email = null!;
        private int _studentID;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int StudentID { get; set; }

        public List<Class> ClassList { get; set; } = new();

        public Student(string firstName, string lastName, string email, int studentID)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            StudentID = studentID;
        }

        public void AddClass(Class newClass)
        {
            var test = ClassList.FirstOrDefault(i => i.ClassID == newClass.ClassID);
            if(test != null)
            {
                throw new Exception("Class already exists for student, cannot add again.");
            }
            else
            {
                ClassList.Add(newClass);
            }
        }

    }
}
