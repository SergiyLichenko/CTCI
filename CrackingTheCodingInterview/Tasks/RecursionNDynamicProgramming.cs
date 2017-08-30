using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class RecursionNDynamicProgramming
    {
        public long TripleStep(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            long a = 1;
            long b = 2;
            long c = 4;

            if (n == 1)
                return a;
            if (n == 2)
                return b;

            for (int i = 3; i < n; i++)
            {
                var tempC = c;
                c = c + b + a;
                var tempB = b;
                b = tempC;
                a = tempB;
            }
            return c;
        }

        public int MagicIndex(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                return -1;

            return MagicIndexHelper(array, 0, array.Length - 1);
        }

        private int MagicIndexHelper(int[] array, int left, int right)
        {
            int middle = (left + right) / 2;
            if (array[middle] == middle)
                return middle;
            if (right <= left)
                return -1;

            int result = 0;
            result = MagicIndexHelper(array, left, Math.Min(array[middle], middle - 1));
            if (result != -1)
                return result;
            result = MagicIndexHelper(array, Math.Max(middle + 1, array[middle]), right);

            return result;
        }

        public int RecursiveMutliply(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();
            if (a == 0 || b == 0)
                return 0;

            return RecursiveMutliplyHelper(a, b);
        }

        private int RecursiveMutliplyHelper(int a, int b)
        {
            int result = 0;
            if (b % 2 == 1)
            {
                result = a;
                b--;
            }
            if (b > 0 && b % 2 == 0)
                result += RecursiveMutliplyHelper(a << 1, b / 2);

            return result;
        }

        public List<int>[] TowersOfHanoi(List<int>[] towers)
        {
            if (towers == null) throw new ArgumentNullException();
            if (towers.Length != 3 || !IsSorted(towers[0])) throw new ArgumentException();
            if (towers[1].Count != 0 || towers[2].Count != 0) throw new InvalidOperationException();
            if (towers[0].Count == 0)
                return towers;

            var result = new List<int>[towers.Length];
            for (int i = 0; i < towers.Length; i++)
                result[i] = new List<int>(towers[i]);

            TowersOfHanoiHelper(result, 2, 0, towers[0].Count);
            return result;
        }

        private void TowersOfHanoiHelper(List<int>[] towers,
            int targetTowerIndex, int sourceIndex, int count)
        {
            int helperIndex = towers.Length - targetTowerIndex - sourceIndex;

            if (count > 1)
                TowersOfHanoiHelper(towers, helperIndex, sourceIndex, count - 1);

            if (towers[targetTowerIndex].Count > 0 &&
                towers[sourceIndex].Count > 0 &&
                towers[targetTowerIndex].Last() > towers[sourceIndex].Last())
                throw new InvalidOperationException();

            towers[targetTowerIndex].Add(towers[sourceIndex].Last());
            towers[sourceIndex].RemoveAt(towers[sourceIndex].Count - 1);

            if (count > 1)
                TowersOfHanoiHelper(towers, targetTowerIndex, helperIndex, count - 1);
        }

        private static bool IsSorted(List<int> arr)
        {
            int l = arr.Count;
            for (int i = 1; i < l / 2 + 1; i++)
                if (arr[i - 1] > arr[i] || arr[l - i] < arr[l - i - 1])
                    return false;
            return true;
        }

        public IEnumerable<string> Parens(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            return ParensHelper(n);
        }

        private IEnumerable<string> ParensHelper(int n)
        {
            if (n == 0)
                return new List<string> { "" };

            var parensList = ParensHelper(n - 1).ToList();
            var result = new HashSet<string>();

            foreach (var item in parensList)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    int leftCount = 0;
                    int rightCount = 0;
                    for (int j = i ; j < item.Length; j++)
                    {
                        if (item[j] == '(')
                            leftCount++;
                        else
                            rightCount++;
                        if (leftCount == rightCount)
                            result.Add(item.Insert(i, "(").Insert(j + 2, ")"));
                    }
                }
                result.Add(item + "()");
            }
            return result;
        }
    }
}
