using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    public class Project
    {
        public String Code { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EstimatedEndDate { get; set; }

        public DateTime RealEndDate {get; set; }

        public Person Responsible = new Person();

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
