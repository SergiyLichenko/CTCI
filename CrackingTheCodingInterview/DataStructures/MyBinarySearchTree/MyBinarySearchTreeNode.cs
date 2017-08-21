using System;

namespace DataStructures.MyBinarySearchTree
{
    public class MyBinarySearchTreeNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public MyBinarySearchTreeNode<T> Left { get; set; }
        public MyBinarySearchTreeNode<T> Right { get; set; }
        public MyBinarySearchTreeNode(T data)
        {
            Data = data;
        }

        public MyBinarySearchTreeNode(T data, MyBinarySearchTreeNode<T> left,
            MyBinarySearchTreeNode<T> right) : this(data)
        {
            Left = left;
            Right = right;
        }

    }
}