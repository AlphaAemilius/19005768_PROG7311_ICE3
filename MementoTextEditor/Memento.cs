using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTextEditor
{
    public class Memento //holds string object of what needs to be saved 
    {
        private string state;  // could be "private ObjectType state"

        public Memento(string state) // could take ObjectType
        {
            this.state = state;
        }

        public string getState()
        {
            return state;
        }
    }
}
