using System;

namespace DataStructures.MyAVLTree
{
    public class MyAVLTreeNode<T> where T : IComparable
    {
        public T Data { get; internal set; }
        public int TreeHeight { get; set; }

        public MyAVLTreeNode<T> Left { get; set; }
        public MyAVLTreeNode<T> Right { get; set; }
        public MyAVLTreeNode(T data)
        {
            Data = data;
        }

        public MyAVLTreeNode(T data, int treeHeight) : this(data)
        {
            TreeHeight = treeHeight;
        }
    }
}