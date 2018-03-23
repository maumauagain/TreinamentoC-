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

        public static Project getProject()
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
