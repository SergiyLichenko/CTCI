using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyLinkedListQueue<T>
    {
        private class MyLinkedListQueueNode<T>
        {
            public MyLinkedListQueueNode<T> Next { get; set; }
            public T Data { get; private set; }

            public MyLinkedListQueueNode(T data)
            {
                Data = data;
            }
        }

        private MyLinkedListQueueNode<T> _head;
        private MyLinkedListQueueNode<T> _tail;
        public int Count { get; private set; }
        public MyLinkedListQueue()
        {

        }

        public MyLinkedListQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            foreach (var item in collection)
                Enqueue(item);
        }

        public void Enqueue(T data)
        {
            var node = new MyLinkedListQueueNode<T>(data);
            if (_head == null)
                _tail = _head = node;
            else
            {
                _head.Next = node;
                _head = node;
            }
            Count++;
        }

        public T Peek()
        {
            if (_tail == null)
                throw new InvalidOperationException();
            return _tail.Data;
        }

        public T Dequeue()
        {
            if (_tail == null)
                throw new InvalidOperationException();

            var data = _tail.Data;
            _tail = _tail.Next;
            Count--;

            if (_tail == null)
                _head = null;

            return data;
        }

        public bool IsEmpty() => Count == 0;
    }
}
