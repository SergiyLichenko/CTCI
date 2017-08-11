using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public enum NodeColor
    {
        Red,
        Black
    }
    public class MyRedBlackTreeNode<T>
    {
        public T Data { get; private set; }
        public MyRedBlackTreeNode<T> Left { get; set; }
        public MyRedBlackTreeNode<T> Right { get; set; }
        public MyRedBlackTreeNode<T> Parent { get; set; }

        public bool IsNull { get; set; }
        public NodeColor Color { get; set; }

        public MyRedBlackTreeNode(T data)
        {
            Data = data;
            Color = NodeColor.Red;
            Left = new MyRedBlackTreeNode<T>(true, this);
            Right = new MyRedBlackTreeNode<T>(true, this);
        }

        public MyRedBlackTreeNode(bool isNull, MyRedBlackTreeNode<T> parent)
        {
            IsNull = isNull;
            Parent = parent;
            Color = NodeColor.Black;
        }

        public MyRedBlackTreeNode(T data, NodeColor color):this(data)
        {
            Color = color;
        }

        public MyRedBlackTreeNode(T data,
            NodeColor color,
            MyRedBlackTreeNode<T> left,
            MyRedBlackTreeNode<T> right) : this(data, color)
        {
            Left = left;
            Right = right;
        }

        public MyRedBlackTreeNode(T data,
            NodeColor color,
            MyRedBlackTreeNode<T> left,
            MyRedBlackTreeNode<T> right,
            MyRedBlackTreeNode<T> parent) : this(data, color, left, right)
        {
            Parent = parent;
        }
    }

    public class MyRedBlackTree<T>
    {
        public int Count { get; private set; }
        public MyRedBlackTreeNode<T> Root { get; private set; }

        public MyRedBlackTree()
        {
            
        }


        public void Insert(T data)
        {
            if(Root == null)
                Root = new MyRedBlackTreeNode<T>(data, NodeColor.Black);

            Count++;
        }
    }
}
