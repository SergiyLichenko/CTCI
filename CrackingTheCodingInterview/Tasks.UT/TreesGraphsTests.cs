using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class TreesGraphsTests
    {
        private TreesGraphs _treesGraphs;

        public TreesGraphsTests()
        {
            _treesGraphs = new TreesGraphs();
        }

        [Fact]
        public void RouteBetweenNodes_Should_Check_True()
        {
            //arrange
            var graph = new MyGraph<int>(7);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);
            graph.AddVertex(6, 6);

            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(4, 6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 3);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 5);

            //act
            var result = _treesGraphs.RouteBetweenNodes(graph, 0, 3);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void RouteBetweenNodes_Should_Check_False()
        {
            //arrange
            var graph = new MyGraph<int>(7);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);
            graph.AddVertex(6, 6);

            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 5);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 3);

            //act
            var result = _treesGraphs.RouteBetweenNodes(graph, 0, 3);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void MinimalTree_Should_Throw_If_Empty()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.MinimalTree(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MinimalTree_Should_Create_Length_One()
        {
            //arrange
            var values = new int[] { 1 };
            //act
            var result = _treesGraphs.MinimalTree(values);

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result.Root.Data.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void MinimalTree_Should_Create_Empty()
        {
            //arrange
            var values = new int[] { };
            //act
            var result = _treesGraphs.MinimalTree(values);

            //assert
            result.Count.ShouldBeEquivalentTo(0);
            result.Root.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void MinimalTree_Should_Even_Size()
        {
            //arrange
            var values = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            //act
            var result = _treesGraphs.MinimalTree(values);

            //assert
            result.Count.ShouldBeEquivalentTo(7);
            result.Root.Data.ShouldBeEquivalentTo(4);
            result.Root.Left.Data.ShouldBeEquivalentTo(2);
            result.Root.Right.Data.ShouldBeEquivalentTo(6);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(3);
            result.Root.Right.Left.Data.ShouldBeEquivalentTo(5);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void MinimalTree_Should_Odd_Size()
        {
            //arrange
            var values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //act
            var result = _treesGraphs.MinimalTree(values);

            //assert
            result.Count.ShouldBeEquivalentTo(8);
            result.Root.Data.ShouldBeEquivalentTo(4);
            result.Root.Left.Data.ShouldBeEquivalentTo(2);
            result.Root.Right.Data.ShouldBeEquivalentTo(6);
            result.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            result.Root.Left.Right.Data.ShouldBeEquivalentTo(3);
            result.Root.Right.Left.Data.ShouldBeEquivalentTo(5);
            result.Root.Right.Right.Data.ShouldBeEquivalentTo(7);
            result.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void ListOfDepth_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.ListOfDepth(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ListOfDepth_Should_Empty_Tree()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.ListOfDepth(tree);

            //assert
            result.Should().NotBeNull();
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void ListOfDepth_Should_Depth_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(1);

            //act
            var result = _treesGraphs.ListOfDepth(tree);

            //assert
            result.Length.ShouldBeEquivalentTo(1);
            result[0].Count.ShouldBeEquivalentTo(1);
            result[0].Head.Data.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ListOfDepth_Should_Check_Depth()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(4);
            tree.Insert(2);
            tree.Insert(6);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(8);

            //act
            var result = _treesGraphs.ListOfDepth(tree);

            //assert
            result.Length.ShouldBeEquivalentTo(4);

            result[0].Count.ShouldBeEquivalentTo(1);
            result[0].Head.Data.ShouldBeEquivalentTo(4);

            result[1].Count.ShouldBeEquivalentTo(2);
            result[1].Head.Data.ShouldBeEquivalentTo(2);
            result[1].Head.Next.Data.ShouldBeEquivalentTo(6);

            result[2].Count.ShouldBeEquivalentTo(4);
            result[2].Head.Data.ShouldBeEquivalentTo(1);
            result[2].Head.Next.Data.ShouldBeEquivalentTo(3);
            result[2].Head.Next.Next.Data.ShouldBeEquivalentTo(5);
            result[2].Head.Next.Next.Next.Data.ShouldBeEquivalentTo(7);

            result[3].Count.ShouldBeEquivalentTo(1);
            result[3].Head.Data.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void CheckBalanced_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.CheckBalanced(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CheckBalanced_Should_Check_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckBalanced_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(5);

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckBalanced_Should_Check_Depth_False()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(12);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(13);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(2);

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CheckBalanced_Should_Check_Depth_True()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(13);
            tree.Insert(17);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(14);
            tree.Insert(2);

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckBalanced_Should_Check_False()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(12);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(11);
            tree.Insert(13);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CheckBalanced_Should_Check_True()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(3);

            //act
            var result = _treesGraphs.CheckBalanced(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ValidateBST_Should_Throw_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.ValidateBST(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ValidateBST_Should_Check_Empty()
        {
            //arrange
            var tree =new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.ValidateBST(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ValidateBST_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(3);

            //act
            var result = _treesGraphs.ValidateBST(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ValidateBST_Should_Multiple_Depth_True()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(13);
            tree.Insert(17);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(14);
            tree.Insert(2);

            //act
            var result = _treesGraphs.ValidateBST(tree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void ValidateBST_Should_Multiple_Depth_False()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(10);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(4);
            tree.Insert(8);
            tree.Insert(13);
            tree.Insert(17);
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(14);
            tree.Insert(2);

            tree.Root.Left.Data = 8;

            //act
            var result = _treesGraphs.ValidateBST(tree);

            //assert
            result.ShouldBeEquivalentTo(false);
        }
    }
}
