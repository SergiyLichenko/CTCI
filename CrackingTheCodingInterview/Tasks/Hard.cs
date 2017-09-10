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

        public int SubstractWithoutMinus(int a, int b)
        {
            while (b != 0)
            {
                a = a ^ b;
                b = (a & b) << 1;
            }
            return a;
        }

        public IEnumerable<int> Shuffle(IEnumerable<int> cards)
        {
            if(cards == null)
                throw new ArgumentNullException();
            var current = cards.ToArray();

            int index = 0;
            var random = new Random();
            while (index < current.Length)
            {
                var randomPrevious = random.Next(0, index+1);
                Swap(current, randomPrevious, index);
                index++;
            }
            return current;
        }

        private void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
