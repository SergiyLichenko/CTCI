using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyLinkedListStack<T>
    {
        private class MyLinkedListStackNode<T>
        {
            public T Data { get; private set; }
            public MyLinkedListStackNode<T> Next { get; set; }

            public MyLinkedListStackNode(T data)
            {
                Data = data;
            }
        }

        private MyLinkedListStackNode<T> _top;

        public int Count { get; private set; }

        public MyLinkedListStack()
        {

        }

        public MyLinkedListStack(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            foreach (var item in collection)
                Push(item);
        }

        public void Push(T item)
        {
            var node = new MyLinkedListStackNode<T>(item);
            node.Next = _top;
            _top = node;
            Count++;
        }

        public T Peek()
        {
            if (_top == null)
                throw new InvalidOperationException();

            return _top.Data;
        }

        public T Pop()
        {
            if (_top == null)
                throw new InvalidOperationException();

            var data = _top.Data;
            _top = _top.Next;
            Count--;
            return data;
        }

        public bool IsEmpty() => _top == null;
    }
}
