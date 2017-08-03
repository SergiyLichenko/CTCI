using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyArrayStack<T>
    {
        private T[] collection;
        private int _top;
        public int Count { get; private set; }
        public int Capacity => collection.Length;

        public MyArrayStack()
        {
            collection = new T[4];
        }

        public MyArrayStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            collection = new T[capacity];
        }

        public MyArrayStack(IEnumerable<T> collection)
        {
            this.collection = collection?.ToArray() ??
                throw new ArgumentNullException();
            Count = this.collection.Length;
            _top = Count;
        }

        public void Push(T item)
        {
            if (_top >= collection.Length)
            {
                var temp = new T[collection.Length * 2];
                Array.Copy(collection, temp, collection.Length);
                collection = temp;
            }
            collection[_top++] = item;
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return collection[_top - 1];
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            var element = collection[_top - 1];
            collection[_top - 1] = default(T);
            _top--;
            Count--;

            return element;
        }

        public bool IsEmpty () => Count == 0;
    }
}
