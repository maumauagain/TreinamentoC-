
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    public class Person : ProjetoBase.Base
    {
        public DateTime BirthDate { get; set; }
        //public Person FatherName = new Person();
        public string Email { get; set; }

        public static Person getPerson()
        {
            return new Person
            {
            };
        }
    }
}
