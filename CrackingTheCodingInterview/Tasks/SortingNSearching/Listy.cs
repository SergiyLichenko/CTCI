using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.SortingNSearching
{
    public class Listy
    {
        private const int DefaultSize = 4;
        private int[] _array;
        private int _count = 0;
        public Listy()
        {
            _array = new int[DefaultSize];
            InsertDefaultValues();
        }

        public int this[int index]
        {
            get => ElementAt(index);
            set => Add(index, value);
        }

        private void Add(int index, int element)
        {
            if (element < 0)
                throw new ArgumentException();
            if (index < 0 || index > _array.Length)
                throw new ArgumentOutOfRangeException();
            if (_count == _array.Length)
            {
                var newArray = new int[_array.Length * 2];
                Array.Copy(_array, newArray, _array.Length);
                _array = newArray;
                InsertDefaultValues();
            }
            _array[index] = element;
            _count++;
        }

        public int ElementAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException();

            if (index >= _array.Length)
                return -1;
            return _array[index];
        }

        private void InsertDefaultValues()
        {
            for (int i = _count; i < _array.Length; i++)
                _array[i] = Int32.MaxValue;
        }
    }
}
