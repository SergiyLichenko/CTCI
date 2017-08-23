using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign
{
    public class CircularArray<T> : IEnumerable<T>
    {
        public CircularArray(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _array = new T[capacity];
            Capacity = capacity;
        }
        public T this[int index]
        {
            get => _array[GetIndex(index)];
            set
            {
                Count++;
                _array[GetIndex(index)] = value;
            }
        }
        private T[] _array;
        private int _indexOffset;
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private int GetIndex(int index)
        {
            index = (index + _indexOffset) % Capacity;
            if (index >= 0)
                return index;

            return index + Capacity;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _array.Length; i++)
                yield return _array[GetIndex(i)];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Rotate(int shift)
        {
            if (shift == 0)
                throw new ArgumentOutOfRangeException();
            _indexOffset += shift;
        }

        public CircularArray<T> Clone()
        {
            var result = new CircularArray<T>(Capacity);
            for (int i = 0; i < Capacity; i++)
                result[i] = _array[i];
            result.Rotate(_indexOffset);

            return result;
        }

        public void CopyTo(Array array, int destinationStartIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (destinationStartIndex < 0 || destinationStartIndex >= array.Length)
                throw new ArgumentOutOfRangeException();
            if (array.Length - destinationStartIndex < Capacity)
                throw new ArgumentException();

            foreach (var item in this)
                array.SetValue(item, destinationStartIndex++);
        }

        public int GetLength() => Capacity;

        public object GetValue(int index)
         => this[index];

        public void SetValue(object value, int index)
        {
            if (!(value is T))
                throw new InvalidCastException();
            this[index] = (T)value;
        }
    }
}
