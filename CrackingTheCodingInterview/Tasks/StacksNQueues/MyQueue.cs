using System;
using System.Collections.Generic;
using DataStructures;

namespace Tasks.StacksNQueues
{
    //#4 Queue via Stacks 
    public class MyQueue<T>
    {
        private MyLinkedListStack<T> _firstStack;
        private MyLinkedListStack<T> _secondStack;

        public int Count => _firstStack.Count + _secondStack.Count;

        public MyQueue()
        {
            _firstStack = new MyLinkedListStack<T>();
            _secondStack = new MyLinkedListStack<T>();
        }

        public MyQueue(IEnumerable<T> collection) : this()
        {
            if (collection == null)
                throw new ArgumentNullException();
            foreach (var item in collection)
                Enqueue(item);
        }

        public void Enqueue(T item)
        {
            _firstStack.Push(item);
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (_secondStack.Count == 0)
                RearangeStacks();

            return _secondStack.Peek();
        }


        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            if (_secondStack.Count == 0)
                RearangeStacks();

            return _secondStack.Pop();
        }

        public bool IsEmpty() => Count == 0;

        private void RearangeStacks()
        {
            while (_firstStack.Count != 0)
                _secondStack.Push(_firstStack.Pop());
        }
    }
}