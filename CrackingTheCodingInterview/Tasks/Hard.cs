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
            if (cards == null)
                throw new ArgumentNullException();
            var current = cards.ToArray();

            int index = 0;
            var random = new Random();
            while (index < current.Length)
            {
                var randomPrevious = random.Next(0, index + 1);
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

        public IEnumerable<int> RandomSet(IEnumerable<int> list, int m)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (m < 0)
                throw new ArgumentOutOfRangeException();
            var current = list.ToArray();
            if (current.Length < m)
                throw new ArgumentException();

            var shuffled = Shuffle(current).ToArray();
            return shuffled.Take(m);
        }

        public int MissingNumber(int[] array, int n)
        {
            if (array == null) throw new ArgumentNullException();
            if (n < 0) throw new ArgumentOutOfRangeException();
            if (array.Length + 1 != n) throw new ArgumentException();

            return MissingNumberHelper(array, 0);
        }

        private int MissingNumberHelper(int[] array, 
            int currentIndex)
        {
            if (array.Length == 0)
                return 0;

            int countZeros = 0;
            int coundOnes = 0;

            foreach (var item in array)
            {
                if (FetchJthBit(item, currentIndex))
                    coundOnes++;
                else
                    countZeros++;
            }

            int currentBit = 0;
            if ( countZeros > coundOnes)
                currentBit |= (1 << currentIndex);

            currentBit |= MissingNumberHelper(array.
                Where(item => (currentBit > 0 && FetchJthBit(item, currentIndex)) || 
                    (currentBit == 0 && !FetchJthBit(item, currentIndex)))
                .ToArray(), currentIndex + 1);

            return currentBit;
        }

        private bool FetchJthBit(int number, int j)
            => (number & (1 << j)) >0;
    }
}
