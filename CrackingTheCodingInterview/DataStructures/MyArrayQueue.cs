using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyArrayQueue<T>
    {
        private T[] _mass;
        private int _head;
        private int _tail;

        public int Count { get; private set; }
        public int Capacity => _mass.Length;

        public MyArrayQueue()
        {
            _mass = new T[4];
        }

        public MyArrayQueue(int capacity)
        {
            _mass = new T[capacity];
        }

        public MyArrayQueue(IEnumerable<T> collection)
        {
            if(collection == null)
                throw new ArgumentNullException();
            _mass = new T[collection.Count()];
            foreach (var item in collection)
                Enqueue(item);
        }

        public void Enqueue(T item)
        {
            if (Count == _mass.Length)
            {
                var temp = new T[_mass.Length * 2];
                int index = 0;
                if (_head > _tail)
                {

                    for (int i = _tail; i < _head; i++)
                        temp[index++] = _mass[i];
                }
                else
                {
                    for (int i = _tail; i < _mass.Length; i++)
                        temp[index++] = _mass[i];
                    for (int i = 0; i < _head; i++)
                        temp[index++] = _mass[i];
                }
                _tail = 0;
                _head = _mass.Length;
                _mass = temp;
            }

            _mass[_head] = item;
            _head = (_head + 1) % _mass.Length;
            Count++;
        }

        public T Dequeue()
        {
            if(Count == 0)
                throw new InvalidOperationException();

            var result = _mass[_tail];
            _mass[_tail] = default(T);
            _tail = (_tail + 1) % _mass.Length;
            Count--;
            return result;
        }

        public bool IsEmpty() => Count == 0;

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return  _mass[_tail];
        }
    }
}
