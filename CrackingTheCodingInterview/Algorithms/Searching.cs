using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Searching<T> where T : IComparable
    {
        public int BinarySearchIterative(IEnumerable<T> array, T item)
        {
            if (array == null)
                throw new ArgumentNullException();
            var tempArray = array.ToArray();

            int left = 0;
            int right = tempArray.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (tempArray[mid].CompareTo(item) == 0)
                    return mid;

                if (tempArray[mid].CompareTo(item) < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        public int BinarySearchRecursive(IEnumerable<T> array, T item)
        {
            if (array == null)
                throw new ArgumentNullException();
            var tempArray = array.ToArray();

            return BinarySearchRecursiveHelper(tempArray, item, 0, tempArray.Length - 1);
        }

        private int BinarySearchRecursiveHelper(T[] array, T item, int left, int right)
        {
            if (left > right)
                return -1;
            var mid = (left + right) / 2;

            int compared = array[mid].CompareTo(item);
            if (compared == 0)
                return mid;

            if (compared < 0)
            {
                var rightResult = BinarySearchRecursiveHelper(array, item, mid + 1, right);
                if (rightResult != -1)
                    return rightResult;
            }
            else
            {
                var leftResult = BinarySearchRecursiveHelper(array, item, left, mid - 1);
                if (leftResult != -1)
                    return leftResult;
            }

            return -1;
        }
    }
}
