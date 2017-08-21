using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.MyRedBlackTree
{
    public class MyRedBlackTree<T> where T : IComparable
    {
        public int Count { get; private set; }
        public MyRedBlackTreeNode<T> Root { get; private set; }

        public bool IsValid()
        {
            if (Count == 0)
                return true;
            if (Root.Color == RedBlackTreeNodeColor.Red)
                return false;

            var countBlacks = new List<int>();
            bool isValid = IsValidHelper(Root, null, countBlacks, 0);
            if (!isValid)
                return false;

            return countBlacks.All(x => x == countBlacks.First());
        }

        private bool IsValidHelper(MyRedBlackTreeNode<T> root,
            MyRedBlackTreeNode<T> parent,
            List<int> countBlacks, int currentCount)
        {
            if (root == null || root.Parent != parent)
                return false;
            if (parent != null && parent.Left != root && parent?.Right != root)
                return false;
            if (parent?.Color == RedBlackTreeNodeColor.Red &&
                root.Color == RedBlackTreeNodeColor.Red)
                return false;

            if (root.IsNull)
            {
                countBlacks.Add(currentCount);

                return true;
            }

            if (root.Color == RedBlackTreeNodeColor.Black)
                currentCount++;
            if (!IsValidHelper(root.Left, root, countBlacks, currentCount))
                return false;
            if (!IsValidHelper(root.Right, root, countBlacks, currentCount))
                return false;

            return true;
        }

        public void Insert(T data)
        {
            if (Root == null)
                Root = new MyRedBlackTreeNode<T>(data, RedBlackTreeNodeColor.Black);
            else
                InsertHelper(Root, data);
            Count++;
        }

        private void InsertHelper(MyRedBlackTreeNode<T> root, T data)
        {
            MyRedBlackTreeNode<T> node = null;
            if (root.IsNull)
            {
                node = new MyRedBlackTreeNode<T>(data, RedBlackTreeNodeColor.Red, root.Parent);
                if (root.Parent.Left == root)
                    root.Parent.Left = node;
                else
                    root.Parent.Right = node;
                root.Color = RedBlackTreeNodeColor.Red;
            }
            var compared = data.CompareTo(root.Data);

            if (compared <= 0 && root.Left != null)
                InsertHelper(root.Left, data);
            else if (root.Right != null)
                InsertHelper(root.Right, data);


            if (root.Parent == null || root.Parent.Color == RedBlackTreeNodeColor.Black)
            {
                if (node != null)
                    root.Parent = null;
                return;
            }

            var otherSibling = root.Parent.Parent.Left == root.Parent ?
                root.Parent.Parent.Right : root.Parent.Parent.Left;

            if (otherSibling.Color == RedBlackTreeNodeColor.Red)
            {
                otherSibling.Color = RedBlackTreeNodeColor.Black;
                otherSibling.Parent.Color = otherSibling.Parent == Root ? RedBlackTreeNodeColor.Black : RedBlackTreeNodeColor.Red;
                root.Parent.Color = RedBlackTreeNodeColor.Black;
            }
            else if (root.Color == RedBlackTreeNodeColor.Red)
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
                    root.Parent.Right.Color = RedBlackTreeNodeColor.Red;
                    root.Parent.Color = RedBlackTreeNodeColor.Black;
                }

                if (root.Parent.Right == root && root.Parent.Parent.Right == root.Parent)
                {
                    RightRightRotation(root);
                    root.Parent.Color = RedBlackTreeNodeColor.Black;
                    root.Parent.Left.Color = RedBlackTreeNodeColor.Red;
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
            if (compared == 0 && !root.IsNull)
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

            bool isSingleLeft = node.Left.Color == RedBlackTreeNodeColor.Red && node.Right.IsNull;
            bool isSingleRight = node.Right.Color == RedBlackTreeNodeColor.Red && node.Left.IsNull;

            if (!node.Left.IsNull && !node.Right.IsNull)
            {
                var successor = FindInOrderSuccessor(node);
                SwapWithSuccessor(node, successor);
                Remove(node);
            }
            else if (node.Color == RedBlackTreeNodeColor.Red)
                RemoveSingleRed(node);
            else if (node.Color == RedBlackTreeNodeColor.Black &&
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
                Root.Color = RedBlackTreeNodeColor.Black;
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
                    node.Left.Color = RedBlackTreeNodeColor.Black;
                }
                else
                {
                    node.Right.Parent = node.Parent;
                    node.Right.Color = RedBlackTreeNodeColor.Black;
                }

                node.Parent = null;
                node.Right = null;
            }
            Count--;
        }

        private void RemoveDoubleBlack(MyRedBlackTreeNode<T> node)
        {
            Count--;
            if (node == Root)
            {
                Root = null;
                return;
            }

            var isRight = node.Parent.Right == node;
            if (isRight)
                node.Parent.Right = node.Right;
            else
                node.Parent.Left = node.Right;

            node.Right.Parent = node.Parent;
            node.Right.IsDoubleBlack = true;

            CaseOneRotationDelete(node.Right);
            node.Right = null;
            node.Parent = null;
        }




        #region Remove Rotation Cases

        private void CaseOneRotationDelete(MyRedBlackTreeNode<T> node)
        {
            if (node == Root && node.IsDoubleBlack)
            {
                node.Color = RedBlackTreeNodeColor.Black;
                node.IsDoubleBlack = false;
            }
            else
                CaseTwoRotationDelete(node);
        }

        private void CaseTwoRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                node.Parent.Color == RedBlackTreeNodeColor.Black && sibling.Color == RedBlackTreeNodeColor.Red &&
                sibling.Left?.Color == RedBlackTreeNodeColor.Black && sibling.Right?.Color == RedBlackTreeNodeColor.Black)
            {
                if (node.Parent.Left == node)
                    RightRightRotation(sibling.Right);
                else
                    LeftLeftRotation(sibling.Left);
                sibling.Color = RedBlackTreeNodeColor.Black;
                node.Parent.Color = RedBlackTreeNodeColor.Red;
            }
            CaseThreeRotationDelete(node);
        }

        private void CaseThreeRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                node.Parent?.Color == RedBlackTreeNodeColor.Black && sibling.Color == RedBlackTreeNodeColor.Black &&
                sibling.Left?.Color == RedBlackTreeNodeColor.Black && sibling.Right?.Color == RedBlackTreeNodeColor.Black)
            {
                node.IsDoubleBlack = false;
                node.Parent.IsDoubleBlack = true;
                sibling.Color = RedBlackTreeNodeColor.Red;

                CaseOneRotationDelete(node.Parent);
            }
            CaseFourRotationDelete(node);
        }

        private void CaseFourRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                node.Parent.Color == RedBlackTreeNodeColor.Red && sibling.Color == RedBlackTreeNodeColor.Black &&
                sibling.Left.Color == RedBlackTreeNodeColor.Black && sibling.Right.Color == RedBlackTreeNodeColor.Black)
            {
                node.IsDoubleBlack = false;
                node.Parent.Color = RedBlackTreeNodeColor.Black;
                sibling.Color = RedBlackTreeNodeColor.Red;
            }
            else
                CaseFiveRotationDelete(node);
        }

        private void CaseFiveRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                sibling.Color == RedBlackTreeNodeColor.Black)
            {
                if (sibling.Parent?.Right == sibling &&
                    sibling.Left?.Color == RedBlackTreeNodeColor.Red && 
                    sibling.Right?.Color == RedBlackTreeNodeColor.Black)
                {
                    RightLeftRotation(sibling.Left);
                    sibling.Color = RedBlackTreeNodeColor.Red;
                    sibling.Parent.Color = RedBlackTreeNodeColor.Black;
                }
                else if (sibling.Parent?.Left == sibling &&
                    sibling.Right?.Color == RedBlackTreeNodeColor.Red && 
                    sibling.Left?.Color == RedBlackTreeNodeColor.Black)
                {
                    LeftRightRotation(sibling.Right);
                    sibling.Color = RedBlackTreeNodeColor.Red;
                    sibling.Parent.Color = RedBlackTreeNodeColor.Black;
                }
            }
            CaseSixRotationDelete(node);
        }

        private void CaseSixRotationDelete(MyRedBlackTreeNode<T> node)
        {
            var sibling = GetSibling(node);
            if (node.IsDoubleBlack && sibling != null &&
                sibling.Color == RedBlackTreeNodeColor.Black)
            {
                bool isRotated = false;
                if (sibling?.Right?.Color == RedBlackTreeNodeColor.Red && sibling.Left != null &&
                    sibling.Parent.Right == sibling)
                {
                    RightRightRotation(sibling.Right);
                    isRotated = true;
                    sibling.Right.Color = RedBlackTreeNodeColor.Black;
                }
                else if (sibling?.Left?.Color == RedBlackTreeNodeColor.Red && sibling.Right != null &&
                    sibling.Parent.Left == sibling)
                {
                    LeftLeftRotation(sibling.Left);
                    isRotated = true;
                    sibling.Left.Color = RedBlackTreeNodeColor.Black;
                }

                if (isRotated)
                {
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = RedBlackTreeNodeColor.Black;
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
            if (parentParent == Root)
                Root = root.Parent;
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
            if (parentParent == Root)
                Root = root.Parent;
        }

        #endregion
    }
}
