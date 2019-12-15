using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server2.Memento
{
    public class CareTaker
    {
        List<MementoPattern> statesList;

        public CareTaker()
        {
            statesList = new List<MementoPattern>();
        }
        public void add(MementoPattern state)
        {
            statesList.Add(state);
        }
        public MementoPattern get(int index)
        {
            MementoPattern restoreState = statesList[index];
            statesList.RemoveAt(index);
            return restoreState;
        }

        public int getListCount()
        {
            return statesList.Count;
        }
    }
}
