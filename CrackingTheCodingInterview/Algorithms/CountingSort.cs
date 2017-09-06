using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class CountingSort
    {
        public static IEnumerable<int> CountingSorting(this IEnumerable<int> array)
        {
            var tempArray = array.ToArray();

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
            }

            return result;
        }
    }
}
