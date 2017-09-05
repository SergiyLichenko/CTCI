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

        public IEnumerable<T> MergeSort(IEnumerable<T> array)
        {
            if (array == null)
                throw new ArgumentNullException();

            var list = new List<T>(array);
            var helper = new T[list.Count];
            MergeSortHelper(list, helper, 0, list.Count - 1);

            return list;
        }

        private void MergeSortHelper(List<T> list, T[] helper, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortHelper(list, helper, left, mid);
                MergeSortHelper(list, helper, mid + 1, right);
                Merge(list, helper, left, mid, right);
            }
        }

        private void Merge(List<T> list, T[] helper,
            int left, int mid, int right)
        {
            int leftIndex = left;
            int rightIndex = mid + 1;
            int index = left;
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex].CompareTo(list[rightIndex]) < 0)
                    helper[index++] = list[leftIndex++];
                else
                    helper[index++] = list[rightIndex++];
            }

            while (leftIndex <= mid)
                helper[index++] = list[leftIndex++];

            for (int i = left; i < index; i++)
                list[i] = helper[i];
        }

        public IEnumerable<T> QuickSort(IEnumerable<T> list)
        {
            if (list == null)
                throw new ArgumentNullException();
            var array = list.ToArray();

            if (array.Length > 0)
                QuickSortWithBoundaries(array, 0, array.Length - 1);
            return array;
        }

        private void QuickSortWithBoundaries(T[] array, int left, int right)
        {
            int pivotIndex = QuickSortHelper(array, left, right);

            if (left < pivotIndex - 1)
                QuickSortWithBoundaries(array, left, pivotIndex-1);
            if (pivotIndex < right)
                QuickSortWithBoundaries(array, pivotIndex , right);
        }

        private int QuickSortHelper(T[] array, int left, int right)
        {
            var pivotIndex = new Random().Next(left, right + 1);
            var pivot = array[pivotIndex];

            int leftIndex = left;
            int rightIndex = right;

            while (leftIndex <= rightIndex)
            {
                while (array[leftIndex].CompareTo(pivot) < 0)
                    leftIndex++;

                while (array[rightIndex].CompareTo(pivot) > 0)
                    rightIndex--;

                if (leftIndex <= rightIndex)
                {
                    Swap(array, leftIndex, rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }
            return leftIndex;
        }

        private static void Swap(T[] tempArray, int i, int j)
        {
            var temp = tempArray[i];
            tempArray[i] = tempArray[j];
            tempArray[j] = temp;
        }
    }
}
