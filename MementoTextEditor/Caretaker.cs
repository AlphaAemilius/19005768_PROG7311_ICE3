using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoTextEditor
{
    public class Caretaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void add(Memento newState)
        {
            mementoList.Add(newState);
        }

        public Memento get(int index)
        {
            return mementoList.ElementAt(index);
        }

        public int getMementoListLength()
        {
            return mementoList.Count();
        }

        public void removeRestoredState()
        {
            if (mementoList.Count() > 0)
            {
                mementoList.RemoveAt(mementoList.Count - 1);  //removes recently restored state
            }
        }
    }
}
