using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyAVLTreeNode<T> where T : IComparable
    {
        public T Data { get; private set; }
        public int LeftHeight { get; set; }
        public int RightHeight { get; set; }

        public MyAVLTreeNode<T> Left { get; set; }
        public MyAVLTreeNode<T> Right { get; set; }
        public MyAVLTreeNode(T data)
        {
            Data = data;
        }

        public MyAVLTreeNode(T data, int leftHeight, int rightHeight) : this(data)
        {
            LeftHeight = leftHeight;
            RightHeight = rightHeight;
        }
    }
    public class MyAVLTree<T> where T : IComparable
    {
        public MyAVLTreeNode<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Insert(T data)
        {
            if (Root == null)
                Root = new MyAVLTreeNode<T>(data);
            else
                Root = InsertHelper(data, Root, null);

            Count++;
        }

        private MyAVLTreeNode<T> InsertHelper(T data, MyAVLTreeNode<T> root,
            MyAVLTreeNode<T> parent)
        {
            if (root == null)
                return null;

            var compared = data.CompareTo(root.Data);
            if (compared > 0 && root.Right == null)
                root.Right = new MyAVLTreeNode<T>(data);
            else if (compared > 0)
                root.Right = InsertHelper(data, root.Right, root);

            if (compared <= 0 && root.Left == null)
                root.Left = new MyAVLTreeNode<T>(data);
            else if (compared <= 0)
                root.Left = InsertHelper(data, root.Left, root);

            UpdateNodeHeight(root);

            var dif = root.LeftHeight - root.RightHeight;
            if (dif > 1)
            {
                if (root.Left?.Right != null)
                    root = LeftRightRotation(root);
                return LeftLeftRotation(root);
            }
            if (dif < -1)
            {
                if (root.Right?.Left != null)
                    root = RightLeftRotation(root);
                return RightRightRotation(root);
            }

            return root;
        }

        private void UpdateNodeHeight(MyAVLTreeNode<T> node)
        {
            node.LeftHeight = node.Left == null ? 0 : Math.Max(node.Left.LeftHeight, node.Left.RightHeight) + 1;
            node.RightHeight = node.Right == null ? 0 : Math.Max(node.Right.LeftHeight, node.Right.RightHeight) + 1;
        }

        private MyAVLTreeNode<T> LeftRightRotation(MyAVLTreeNode<T> treeNode)
        {
            var left = treeNode.Left;
            treeNode.Left = left.Right;
            treeNode.Left.Left = left;
            left.Right = null;

            UpdateNodeHeight(treeNode.Left.Left);
            UpdateNodeHeight(treeNode.Left);
            UpdateNodeHeight(treeNode);

            return treeNode;
        }

        private MyAVLTreeNode<T> LeftLeftRotation(MyAVLTreeNode<T> treeNode)
        {
            var left = treeNode.Left;
            treeNode.Left = left.Right;
            left.Right = treeNode;

            UpdateNodeHeight(treeNode);
            UpdateNodeHeight(left);

            return left;
        }

        private MyAVLTreeNode<T> RightRightRotation(MyAVLTreeNode<T> treeNode)
        {
            var right = treeNode.Right;
            treeNode.Right = null;
            right.Left = treeNode;

            UpdateNodeHeight(right.Left);
            UpdateNodeHeight(right);

            return right;
        }

        private MyAVLTreeNode<T> RightLeftRotation(MyAVLTreeNode<T> treeNode)
        {
            var right = treeNode.Right;
            treeNode.Right = right.Left;
            treeNode.Right.Right = right;
            right.Left = null;

            UpdateNodeHeight(right);
            UpdateNodeHeight(treeNode.Right);
            UpdateNodeHeight(treeNode);

            return treeNode;
        }
    }
}
