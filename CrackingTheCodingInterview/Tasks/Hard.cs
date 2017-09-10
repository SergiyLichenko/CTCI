using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Hard
    {
        public int AddWithoutPlus(int a, int b)
        {
            if (b == 0)
                return a;

            int c = a & b;
            a = a ^ b;

            return AddWithoutPlus(a, c << 1);
        }
    }
}
