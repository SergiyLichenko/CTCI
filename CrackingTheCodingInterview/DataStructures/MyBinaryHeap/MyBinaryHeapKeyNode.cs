using System;

namespace DataStructures.MyBinaryHeap
{
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
}