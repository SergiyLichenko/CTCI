using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.MyBinarySearchTree;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyBinarySearchTreeTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var result = new MyBinarySearchTree<int>();

            //assert
            result.Count.ShouldBeEquivalentTo(0);
            result.Root.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Insert()
        {
            //arrange
            var result = new MyBinarySearchTree<int>();

            //act
            result.Insert(8);
            result.Insert(4);
            result.Insert(10);
            result.Insert(2);
            result.Insert(6);
            result.Insert(20);

            //assert
            result.Count.ShouldBeEquivalentTo(6);

            result.Root.Data.ShouldBeEquivalentTo(8);
            result.Root.Left.Data.ShouldBeEquivalentTo(4);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(2);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(6);
            result.Root.Right.Data.ShouldBeEquivalentTo(10);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(20);
        }

        [Fact]
        public void Should_Insert_All_Right()
        {
            //arrange
            var result = new MyBinarySearchTree<int>();

            //act
            result.Insert(10);
            result.Insert(20);
            result.Insert(30);
            result.Insert(40);
            result.Insert(50);
            result.Insert(60);

            //assert
            result.Count.ShouldBeEquivalentTo(6);

            result.Root.Data.ShouldBeEquivalentTo(10);
            result.Root.Right.Data.ShouldBeEquivalentTo(20);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(30);
            result.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(40);
            result.Root.Right.Right.Right.Right.Data.ShouldBeEquivalentTo(50);
            result.Root.Right.Right.Right.Right.Right.Data.ShouldBeEquivalentTo(60);
        }

        [Fact]
        public void Should_Insert_All_Left()
        {
            //arrange
            var result = new MyBinarySearchTree<int>();

            //act
            result.Insert(10);
            result.Insert(9);
            result.Insert(8);
            result.Insert(7);
            result.Insert(6);
            result.Insert(5);

            //assert
            result.Count.ShouldBeEquivalentTo(6);

            result.Root.Data.ShouldBeEquivalentTo(10);
            result.Root.Left.Data.ShouldBeEquivalentTo(9);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(8);
            result.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(7);
            result.Root.Left.Left.Left.Left.Data.ShouldBeEquivalentTo(6);
            result.Root.Left.Left.Left.Left.Left.Data.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_Contains_True()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(10);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(20);

            //act
            var result = tree.Contains(6);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Contains_False()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(8);
            tree.Insert(4);
            tree.Insert(10);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(20);

            //act
            var result = tree.Contains(5);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Contains_When_Empty_Tree()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = tree.Contains(5);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Remove_Helper_Leaf_Node_Left()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(13);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(46);
            tree.Root.Left.Right.Right.Left.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Check_Remove_Helper_Leaf_Node_Right()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(48);
            tree.Insert(13);

            //act
            tree.Remove(48);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Right.ShouldBeEquivalentTo(null);
            tree.Root.Left.Right.Right.Left.Data.ShouldBeEquivalentTo(13);
        }

        [Fact]
        public void Should_Check_Remove_Helper_One_Child_Left()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(47);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(46);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(46);
            tree.Root.Left.Right.Right.Left.Data.ShouldBeEquivalentTo(13);
        }

        [Fact]
        public void Should_Check_Remove_Helper_One_Child_Right()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(45);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(46);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(46);
            tree.Root.Left.Right.Right.Left.Data.ShouldBeEquivalentTo(13);
        }

        [Fact]
        public void Should_Check_Remove_Helper_Two_Children()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(38);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(15);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(13);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(46);
        }

        [Fact]
        public void Should_Check_Remove_When_Is_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            tree.Remove(3);

            //assert
            tree.Count.ShouldBeEquivalentTo(0);
            tree.Root.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Check_Remove_With_Two_Leafs_In_The_Middle()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(9);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Left.Data.ShouldBeEquivalentTo(13);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(46);
        }

        [Fact]
        public void Should_Check_Remove_Multiple()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            //act
            tree.Remove(9);
            tree.Remove(5);
            tree.Remove(15);

            //assert
            tree.Count.ShouldBeEquivalentTo(7);

            tree.Root.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(8);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(47);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(13);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(46);
        }

        [Fact]
        public void Should_Check_PreOrder_Traversal()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            var preOrderTraversal = new int[] { 38, 5, 1, 9, 8, 15, 13, 45, 47, 46 };

            //act
            var result = tree.PreOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            preOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
            for (int i = 0; i < preOrderTraversal.Length; i++)
                preOrderTraversal[i].ShouldBeEquivalentTo(result[i]);
        }

        [Fact]
        public void Should_Check_PreOrder_Traversal_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            var preOrderTraversal = new int[] { };

            //act
            var result = tree.PreOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(0);

            preOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
        }

        [Fact]
        public void Should_Check_InOrder_Traversal()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            var inOrderTraversal = new int[] { 1, 5, 8, 9, 13, 15, 38, 45, 46, 47 };

            //act
            var result = tree.InOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            inOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
            for (int i = 0; i < inOrderTraversal.Length; i++)
                inOrderTraversal[i].ShouldBeEquivalentTo(result[i]);
        }

        [Fact]
        public void Should_Check_InOrder_Traversal_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            var inOrderTraversal = new int[] { };

            //act
            var result = tree.InOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(0);
            inOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
        }

        [Fact]
        public void Should_Check_PostOrder_Traversal()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(38);
            tree.Insert(5);
            tree.Insert(45);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(47);
            tree.Insert(8);
            tree.Insert(15);
            tree.Insert(46);
            tree.Insert(13);

            var postOrderTraversal = new int[] { 1, 8, 13, 15, 9, 5, 46, 47, 45, 38 };

            //act
            var result = tree.PostOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            postOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
            for (int i = 0; i < postOrderTraversal.Length; i++)
                postOrderTraversal[i].ShouldBeEquivalentTo(result[i]);
        }

        [Fact]
        public void Should_Check_PostOrder_Traversal_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            var postOrderTraversal = new int[] { };

            //act
            var result = tree.PostOrderTraversal().ToArray();

            //assert
            tree.Count.ShouldBeEquivalentTo(0);
            postOrderTraversal.Length.ShouldBeEquivalentTo(result.Length);
        }
    }
}
