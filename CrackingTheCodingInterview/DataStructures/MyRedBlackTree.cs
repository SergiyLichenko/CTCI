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

        public bool IsDoubleBlack { get; set; }

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
                {
                    LeftLeftRotation(root);
                    root.Parent.Right.Color = NodeColor.Red;
                    root.Parent.Color = NodeColor.Black;
                }

                if (root.Parent.Right == root && root.Parent.Parent.Right == root.Parent)
                {
                    RightRightRotation(root);
                    root.Parent.Color = NodeColor.Black;
                    root.Parent.Left.Color = NodeColor.Red;
                }
            }
        }

        public MyRedBlackTreeNode<T> Find(T data)
            => FindHelper(data, Root);
        private MyRedBlackTreeNode<T> FindHelper(T data, MyRedBlackTreeNode<T> root)
        {
            if (root.IsNull)
                return null;

            var compared = data.CompareTo(root.Data);
            if (compared == 0)
                return root;
            if (compared < 0)
                return FindHelper(data, root.Left);

            return FindHelper(data, root.Right);
        }


        #region Remove

        public void Remove(MyRedBlackTreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException();

            bool isSingleLeft = node.Left.Color == NodeColor.Red && node.Right.IsNull;
            bool isSingleRight = node.Right.Color == NodeColor.Red && node.Left.IsNull;

            if (!node.Left.IsNull && !node.Right.IsNull)
            {
                var successor = FindInOrderSuccessor(node);
                SwapWithSuccessor(node, successor);
                Remove(node);
            }
            else if (node.Color == NodeColor.Red)
                RemoveSingleRed(node);
            else if (node.Color == NodeColor.Black &&
                     (isSingleLeft || isSingleRight))
                RemoveBlackWithSingleRedChild(node, isSingleLeft);
            else
                RemoveDoubleBlack(node);
        }

        private void RemoveSingleRed(MyRedBlackTreeNode<T> node)
        {
            if (node.Parent.Left == node)
                node.Parent.Left = node.Right;
            else
                node.Parent.Right = node.Right;
            node.Right.Parent = node.Parent;

            node.Right = null;
            node.Parent = null;
            Count--;
        }

        private void RemoveBlackWithSingleRedChild(MyRedBlackTreeNode<T> node, bool isSingleLeft)
        {
            if (Root == node)
            {
                Root = isSingleLeft ? node.Left : node.Right;
                Root.Parent = null;
            }
            else
            {
                if (node.Parent.Right == node)
                    node.Parent.Right = isSingleLeft ? node.Left : node.Right;
                else
                    node.Parent.Left = isSingleLeft ? node.Left : node.Right;

                if (isSingleLeft)
                {
                    node.Left.Parent = node.Parent;
                    node.Left.Color = NodeColor.Black;
                }
                else
                {
                    node.Right.Parent = node.Parent;
                    node.Right.Color = NodeColor.Black;
                }

                node.Parent = null;
                node.Right = null;
            }
            Count--;
        }

        private void RemoveDoubleBlack(MyRedBlackTreeNode<T> node)
        {
            node.Parent.Left = node.Right;
            node.Right.Parent = node.Parent;
            node.Right.IsDoubleBlack = true;

            CaseOneRotationDelete(node.Right);
            node.Right = null;
            node.Parent = null;
            Count--;
        }


        #region Remove Rotation Cases

        private void CaseOneRotationDelete(MyRedBlackTreeNode<T> node)
        {
            if (node == Root && node.IsDoubleBlack)
            {
                node.Color = NodeColor.Black;
                node.IsDoubleBlack = false;
            }
            else
                CaseTwoRotationDelete(node);
        }

        private void CaseTwoRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                node.Parent.Color == NodeColor.Black && sibling.Color == NodeColor.Red &&
                sibling.Left?.Color == NodeColor.Black && sibling.Right?.Color == NodeColor.Black)
            {
                if (node.Parent.Left == node)
                    RightRightRotation(sibling.Right);
                else
                    LeftLeftRotation(sibling.Left);
                sibling.Color = NodeColor.Black;
                node.Parent.Color = NodeColor.Red;
            }
            CaseThreeRotationDelete(node);
        }

        private void CaseThreeRotationDelete(MyRedBlackTreeNode<T> node)
        {
            if (node.IsDoubleBlack && node.Parent?.Color == NodeColor.Black
                && node.Parent?.Left == node && node.Parent?.Right?.Color == NodeColor.Black &&
                node.Parent?.Right?.Left?.Color == NodeColor.Black &&
                node.Parent?.Right?.Right?.Color == NodeColor.Black)
            {
                node.IsDoubleBlack = false;
                node.Parent.IsDoubleBlack = true;
                node.Parent.Right.Color = NodeColor.Red;

                CaseOneRotationDelete(node.Parent);
            }
            else
                CaseFourRotationDelete(node);
        }

        private void CaseFourRotationDelete(MyRedBlackTreeNode<T> node)
        {
            if (node.IsDoubleBlack && node.Parent?.Color == NodeColor.Red &&
                node.Parent?.Right?.Color == NodeColor.Black &&
                node.Parent?.Right?.Left?.Color == NodeColor.Black &&
                node.Parent?.Right?.Right?.Color == NodeColor.Black)
            {
                node.IsDoubleBlack = false;
                node.Parent.Color = NodeColor.Black;
                node.Parent.Right.Color = NodeColor.Red;
            }
            else
                CaseFiveRotationDelete(node);
        }

        private void CaseFiveRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                sibling.Color == NodeColor.Black)
            {
                if (sibling.Left?.Color == NodeColor.Red && sibling.Right?.Color == NodeColor.Black)
                {
                    RightLeftRotation(sibling.Left);
                    sibling.Color = NodeColor.Red;
                    sibling.Parent.Color = NodeColor.Black;
                }
                else if (sibling.Right?.Color == NodeColor.Red && sibling.Left?.Color == NodeColor.Black)
                {
                    LeftRightRotation(sibling.Right);
                    sibling.Color = NodeColor.Red;
                    sibling.Parent.Color = NodeColor.Black;
                }
            }
            CaseSixRotationDelete(node);
        }

        private void CaseSixRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                sibling.Color == NodeColor.Black)
            {
                bool isRotated = false;
                if (sibling?.Right.Color == NodeColor.Red)
                {
                    RightRightRotation(sibling.Right);
                    isRotated = true;
                    sibling.Right.Color = NodeColor.Black;
                }
                else if (sibling?.Left?.Color == NodeColor.Red)
                {
                    LeftLeftRotation(sibling.Left);
                    isRotated = true;
                    sibling.Left.Color = NodeColor.Black;
                }

                if (isRotated)
                {
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = NodeColor.Black;
                    node.IsDoubleBlack = false;
                }
            }
        }

        #endregion


        #endregion


        #region Helpers

        private MyRedBlackTreeNode<T> GetSibling(MyRedBlackTreeNode<T> node)
        {
            if (node == null || node.Parent == null)
                return null;
            if (node.Parent.Left == node)
                return node.Parent.Right;
            return node.Parent.Left;
        }

        private void SwapWithSuccessor(MyRedBlackTreeNode<T> node, MyRedBlackTreeNode<T> successor)
        {
            var parentNode = node.Parent;

            if (parentNode != null)
            {
                if (parentNode.Left == node)
                    parentNode.Left = successor;
                else
                    parentNode.Right = successor;
            }

            var parentSuccessor = successor.Parent;
            if (parentSuccessor.Left == successor)
                parentSuccessor.Left = node;
            else
                parentSuccessor.Right = node;

            successor.Parent = parentNode;
            node.Parent = parentSuccessor;

            var nodeLeft = node.Left;
            node.Left = successor.Left;
            successor.Left = nodeLeft;
            node.Left.Parent = node;
            successor.Left.Parent = successor;

            var nodeRight = node.Right;
            node.Right = successor.Right;
            successor.Right = nodeRight;
            node.Right.Parent = node;
            successor.Right.Parent = successor;

            var color = node.Color;
            node.Color = successor.Color;
            successor.Color = color;

            if (Root == node)
                Root = successor;
        }

        private MyRedBlackTreeNode<T> FindInOrderSuccessor(MyRedBlackTreeNode<T> root)
        {
            var next = root.Right;

            while (!next.IsNull && !next.Left.IsNull)
                next = next.Left;

            return next;
        }

        #endregion

        #region Rotations

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
        }

        #endregion
    }
}
