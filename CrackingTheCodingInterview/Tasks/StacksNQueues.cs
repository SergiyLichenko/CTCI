using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DataStructures;

namespace Tasks
{
    //#1 Three In One
    public class ThreeInOneStack<T>
    {
        private const int _defaultSize = 12;
        private const int _stackCount = 3;
        private int[] _counts = new int[_stackCount];
        private int[] _capacities = new int[_stackCount];
        private int[] _tops = new int[_stackCount];
        private int[] _rangePoints = new int[_stackCount];

        private T[] _data;

        public int CountTotal => _counts.Sum();
        public int Count1 => _counts[0];
        public int Count2 => _counts[1];
        public int Count3 => _counts[2];

        public int CapacityTotal => _capacities.Sum();
        public int Capacity1 => _capacities[0];
        public int Capacity2 => _capacities[1];
        public int Capacity3 => _capacities[2];

        public ThreeInOneStack()
        {
            _data = new T[_defaultSize];
            RearangeStacks();
        }

        private void RearangeStacks()
        {
            _rangePoints[0] = 0;
            _rangePoints[1] = _data.Length / _stackCount;
            _rangePoints[2] = _rangePoints[1] +
                (_data.Length - _rangePoints[1]) / (_stackCount - 1);

            _tops[0] = 0;
            _tops[1] = _rangePoints[1];
            _tops[2] = _rangePoints[2];

            _capacities[0] = _rangePoints[1];
            _capacities[1] = _rangePoints[2] - _rangePoints[1];
            _capacities[2] = _data.Length - _capacities[0] - _capacities[1];
        }

        public void Push(T data, int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > _stackCount - 1)
                throw new ArgumentOutOfRangeException();

            if (CountTotal == _data.Length)
                ExpandSpace();
            AddOne(data, stackIndex, stackIndex, false);
        }

        public T Peek(int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > _stackCount - 1)
                throw new ArgumentOutOfRangeException();
            if (_counts[stackIndex] == 0)
                throw new InvalidOperationException();
            return _data[_tops[stackIndex] - 1];
        }

        public T Pop(int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > _stackCount - 1)
                throw new ArgumentOutOfRangeException();
            if (_counts[stackIndex] == 0)
                throw new InvalidOperationException();

            var newIndex = (_tops[stackIndex] - 1) % _data.Length;
            if (newIndex < 0)
                newIndex += _data.Length;
            var data = _data[newIndex];
            _data[newIndex] = default(T);
            _tops[stackIndex] = newIndex;
            _counts[stackIndex]--;

            return data;
        }

        public bool IsEmpty(int stackIndex)
        {
            if (stackIndex < 0 || stackIndex > _stackCount - 1)
                throw new ArgumentOutOfRangeException();

            return _counts[stackIndex] == 0;
        }

        private void ExpandSpace()
        {
            var data = _data;
            var rangePoints = new List<int>(_rangePoints);
            var tops = new List<int>(_tops);
            var counts = _counts;
            _counts = new int[_stackCount];
            _data = new T[data.Length * 2];

            RearangeStacks();

            for (int i = 0; i < _stackCount; i++)
            {
                if (counts[i] == 0)
                    continue;
                if (rangePoints[i] < tops[i])
                    for (int j = rangePoints[i]; j < tops[i]; j++)
                        AddOne(data[j], i, i, false);
                else
                {
                    for (int j = rangePoints[i]; j < data.Length; j++)
                        AddOne(data[j], i, i, false);
                    for (int j = 0; j < tops[i]; j++)
                        AddOne(data[j], i, i, false);
                }
            }
        }

        private bool AddOne(T data, int stackIndex,
            int initialStackIndex,
            bool isShiftRight)
        {
            if (isShiftRight && stackIndex == initialStackIndex)
                return false;

            if (_capacities[stackIndex] - _counts[stackIndex] == 0)
            {
                var nextStackIndex = (stackIndex + 1) % _stackCount;
                var result = AddOne(data, nextStackIndex, stackIndex, true);
                if (!result)
                    return false;
                _capacities[stackIndex]++;
            }

            if (isShiftRight)
            {
                for (int i = 0; i < _counts[stackIndex]; i++)
                {
                    _data[_tops[stackIndex] - i] =
                        _data[_tops[stackIndex] - i - 1];
                }
                _data[_tops[stackIndex] - _counts[stackIndex]] = default(T);
                _tops[stackIndex] = (_tops[stackIndex] + 1) % _data.Length;
                _rangePoints[stackIndex] = (_rangePoints[stackIndex] + 1) % _data.Length;
                _capacities[stackIndex]--;
                return true;
            }

            _data[_tops[stackIndex]] = data;
            _tops[stackIndex] = (_tops[stackIndex] + 1) % _data.Length;
            _counts[stackIndex]++;
            return true;
        }
    }

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

    //#6 Animal Shelter
    public class Animal
    {
        public int Order { get; set; }
        public Animal() { }
    }
    public class Dog : Animal { }
    public class Cat : Animal { }

    public class AnimalShelterQueue
    {
        private MyDoublyLinkedList<Cat> _cats;
        private MyDoublyLinkedList<Dog> _dogs;

        public int Count => _cats.Count + _dogs.Count;
        private int _order;
        public AnimalShelterQueue()
        {
            _cats = new MyDoublyLinkedList<Cat>();
            _dogs = new MyDoublyLinkedList<Dog>();
        }

        public void Enqueue(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException();

            animal.Order = _order++;
            if (animal is Dog dog)
                _dogs.AddFirst(new MyDoublyLinkedListNode<Dog>(dog));
            if (animal is Cat cat)
                _cats.AddFirst(new MyDoublyLinkedListNode<Cat>(cat));
        }

        public Animal DequeueAny()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            if (_dogs.Count == 0)
                return DequeueCat();
            if (_cats.Count == 0)
                return DequeueDog();

            if (_cats.Tail.Data.Order > _dogs.Tail.Data.Order)
                return DequeueDog();
            return DequeueCat();
        }

        public Dog DequeueDog()
        {
            if (_dogs.Count == 0)
                throw new InvalidOperationException();

            var dog = _dogs.Tail.Data;
            _dogs.RemoveLast();
            return dog;
        }

        public Cat DequeueCat()
        {
            if (_cats.Count == 0)
                throw new InvalidOperationException();

            var cat = _cats.Tail.Data;
            _cats.RemoveLast();
            return cat;
        }
    }
}
