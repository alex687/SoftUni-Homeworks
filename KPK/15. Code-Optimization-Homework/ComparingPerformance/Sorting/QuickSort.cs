using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class QuickSort
    {
        public static T[] Sort<T>(T[] array, int down, int up) where T : IComparable
        {
            int downLimit = down;
            int upperLimit = up;
            T pivot = array[(down + up) / 2];
            while (downLimit <= upperLimit)
            {
                while (array[downLimit].CompareTo(pivot) < 0)
                {
                    downLimit++;
                }

                while (array[upperLimit].CompareTo(pivot) > 0)
                {
                    upperLimit--;
                }

                if (downLimit <= upperLimit)
                {
                    T exchangeValue = array[downLimit];
                    array[downLimit] = array[upperLimit];
                    array[upperLimit] = exchangeValue;
                    downLimit++;
                    upperLimit--;
                }
            }

            if (down < upperLimit)
            {
                Sort(array, down, upperLimit);
            }

            if (downLimit < up)
            {
                Sort(array, downLimit, up);
            }

            return array;
        }

    }
}
