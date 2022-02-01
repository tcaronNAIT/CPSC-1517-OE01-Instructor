using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonExample
{
    public class Student
    {
        private string _firstName = null!;
        private string _lastName = null!;
        private string _email = null!;
        private int _studentID;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int StudentID
        {
            get { return _studentID; }
            set { _studentID = value; }
        }
        public List<Class> ClassList { get; set; } = null!;

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
