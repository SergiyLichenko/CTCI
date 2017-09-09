using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.SortingNSearching
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

        private static bool IsSorted(int[] arr, int fromIndex, int toIndex)
        {
            for (int i = fromIndex; i < toIndex; i++)
                if (arr[i + 1] < arr[i])
                    return false;
            return true;
        }

        public string[] GroupAnagrams(string[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            var arr = array.OrderBy(x => x.Length).ToArray();
            var isAdded = new bool[arr.Length];

            var result = new List<string>();
            for (int i = 0; i < arr.Length; i++)
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

        public int SearchInRotatedArray(int[] array, int target)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();
            var maxElementIndex = FindMaxElementIndex(array, 0, array.Length - 1);
            var offset = array.Length - maxElementIndex - 1;
            var left = (maxElementIndex + 1) % array.Length;

            var fakeIndex = FindIndex(array, target, offset, left, maxElementIndex);

            if (fakeIndex == -1)
                return fakeIndex;
            return (fakeIndex + maxElementIndex + 1) % array.Length;
        }

        private int FindIndex(int[] array, int target, int offset,
            int left, int right)
        {
            var trueLeft = (left + offset) % array.Length;
            var trueRight = (right + offset) % array.Length;
            var trueMiddle = (trueLeft + trueRight) / 2;
            var currentMiddle = trueMiddle - offset;
            if (currentMiddle < 0)
                currentMiddle += array.Length;

            if (array[currentMiddle] == target)
                return trueMiddle;
            if (left == right)
                return -1;

            if (array[currentMiddle] < target)
                return FindIndex(array, target, offset, currentMiddle + 1, right);

            return FindIndex(array, target, offset, left, currentMiddle - 1);
        }

        private int FindMaxElementIndex(int[] array, int left, int right)
        {
            if (right - left <= 1)
                return array[left] > array[right] ? left : right;

            var middle = (left + right) / 2;

            if (array[left] < array[middle])
                return FindMaxElementIndex(array, middle, right);
            return FindMaxElementIndex(array, left, middle);
        }

        public int SortedSearchNoSize(Listy listy, int target)
        {
            if (listy == null)
                throw new ArgumentNullException();
            if (target < 0)
                throw new ArgumentOutOfRangeException();
            var listySize = 4;
            while (listy.ElementAt(listySize) != -1)
                listySize *= 2;

            return SortedSearchNoSizeHelper(listy, target, 0, listySize);
        }

        private int SortedSearchNoSizeHelper(Listy listy, int target,
            int left, int right)
        {
            int middle = (left + right) / 2;

            if (listy.ElementAt(middle) == target)
                return middle;
            if (left == right)
                return -1;

            if (listy.ElementAt(middle) < target)
                return SortedSearchNoSizeHelper(listy, target, middle + 1, right);
            return SortedSearchNoSizeHelper(listy, target, left, middle - 1);
        }

        public int SparseSearch(string[] words, string target)
        {
            if (words == null || target == null) throw new ArgumentNullException();
            if (words.Length == 0 || target.Length == 0) throw new ArgumentException();

            int left = 0;
            int right = words.Length - 1;

            while (left <= right)
            {
                var middle = (left + right) / 2;
                var firstMiddleWord = middle;
                while (firstMiddleWord >= 0 && words[firstMiddleWord] == string.Empty)
                    firstMiddleWord--;

                if (firstMiddleWord >= 0 && words[firstMiddleWord] == target)
                    return firstMiddleWord;

                if (firstMiddleWord < 0 || String.Compare(words[firstMiddleWord], target, StringComparison.Ordinal) < 0)
                    left = middle + 1;
                else
                    right = firstMiddleWord - 1;
            }

            return -1;
        }

        public int MissingInt(uint[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            int thousand = 1000;
            int million = thousand * thousand;

            var millionNumbers = new int[thousand];

            for (int i = 0; i < array.Length; i++)
            {
                int millionNumber = (int)array[i] / million;
                millionNumbers[millionNumber]++;
            }

            var currentMillion = new bool[million];
            for (int i = 0; i < millionNumbers.Length; i++)
            {
                if (millionNumbers[i] < million)
                {
                    for (int j = 0; j < array.Length; j++)
                    {
                        int millionNumber = (int)array[i] / million;
                        if (millionNumber == i)
                        {
                            var mod = (int)array[i] % million;
                            currentMillion[mod] = true;
                        }
                    }
                    var first = Array.FindIndex(currentMillion, x => x == false);
                    return i * million + first;
                }
            }

            return -1;
        }
    }
}
