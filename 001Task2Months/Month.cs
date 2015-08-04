using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001Task2Months
{
    class Month
    {
        public int Index { get; private set; }
        public int NumberOfDays { get; private set; }

        public Month(int index, int numberOfDays)
        {
            Index = index;
            NumberOfDays = numberOfDays;
        }

        public override string ToString()
        {
            return Index + " - " + NumberOfDays;
        }
    }
}
