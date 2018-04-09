
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    public class Person
    {
        public DateTime BirthDate { get; set; }
        //public Person FatherName = new Person();
        public string Email { get; set; }

        public static Person GetPerson()
        {
            return new Person
            {
            };
        }
    }
}
