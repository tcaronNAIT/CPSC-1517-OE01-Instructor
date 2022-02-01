using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JsonExample
{
    public class Class
    {
        private string _name = null!;
        private string _description = null!;
        private string _classID = null!;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description 
        {
            get { return _description; }
            set { _description = value; } 
        }
        public string ClassID
        {
            get { return _classID; }
            set { _classID = value; }
        }

        public Class(string name, string description,  string classID)
        {
            Name = name;
            Description = description;
            ClassID = classID;
        }
    }
}
