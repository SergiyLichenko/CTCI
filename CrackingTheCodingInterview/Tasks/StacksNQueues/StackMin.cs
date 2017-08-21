using System;
using System.Collections.Generic;

namespace Tasks.StacksNQueues
{
    //#2 Stack Min
    public class StackMin
    {
        private class MyLinkedListStackMinNode
        {
            public MyLinkedListStackMinNode Next { get; set; }
            public int Data { get; private set; }
            public int Min { get; private set; }
            public MyLinkedListStackMinNode(int data, int min)
            {
                Data = data;
                Min = min;
            }
        }

        private MyLinkedListStackMinNode _head;
        public int Count { get; private set; }
        private int _min = Int32.MaxValue;
        public StackMin()
        {

        }

        public StackMin(IEnumerable<int> data)
        {
            if (data == null)
                throw new ArgumentNullException();
            foreach (var item in data)
                Push(item);
        }

        public void Push(int item)
        {
            _min = Math.Min(item, _min);
            var node = new MyLinkedListStackMinNode(item, _min);

            node.Next = _head;
            _head = node;
            Count++;
        }

        public int Peek()
        {
            if (_head == null)
                throw new InvalidOperationException();
            return _head.Data;
        }

        public int Pop()
        {
            if (_head == null)
                throw new InvalidOperationException();

            var data = _head.Data;
            _head = _head.Next;
            Count--;

            return data;
        }

        public int Min()
        {
            if (_head == null)
                throw new InvalidOperationException();

            return _head.Min;
        }

        public bool IsEmpty() => Count == 0;
    }
}