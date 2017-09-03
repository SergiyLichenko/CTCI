using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sorting<T> where T : IComparable
    {
        public IEnumerable<T> BubbleSort(IEnumerable<T> array)
        {
            if (array == null)
                throw new ArgumentNullException();
            var tempArray = array.ToArray();

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = i + 1; j < tempArray.Length; j++)
                    if (tempArray[j].CompareTo(tempArray[i]) < 0)
                        Swap(tempArray, i, j);
                yield return tempArray[i];
            }
        }

        public IEnumerable<T> SelectionSort(IEnumerable<T> array)
        {
            if (array == null)
                throw new ArgumentNullException();
            var tempArray = array.ToArray();
            for (int i = 0; i < tempArray.Length; i++)
            {
                int minIndex = i;
                T minItem = tempArray[i];
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    if (tempArray[j].CompareTo(minItem) < 0)
                    {
                        minItem = tempArray[j];
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                    Swap(tempArray, i, minIndex);
                yield return tempArray[i];
            }
        }

        private static void Swap(T[] tempArray, int i, int j)
        {
            var temp = tempArray[i];
            tempArray[i] = tempArray[j];
            tempArray[j] = temp;
        }
    }
}
