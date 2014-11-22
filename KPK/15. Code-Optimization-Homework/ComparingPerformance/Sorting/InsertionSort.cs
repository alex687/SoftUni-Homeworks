using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class InsertionSort
    {
        public static T[] Sort<T>(T[] array) where T : IComparable
        {
            for (int iteration = 1; iteration < 100; iteration++)
            {
                T correntNumber = array[iteration];
                int currentPosition = iteration - 1;
                while (currentPosition >= 0 && correntNumber.CompareTo(array[currentPosition]) < 0)
                {
                    T exchangeNumber = array[currentPosition + 1];
                    array[currentPosition + 1] = array[currentPosition];
                    array[currentPosition] = exchangeNumber;
                    currentPosition--;
                }
            }

            return array;
        }

    }
}
