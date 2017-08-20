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
            for (int i = 0; i < sizeof(int) * 8 - 1; i++)
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

            throw new ArgumentException($"Number does not have " +
                                        $"previous with the same count of 1s");
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
            throw new ArgumentException($"Number does not have " +
                                        $"next with the same count of 1s");
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

        public int Convertion(uint a, uint b)
        {
            uint num = a ^ b;
            int count = 0;

            while (num != 0)
            {
                if ((num & 1) == 1)
                    count++;
                num = num >> 1;
            }

            return count;
        }

        public uint PairwiseSwap(uint a)
        {
            uint maskEven = 0xaaaaaaaa;
            uint maskOdd = 0x55555555;

            uint evenNumber = a & maskEven;
            uint oddNumber = a & maskOdd;

            return (evenNumber >> 1) | (oddNumber << 1);
        }

        public string DrawLine(byte[] screen, int width,
            int x1Index, int x2Index, int yIndex)
        {
            if (screen == null)
                throw new ArgumentNullException();
            if (width < 0 || width > screen.Length * 8)
                throw new ArgumentOutOfRangeException();
            if ((screen.Length * 8) % width != 0)
                throw new ArgumentException();
            if (x1Index >= x2Index || x1Index < 0 || x1Index >= width - 1 || x2Index < 1 || x2Index >= width)
                throw new ArgumentOutOfRangeException();
            if (yIndex < 0 || yIndex >= screen.Length * 8 / width)
                throw new ArgumentOutOfRangeException();


            var builder = new StringBuilder();
            var currentRow = screen.Skip(width / 8 * yIndex).Take(width / 8).ToArray();
            builder.Append(new string('\n', yIndex));
            builder.Append(new string(' ', x1Index));

            for (int i = x1Index; i <= x2Index; i++)
            {

                var currentByte = currentRow[i / 8];
                int mask = 1 << (7 - (i % 8));

                if ((currentByte & mask) != 0)
                    builder.Append("1");
                else
                    builder.Append("0");
            }


            builder.Append(new string(' ', width - 1 - x2Index));
            builder.Append(new string('\n', screen.Length * 8 / width - yIndex - 1));

            return builder.ToString();
        }
    }
}
