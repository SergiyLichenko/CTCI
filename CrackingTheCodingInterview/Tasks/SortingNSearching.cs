using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class SortingNSearching
    {
        public IEnumerable<int> SortedMerge(int[] firstArray,
            int[] secondArray, int startBufferIndex)
        {
            if (firstArray == null || secondArray == null) throw new ArgumentNullException();
            if (startBufferIndex < 0 || startBufferIndex > firstArray.Length) throw new ArgumentOutOfRangeException();
            if (firstArray.Length - startBufferIndex < secondArray.Length) throw new ArgumentException();
            if (startBufferIndex > 0 && !IsSorted(firstArray, 0, startBufferIndex - 1)) throw new ArgumentException();
            if (!IsSorted(secondArray, 0, secondArray.Length - 1)) throw new ArgumentException();

            var result = new int[firstArray.Length];
            var firstArrayIndex = startBufferIndex - 1;
            var secondArrayIndex = secondArray.Length - 1;
            var resultIndex = startBufferIndex + secondArray.Length - 1;

            while (firstArrayIndex >= 0 || secondArrayIndex >= 0)
            {
                if (firstArrayIndex >= 0 && secondArrayIndex >= 0)
                {
                    if (firstArray[firstArrayIndex] > secondArray[secondArrayIndex])
                    {
                        result[resultIndex] = firstArray[firstArrayIndex];
                        firstArrayIndex--;
                    }
                    else
                    {
                        result[resultIndex] = secondArray[secondArrayIndex];
                        secondArrayIndex--;
                    }

                }
                else if (firstArrayIndex >= 0)
                {
                    result[resultIndex] = firstArray[firstArrayIndex];
                    firstArrayIndex--;
                }
                else if (secondArrayIndex >= 0)
                {
                    result[resultIndex] = secondArray[secondArrayIndex];
                    secondArrayIndex--;
                }

                resultIndex--;
            }

            return result;
        }

        public string[] GroupAnagrams(string[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var arr = array.OrderBy(x => x.Length).ToArray();
            var isAdded = new bool[arr.Length];

            var result = new List<string>();
            for (int i = 0; i < arr.Length ; i++)
            {
                if (isAdded[i])
                    continue;
                result.Add(arr[i]);
                isAdded[i] = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (arr[i].Length != array[j].Length)
                        break;
                    if (IsAnagram(array[i], array[j]))
                    {
                        isAdded[j] = true;
                        result.Add(array[j]);
                    }
                }
            }
            return result.ToArray();
        }

        private bool IsAnagram(string first, string second)
        {
            if (first.Length != second.Length)
                return false;

            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (var item in first)
            {
                if (!map.ContainsKey(item))
                    map[item] = 0;
                map[item]++;
            }
            foreach (var item in second)
            {
                if (!map.ContainsKey(item))
                    return false;
                map[item]--;
            }

            return map.Sum(x => x.Value) == 0;
        }

        private static bool IsSorted(int[] arr, int fromIndex, int toIndex)
        {
            for (int i = fromIndex; i < toIndex; i++)
                if (arr[i + 1] < arr[i])
                    return false;
            return true;
        }
    }
}
