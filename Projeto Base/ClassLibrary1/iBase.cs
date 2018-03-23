using System;
using System.Collections.Generic;
using System.Text;

namespace Activity.ObjectModel
{
    interface iBase
    {
        Int32 Id { get; set; }
        Boolean Removed { get; set; }

        void Print();

   
    }
}
