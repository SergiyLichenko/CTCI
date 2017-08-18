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
                if (index == sizeof(int)*8)
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

            for (int i = 0; i < sizeof(int)*8; i++)
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
    }
}
