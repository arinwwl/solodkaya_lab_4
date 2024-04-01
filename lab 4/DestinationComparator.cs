using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class DestinationComparator: IComparer
    {
         public int Compare(object? x, object? y)
        {
            if (x is Train<int> && y is Train<int>)
            {
                var train1 = x as Train<int>;
                var train2 = y as Train<int>;
                if (train1?.Destination.CompareTo(train2?.Destination)>1) return 1;
                else if (train1?.Destination.CompareTo(train2?.Destination) < 1) return -1;
                return 0;
            }
            throw new Exception("Невозможно сравнить");
        }
    }
}
