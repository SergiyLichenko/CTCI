using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class CountingSort
    {
        public static IEnumerable<int> CountingSorting(this IEnumerable<int> array, Action<int, int> act = null)
        {
            var tempArray = array.ToArray();
            if (tempArray.Any(x => x > 9))
                throw new ArgumentException();

            var buckets = new int[10];
            foreach (var item in tempArray)
                buckets[item]++;

            for (int i = 1; i < buckets.Length; i++)
                buckets[i] += buckets[i - 1];

            var result = new int[tempArray.Length];
            for (int i = tempArray.Length - 1; i >= 0; i--)
            {
                var resultIndex = buckets[tempArray[i]] - 1;
                buckets[tempArray[i]]--;
                result[resultIndex] = tempArray[i];

                act?.Invoke(i, resultIndex);
            }

            return result;
        }

        public static IEnumerable<int> RadixSort(this IEnumerable<int> list)
        {
            var array = list.ToArray();
            if (array.Length == 0)
                return array;

            var maxNumberLength = array.Select(x => x.ToString()).Max(x => x.Length);

            var tempArray = new int[array.Length];
            var tempValues = new int[array.Length];

            for (int i = 0; i < maxNumberLength; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    tempArray[j] = array[j];
                    if (i != 0)
                        tempArray[j] = tempArray[j] / ((int)Math.Pow(10, i));
                    tempArray[j] %= 10;
                }

                tempArray.CountingSorting((oldIndex, newIndex) =>
                        tempValues[newIndex] = array[oldIndex]);

                for (int j = 0; j < tempValues.Length; j++)
                    array[j] = tempValues[j];
            }


            return array;
        }
    }
}
