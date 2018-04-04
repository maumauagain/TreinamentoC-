using ProjetoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    public class Project : Base
    {
        public String Code { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public DateTime RealEndDate {get; set; }

        public Person Responsible = new Person();

        public Dictionary<Person, List<Tasks>> Tasks = new Dictionary<Person, List<Tasks>>();

        public List<Person> members = new List<Person>();

        public static Project GetProject()
        {
            return new Project
            {
            };
        }

        public bool MarkFinished() {
            return false;
        }
    }
}
