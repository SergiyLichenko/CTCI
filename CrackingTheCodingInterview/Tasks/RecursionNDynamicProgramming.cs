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
    }
}
