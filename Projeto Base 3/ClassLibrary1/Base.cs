using Activity.ObjectModel;
using System;

namespace ProjetoBase
{
    public class Base : iBase
    {

        public string Title { get; set; }
        public string Comments { get; set; }
        public int Id { get; set; }
        public int Removed { get; set; }

        public void Print()
        {
            
        }

        public bool SetRemoved() {

            return false;
        } 
       
    }
}
