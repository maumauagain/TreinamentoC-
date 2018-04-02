using ProjetoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    public class Tasks : Base
    {
        public Person Responsible = new Person();
        public decimal WorkHours { get; set; }
        public ETaskType TaskType { get; set; }
    }
}
