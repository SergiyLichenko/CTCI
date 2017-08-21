using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures;

namespace Tasks.StacksNQueues
{
    //#3 Stack of Plates
    public class SetOfStacks<T>
    {
        private int _stackSize;
        private int _topIndex;
        private List<MyArrayStack<T>> _stacks = new List<MyArrayStack<T>>();

        public int Count => _stacks.Where(x => x != null).Sum(x => x.Count);
        public SetOfStacks(int stackSize)
        {
            if (stackSize < 0)
                throw new ArgumentOutOfRangeException();
            _stackSize = stackSize;
        }

        public SetOfStacks(IEnumerable<T> collection, int stackSize) : this(stackSize)
        {
            if (collection == null)
                throw new ArgumentNullException();
            foreach (var item in collection)
                Push(item);
        }

        public void Push(T item)
        {
            if (_stacks.Count != _topIndex &&
                _stacks[_topIndex].Count == _stackSize)
            {
                _stacks.Add(new MyArrayStack<T>(_stackSize));
                _topIndex++;
            }
            if (_stacks.Count == _topIndex)
                _stacks.Add(new MyArrayStack<T>(_stackSize));

            _stacks.Last().Push(item);
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return _stacks[_topIndex].Peek();
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var data = _stacks[_topIndex].Pop();
            if (_stacks[_topIndex].Count == 0)
            {
                _stacks.RemoveAt(_topIndex);
                _topIndex = _topIndex == 0 ? 0 : _topIndex - 1;
            }
            return data;
        }

        public bool IsEmpty() => Count == 0;

        public T PopAt(int subStackIndex)
        {
            if (subStackIndex < 0 || subStackIndex >= _stacks.Count)
                throw new ArgumentOutOfRangeException();

            var data = _stacks[subStackIndex].Pop();

            for (int i = subStackIndex; i < _stacks.Count - 1; i++)
                RearrangeStacks(_stacks[i], _stacks[i + 1]);

            if (_stacks[_topIndex].Count == 0)
                _stacks.RemoveAt(_topIndex--);
            return data;
        }

        private void RearrangeStacks(MyArrayStack<T> first,
            MyArrayStack<T> second)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();

            MyArrayStack<T> temp = new MyArrayStack<T>(second.Capacity);

            while (second.Count != 1)
                temp.Push(second.Pop());

            first.Push(second.Pop());

            while (temp.Count != 0)
                second.Push(temp.Pop());
        }
    }
}