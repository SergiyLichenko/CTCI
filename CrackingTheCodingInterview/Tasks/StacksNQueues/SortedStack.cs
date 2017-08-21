using System;
using System.Collections.Generic;
using DataStructures;

namespace Tasks.StacksNQueues
{
    //#5 Sort Stack
    public class SortedStack<T> where T : IComparable
    {
        private MyLinkedListStack<T> _firstStack;
        private MyLinkedListStack<T> _secondStack;

        public int Count => _firstStack.Count + _secondStack.Count;
        public SortedStack()
        {
            _firstStack = new MyLinkedListStack<T>();
            _secondStack = new MyLinkedListStack<T>();
        }

        public SortedStack(IEnumerable<T> items) : this()
        {
            if (items == null)
                throw new ArgumentNullException();
            foreach (var item in items)
                Push(item);
        }

        public void Push(T item)
        {
            while (_firstStack.Count > 0 &&
                   IsLessThan(_firstStack.Peek(), item))
                _secondStack.Push(_firstStack.Pop());

            _firstStack.Push(item);

            while (_secondStack.Count > 0)
                _firstStack.Push(_secondStack.Pop());
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return _firstStack.Peek();
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return _firstStack.Pop();
        }

        public bool IsEmpty() => Count == 0;

        private bool IsGreaterThan<T>(T value, T other) where T : IComparable
            => value.CompareTo(other) > 0;

        private bool IsLessThan<T>(T value, T other) where T : IComparable
            => value.CompareTo(other) < 0;
    }
}