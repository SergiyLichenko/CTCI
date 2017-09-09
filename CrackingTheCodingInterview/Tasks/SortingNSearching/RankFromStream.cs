using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.SortingNSearching
{
    public class RankFromStream
    {
        private readonly SortedDictionary<int, int> _map = new SortedDictionary<int, int>();

        public void Add(int item)
        {
            if (!_map.ContainsKey(item))
                _map[item] = 0;
            _map[item]++;
        }

        public int GetRankOfNumber(int item)
        {
            if (!_map.ContainsKey(item))
                throw new ArgumentException();
            var sum = 0;

            foreach (var pair in _map)
            {
                if (pair.Key == item)
                {
                    sum += pair.Value - 1;
                    break;
                }
                sum += pair.Value;
            }

            return sum;
        }
    }
}
