using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTextEditor
{
    public class Originator //our custom object type that needs snapshot made 
    {
        private String state;

        public void setState(String state)
        {
            this.state = state;
        }

        public String getState()
        {
            return state;
        }

        public Memento saveStateToMemento()
        {
            return new Memento(state); //potentially redeclare this object to pass to memento
        }

        public void getStateFromMemento(Memento olderMemento) // correct mememnto fed in here 
        {
            state = olderMemento.getState();
        }
    }
}
