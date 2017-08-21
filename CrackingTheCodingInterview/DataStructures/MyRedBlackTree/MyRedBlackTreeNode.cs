using System;

namespace DataStructures.MyRedBlackTree
{
    public class MyRedBlackTreeNode<T> where T : IComparable
    {
        public T Data { get; private set; }
        public MyRedBlackTreeNode<T> Left { get; set; }
        public MyRedBlackTreeNode<T> Right { get; set; }
        public MyRedBlackTreeNode<T> Parent { get; set; }

        public bool IsNull { get; set; }
        public RedBlackTreeNodeColor Color { get; set; }

        public bool IsDoubleBlack { get; set; }

        public MyRedBlackTreeNode(T data)
        {
            Data = data;
            Color = RedBlackTreeNodeColor.Red;
            Left = new MyRedBlackTreeNode<T>(true, this);
            Right = new MyRedBlackTreeNode<T>(true, this);
        }

        public MyRedBlackTreeNode(bool isNull, MyRedBlackTreeNode<T> parent)
        {
            IsNull = isNull;
            Parent = parent;
            Color = RedBlackTreeNodeColor.Black;
        }

        public MyRedBlackTreeNode(T data, RedBlackTreeNodeColor color) : this(data)
        {
            Color = color;
        }
        public MyRedBlackTreeNode(T data, RedBlackTreeNodeColor color,
            MyRedBlackTreeNode<T> parent) : this(data)
        {
            Color = color;
            Parent = parent;
        }

        public MyRedBlackTreeNode(T data,
            RedBlackTreeNodeColor color,
            MyRedBlackTreeNode<T> left,
            MyRedBlackTreeNode<T> right) : this(data, color)
        {
            Left = left;
            Right = right;
        }

        public MyRedBlackTreeNode(T data,
            RedBlackTreeNodeColor color,
            MyRedBlackTreeNode<T> left,
            MyRedBlackTreeNode<T> right,
            MyRedBlackTreeNode<T> parent) : this(data, color, left, right)
        {
            Parent = parent;
        }

        public MyRedBlackTreeNode<T> Clone()
        {
            return (MyRedBlackTreeNode<T>)MemberwiseClone();
        }
    }
}