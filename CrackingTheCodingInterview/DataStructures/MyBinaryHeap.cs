﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public enum MyBinaryHeapType
    {
        MinHeap,
        MaxHeap
    }

    public class MyBinaryHeapNode<T> where T: IComparable
    {
        public MyBinaryHeapNode<T> Left { get; set; }
        public MyBinaryHeapNode<T> Right { get; set; }
        public MyBinaryHeapNode<T> Parent { get; set; }
        public T Data { get; set; }

        public MyBinaryHeapNode(T data)
        {
            Data = data;
        }
    }

    public class MyBinaryHeapKeyNode<TKey, TValue> : MyBinaryHeapNode<TValue>, IComparable
        where TValue : IComparable
    {
        public TKey Key { get; private set; }
        public MyBinaryHeapKeyNode(TValue data) : base(data)
        {

        }

        public MyBinaryHeapKeyNode(TKey key, TValue value) : this(value)
        {
            Key = key;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            if (!(obj is MyBinaryHeapKeyNode<TKey, TValue>))
                throw new ArgumentException();
            var node = (MyBinaryHeapKeyNode<TKey, TValue>)obj;

            return Data.CompareTo(node.Data);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
            if (!(obj is MyBinaryHeapKeyNode<TKey, TValue>))
                throw new ArgumentException();
            var node = (MyBinaryHeapKeyNode<TKey, TValue>)obj;

            return Key.Equals(node.Key);
        }
    }

    public class MyBinaryHeap<T> where T : IComparable
    {
        public MyBinaryHeapNode<T> Root => _nodes.Count == 0 ? null : _nodes[0];
        public MyBinaryHeapType HeapType { get; private set; }
        public int Count { get; private set; }

        private Dictionary<MyBinaryHeapNode<T>, int> _map;
        private List<MyBinaryHeapNode<T>> _nodes;

        public MyBinaryHeap(MyBinaryHeapType type)
        {
            HeapType = type;
            _map = new Dictionary<MyBinaryHeapNode<T>, int>();
            _nodes = new List<MyBinaryHeapNode<T>>();
        }

        public void Insert(T data)
        {
            var currentIndex = Count++;
            var parentIndex = (currentIndex - 1) / 2;
            var node = new MyBinaryHeapNode<T>(data);
            _nodes.Add(node);

            if (Count == 1)
                return;

            if (_nodes[parentIndex].Left == null)
                _nodes[parentIndex].Left = node;
            else
                _nodes[parentIndex].Right = node;

            node.Parent = _nodes[parentIndex];
            BubbleUp(currentIndex, parentIndex);
        }

        public T ExtractTop()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            var data = Root.Data;
            var lastNode = _nodes[--Count];
            _nodes.RemoveAt(Count);

            if (Count == 0)
                return data;

            var lastNodeParentIndex = (Count - 1) / 2;

            if (_nodes[lastNodeParentIndex].Left.Equals(lastNode))
                _nodes[lastNodeParentIndex].Left = null;
            else
                _nodes[lastNodeParentIndex].Right = null;

            Root.Data = lastNode.Data;
            BubbleDown(0);

            return data;
        }

        public void Decrease(T item, T newValue)
        {
            if (!Contains(item))
                throw new InvalidOperationException();
            if ((item.CompareTo(newValue) < 0 &&
                HeapType == MyBinaryHeapType.MinHeap) ||
               (item.CompareTo(newValue) > 0 &&
                HeapType == MyBinaryHeapType.MaxHeap))
                throw new ArgumentException();
            var currentIndex = _nodes.FindIndex(x => x.Data.Equals(item));
            var parentIndex = (currentIndex - 1) / 2;

            _nodes[currentIndex].Data = newValue;
            BubbleUp(currentIndex, parentIndex);
        }

        public bool Contains(T item) => _nodes.Count(x => x.Data.Equals(item)) != 0;

        private void BubbleDown(int currentIndex)
        {
            bool MinHeapCondition() =>
                (_nodes[currentIndex].Left?.Data.CompareTo(_nodes[currentIndex].Data) < 0 ||
                 _nodes[currentIndex].Right?.Data.CompareTo(_nodes[currentIndex].Data) < 0) &&
                HeapType == MyBinaryHeapType.MinHeap;

            bool MaxHeapCondition() =>
                (_nodes[currentIndex].Left?.Data.CompareTo(_nodes[currentIndex].Data) > 0 ||
                 _nodes[currentIndex].Right?.Data.CompareTo(_nodes[currentIndex].Data) > 0) &&
                HeapType == MyBinaryHeapType.MaxHeap;

            while (MinHeapCondition() || MaxHeapCondition())
            {
                int? Compared() => _nodes[currentIndex].Left?.Data
                    .CompareTo(_nodes[currentIndex].Right.Data);
                var temp = _nodes[currentIndex].Data;

                if (_nodes[currentIndex].Right == null ||
                    ((Compared() <= 0 && HeapType == MyBinaryHeapType.MinHeap) ||
                     (Compared() >= 0 && HeapType == MyBinaryHeapType.MaxHeap)))
                {
                    _nodes[currentIndex].Data = _nodes[currentIndex].Left.Data;
                    _nodes[currentIndex].Left.Data = temp;
                    currentIndex = currentIndex * 2 + 1;
                }
                else
                {
                    _nodes[currentIndex].Data = _nodes[currentIndex].Right.Data;
                    _nodes[currentIndex].Right.Data = temp;
                    currentIndex = currentIndex * 2 + 2;
                }
            }
        }

        private void BubbleUp(int currentIndex, int parentIndex)
        {
            bool MinHeapCondition() =>
                _nodes[parentIndex].Data.CompareTo(_nodes[currentIndex].Data) > 0 &&
                HeapType == MyBinaryHeapType.MinHeap;

            bool MaxHeapCondition() =>
                _nodes[parentIndex].Data.CompareTo(_nodes[currentIndex].Data) < 0 &&
                HeapType == MyBinaryHeapType.MaxHeap;

            while (MinHeapCondition() || MaxHeapCondition())
            {
                var temp = _nodes[parentIndex].Data;
                _nodes[parentIndex].Data = _nodes[currentIndex].Data;
                _nodes[currentIndex].Data = temp;

                if (parentIndex == 0)
                    break;
                currentIndex = parentIndex;
                parentIndex = (currentIndex - 1) / 2;
            }
        }

    }
}
