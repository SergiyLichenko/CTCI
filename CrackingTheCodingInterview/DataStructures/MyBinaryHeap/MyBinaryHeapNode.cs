using System;

namespace DataStructures.MyBinaryHeap
{
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
}