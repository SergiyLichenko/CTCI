using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class BitManipulations
    {
        public int Insertion(int n, int m, int i, int j)
        {
            if (j <= i || i < 0 || j < 0 || i > 30 || j > 31)
                throw new ArgumentOutOfRangeException();

            int mask = (int)Math.Pow(2, j - i + 1) - 1;
            mask <<= i;
            mask = ~mask;

            int result = n & mask;
            result = result | (m << i);

            return result;
        }

        public string BinaryToString(double n)
        {
            if (n <= 0 || n >= 1)
                throw new ArgumentOutOfRangeException();
            StringBuilder builder = new StringBuilder();
            builder.Append("0.");

            int index = 0;
            while (n != 0)
            {
                if (index == sizeof(int) * 8)
                {
                    builder.Clear();
                    builder.Append("ERROR");
                    break;
                }

                index++;
                double number = Math.Pow(2, -index);
                if (number > n)
                    builder.Append('0');
                else
                {
                    builder.Append('1');
                    n -= number;
                }
            }


            return builder.ToString();
        }

        public int FlipBitToWin(int number)
        {
            int withFlip = 0;
            int noFlip = 0;
            int maxLegnth = 0;

            for (int i = 0; i < sizeof(int) * 8; i++)
            {
                if (((1 << i) & number) != 0)
                {
                    withFlip++;
                    noFlip++;
                }
                else
                {
                    maxLegnth = Math.Max(maxLegnth, withFlip);
                    maxLegnth = Math.Max(maxLegnth, noFlip);

                    withFlip = noFlip + 1;
                    noFlip = 0;
                }
            }
            maxLegnth = withFlip > maxLegnth ? withFlip : maxLegnth;
            maxLegnth = noFlip > maxLegnth ? noFlip : maxLegnth;

            return maxLegnth;
        }

        public int[] NextNumber(int n)
        {
            int next = GetNext(n);
            int previous = GetPrevious(n);

            return new[] { previous, next };
        }

        private int GetPrevious(int n)
        {
            for (int i = 0; i < sizeof(int) * 8-1; i++)
            {
                if (GetIthBit(n, i) == 0)
                {
                    if (GetIthBit(n, i + 1) == 0)
                        continue;
                    n = FlipBit(n, i);
                    n = FlipBit(n, i + 1);

                    return ShiftMaxLeft(n, i);
                }
            }

            throw new ArgumentException($"Number does not have" +
                                        $" previous with the same count of 1s");
        }

        private int GetNext(int n)
        {
            for (int i = 0; i < sizeof(int) * 8 - 1; i++)
            {
                if (GetIthBit(n, i) == 1)
                {
                    if (GetIthBit(n, i + 1) == 1)
                        continue;
                    n = FlipBit(n, i);
                    n = FlipBit(n, i + 1);

                    return ShiftMaxRight(n, i);
                }
            }
            throw new ArgumentException($"Number does not have" +
                                        $" next with the same count of 1s");
        }

        private int ShiftMaxLeft(int n, int leftIndex)
        {
            int countZeros = 0;
            while (leftIndex - countZeros - 1 >= 0 &&
                   GetIthBit(n, leftIndex - countZeros - 1) == 0)
                countZeros++;

            if (countZeros == 0)
                return n;

            for (int i = leftIndex - 1; i >= 0 && i - countZeros >= 0; i--)
                if (GetIthBit(n, i - countZeros) == 1)
                    n = n | (1 << i);
            for (int i = 0; i < countZeros; i++)
                n = n & (~(1 << i));

            return n;
        }

        private int ShiftMaxRight(int n, int leftIndex)
        {
            int countZeros = 0;
            while (GetIthBit(n, countZeros) == 0)
                countZeros++;
            if (countZeros == 0)
                return n;

            int i;
            for (i = 0; i < leftIndex - countZeros; i++)
                if (GetIthBit(n, i + countZeros) == 1)
                    n = n | (1 << i);
            for (; i < leftIndex; i++)
                n = n & (~(1 << i));

            return n;
        }


        private int GetIthBit(int n, int i)
            => (n & (1 << i)) == 0 ? 0 : 1;

        private int FlipBit(int n, int index)
        {
            if ((n & (1 << index)) != 0)
                n = n & (~(1 << index));
            else
                n = n | (1 << index);

            return n;
        }
    }
}
