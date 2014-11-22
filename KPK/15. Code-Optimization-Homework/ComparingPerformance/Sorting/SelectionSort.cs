using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class SelectionSort
    {
        public static T[] Sort<T>(T[] array) where T : IComparable
        {
            for (int j = 0; j < array.Length -1; j++)
            {
                /* find the min element in the unsorted a[j .. n-1] */
                int iMin = j;
                for (int i = j + 1; i < array.Length; i++)
                {
                    if (array[i].CompareTo(array[iMin]) < 0)
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    T oldValue = array[j];
                    array[j] = array[iMin];
                    array[iMin] = oldValue;
                }
            }

            return array;
        }
    }
}
