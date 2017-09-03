using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class Sorting
    {
        public IEnumerable<int> BubbleSort(IEnumerable<int> array)
        {
            if (array == null)
                throw new ArgumentNullException();
            var tempArray = array.ToArray();

            for (int i = 0; i < tempArray.Length; i++)
            {
                for (int j = i + 1; j < tempArray.Length; j++)
                {
                    if (tempArray[j] < tempArray[i])
                    {
                        tempArray[i] += tempArray[j];
                        tempArray[j] = tempArray[i] - tempArray[j];
                        tempArray[i] -= tempArray[j];
                    }

                }
                yield return tempArray[i];
            }
        }
    }
}
