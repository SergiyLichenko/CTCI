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
    public class MyRedBlackTreeNode<T> where T : IComparable
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

        public MyRedBlackTreeNode(T data, NodeColor color) : this(data)
        {
            Color = color;
        }
        public MyRedBlackTreeNode(T data, NodeColor color,
            MyRedBlackTreeNode<T> parent) : this(data)
        {
            Color = color;
            Parent = parent;
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

    public class MyRedBlackTree<T> where T : IComparable
    {
        public int Count { get; private set; }
        public MyRedBlackTreeNode<T> Root { get; private set; }

        public MyRedBlackTree()
        {

        }


        public void Insert(T data)
        {
            if (Root == null)
                Root = new MyRedBlackTreeNode<T>(data, NodeColor.Black);
            else
                InsertHelper(Root, data);
            Count++;
        }

        private void InsertHelper(MyRedBlackTreeNode<T> root, T data)
        {
            MyRedBlackTreeNode<T> node = null;
            if (root.IsNull)
            {
                node = new MyRedBlackTreeNode<T>(data, NodeColor.Red, root.Parent);
                if (root.Parent.Left == root)
                    root.Parent.Left = node;
                else
                    root.Parent.Right = node;
                root.Color = NodeColor.Red;
            }
            var compared = data.CompareTo(root.Data);

            if (compared <= 0 && root.Left != null)
                InsertHelper(root.Left, data);
            else if (root.Right != null)
                InsertHelper(root.Right, data);


            if (root.Parent == null || root.Parent.Color == NodeColor.Black)
            {
                if (node != null)
                    root.Parent = null;
                return;
            }

            var otherSibling = root.Parent.Parent.Left == root.Parent ?
                root.Parent.Parent.Right : root.Parent.Parent.Left;

            if (otherSibling.Color == NodeColor.Red)
            {
                otherSibling.Color = NodeColor.Black;
                otherSibling.Parent.Color = otherSibling.Parent == Root ? NodeColor.Black : NodeColor.Red;
                root.Parent.Color = NodeColor.Black;
            }
            else if (root.Color == NodeColor.Red)
            {
                root = node ?? root;
                if (root.Parent.Right == root && root.Parent.Parent.Left == root.Parent)
                {
                    LeftRightRotation(root);
                    root = root.Left;
                }
                if (root.Parent.Left == root && root.Parent.Parent.Right == root.Parent)
                {
                    RightLeftRotation(root);
                    root = root.Right;
                }

                if (root.Parent.Left == root && root.Parent.Parent.Left == root.Parent)
                    LeftLeftRotation(root);

                if (root.Parent.Right == root && root.Parent.Parent.Right == root.Parent)
                    RightRightRotation(root);
            }
        }

        private void RightLeftRotation(MyRedBlackTreeNode<T> root)
        {
            var parentParent = root.Parent.Parent;

            var right = root.Right;
            root.Right = root.Parent;
            parentParent.Right = root;
            root.Parent = parentParent;
            root.Right.Left = right;
            root.Right.Left.Parent = root.Right;
            root.Right.Parent = root;
        }

        private void RightRightRotation(MyRedBlackTreeNode<T> root)
        {
            var parentParent = root.Parent.Parent;
            if (parentParent.Parent != null)
            {
                if (parentParent.Parent.Left == parentParent)
                    parentParent.Parent.Left = root.Parent;
                else
                    parentParent.Parent.Right = root.Parent;
                root.Parent.Parent = parentParent.Parent;
            }
            else
            {
                Root = root.Parent;
                root.Parent.Parent = null;
            }
            parentParent.Right = root.Parent.Left;
            parentParent.Right.Parent = parentParent;
            root.Parent.Left = parentParent;
            parentParent.Parent = root.Parent;

            root.Parent.Color = NodeColor.Black;
            parentParent.Color = NodeColor.Red;
        }

        private void LeftRightRotation(MyRedBlackTreeNode<T> root)
        {
            var parentParent = root.Parent.Parent;
           
            var left = root.Left;
            root.Left = root.Parent;
            parentParent.Left = root;
            root.Left.Right = left;
            root.Parent = parentParent;
            root.Left.Parent = root;
            root.Left.Right.Parent = root.Left;
        }

        private void LeftLeftRotation(MyRedBlackTreeNode<T> root)
        {
            var parentParent = root.Parent.Parent;
            if (parentParent.Parent != null)
            {
                if (parentParent.Parent.Left == parentParent)
                    parentParent.Parent.Left = root.Parent;
                else
                    parentParent.Parent.Right = root.Parent;
                root.Parent.Parent = parentParent.Parent;
            }
            else
            {
                Root = root.Parent;
                root.Parent.Parent = null;
            }

            parentParent.Left = root.Parent.Right;
            parentParent.Left.Parent = parentParent;
            root.Parent.Right = parentParent;
            parentParent.Parent = root.Parent;

            parentParent.Color = NodeColor.Red;
            root.Parent.Color = NodeColor.Black;
        }
    }
}
