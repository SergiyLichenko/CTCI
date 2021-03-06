using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.StacksNQueues
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
}