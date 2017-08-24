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
            if(n<=0)
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
    }
}
