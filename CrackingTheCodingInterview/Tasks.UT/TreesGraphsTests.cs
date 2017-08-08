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
            var tree = new MyBinarySearchTree<int>();

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

        [Fact]
        public void Successor_Should_Check_If_Null()
        {
            //arrange

            //act
            Action actFirst = () => _treesGraphs.Successor(null, new MyBinarySearchTreeNode<int>(1));
            Action actSecond = () => _treesGraphs.Successor(new MyBinarySearchTree<int>(), null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Successor_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(2);

            //act
            var result = _treesGraphs.Successor(tree, tree.Root);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Successor_Should_Check_Right_Substree_Case()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(20);
            tree.Insert(8);
            tree.Insert(22);
            tree.Insert(4);
            tree.Insert(12);
            tree.Insert(10);
            tree.Insert(14);

            //act
            var result = _treesGraphs.Successor(tree, tree.Root.Left);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);
        }

        [Fact]
        public void Successor_Should_Check_Parent_Case()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(20);
            tree.Insert(8);
            tree.Insert(22);
            tree.Insert(4);
            tree.Insert(12);
            tree.Insert(10);
            tree.Insert(14);

            //act
            var result = _treesGraphs.Successor(tree, tree.Root.Left.Right.Left);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Left.Right);
        }


        [Fact]
        public void Successor_Should_Check_Parent_Case_Multiple()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(20);
            tree.Insert(8);
            tree.Insert(22);
            tree.Insert(4);
            tree.Insert(12);
            tree.Insert(10);
            tree.Insert(14);

            //act
            var result = _treesGraphs.Successor(tree, tree.Root.Left.Right.Right);

            //assert
            result.ShouldBeEquivalentTo(tree.Root);
        }

        [Fact]
        public void Successor_Should_Check_Null_Case()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(20);
            tree.Insert(8);
            tree.Insert(22);
            tree.Insert(4);
            tree.Insert(12);
            tree.Insert(10);
            tree.Insert(14);

            //act
            var result = _treesGraphs.Successor(tree, tree.Root.Right);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void BuildOrder_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.BuildOrder(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BuildOrder_Should_Check_Example()
        {
            //arrange
            var graph = new MyGraph<char>(6);
            graph.AddVertex(0, 'a');
            graph.AddVertex(1, 'b');
            graph.AddVertex(2, 'c');
            graph.AddVertex(3, 'd');
            graph.AddVertex(4, 'e');
            graph.AddVertex(5, 'f');

            graph.AddEdge(5, 1);
            graph.AddEdge(5, 0);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 3);
            graph.AddEdge(3, 2);

            var order = new[] { 'e', 'f', 'a', 'b', 'd', 'c' };

            //act
            var result = _treesGraphs.BuildOrder(graph).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(order.Length);

            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(order[i]);
        }

        [Fact]
        public void BuildOrder_Should_Check_Order()
        {
            //arrange
            var graph = new MyGraph<char>(6);
            graph.AddVertex(0, 'a');
            graph.AddVertex(1, 'b');
            graph.AddVertex(2, 'c');
            graph.AddVertex(3, 'd');
            graph.AddVertex(4, 'e');
            graph.AddVertex(5, 'f');

            graph.AddEdge(0, 5);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 5);
            graph.AddEdge(3, 2);

            var order = new[] { 'a', 'b', 'd', 'e', 'c', 'f' };

            //act
            var result = _treesGraphs.BuildOrder(graph).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(order.Length);

            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(order[i]);
        }

        [Fact]
        public void BuildOrder_Should_Check_Order_Reversed()
        {
            //arrange
            var graph = new MyGraph<char>(6);
            graph.AddVertex(0, 'a');
            graph.AddVertex(1, 'b');
            graph.AddVertex(2, 'c');
            graph.AddVertex(3, 'd');
            graph.AddVertex(4, 'e');
            graph.AddVertex(5, 'f');

            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(3, 1);
            graph.AddEdge(5, 2);
            graph.AddEdge(2, 3);

            var order = new[] { 'e', 'f', 'a', 'c', 'd', 'b' };

            //act
            var result = _treesGraphs.BuildOrder(graph).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(order.Length);

            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(order[i]);
        }

        [Fact]
        public void BuildOrder_Should_Check_For_Cycle()
        {
            //arrange
            var graph = new MyGraph<char>(6);
            graph.AddVertex(0, 'a');
            graph.AddVertex(1, 'b');
            graph.AddVertex(2, 'c');

            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);

            //act
            Action act = () => _treesGraphs.BuildOrder(graph);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void BuildOrder_Should_Check_Empty()
        {
            //arrange
            var graph = new MyGraph<char>(6);

            //act
            var result = _treesGraphs.BuildOrder(graph).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void BuildOrder_Should_Check_Length_One()
        {
            //arrange
            var graph = new MyGraph<char>(6);
            graph.AddVertex(0, 'a');

            //act
            var result = _treesGraphs.BuildOrder(graph).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo('a');
        }

        [Fact]
        public void FirstCommonAncestor_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action actFirst = () => _treesGraphs.FirstCommonAncestor(null,
                new MyBinarySearchTreeNode<int>(1), new MyBinarySearchTreeNode<int>(2));
            Action actSecond = () => _treesGraphs.FirstCommonAncestor(new MyBinarySearchTree<int>(),
                null, new MyBinarySearchTreeNode<int>(2));
            Action actThird = () => _treesGraphs.FirstCommonAncestor(new MyBinarySearchTree<int>(),
                new MyBinarySearchTreeNode<int>(1), null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
            actThird.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(3);

            //act
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root, tree.Root);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Length_Two()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(3);
            tree.Insert(5);

            //act
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root, tree.Root.Right);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Length_Three()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(3);
            tree.Insert(5);
            tree.Insert(1);

            //act
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root.Left, tree.Root.Right);

            //assert
            result.ShouldBeEquivalentTo(tree.Root);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Multiple_Depth()
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
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root.Left.Left.Left.Left, tree.Root.Right.Left.Right);

            //assert
            result.ShouldBeEquivalentTo(tree.Root);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Multiple_Depth_Same_Branch()
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
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root.Left.Left.Left.Left, tree.Root.Left.Left.Right);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Left.Left);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Multiple_Depth_One_Parent()
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
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root.Left.Left.Left.Left, tree.Root);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void FirstCommonAncestor_Should_Check_Multiple_Depth_One_Root()
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
            var result = _treesGraphs.FirstCommonAncestor(tree,
                tree.Root.Left.Left.Left.Left, tree.Root.Left.Left);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Left);
        }

        [Fact]
        public void BSTSequences_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.BSTSequences(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BSTSequences_Should_Check_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.BSTSequences(tree);

            //assert
            result.Count.ShouldBeEquivalentTo(0);
        }


        [Fact]
        public void BSTSequences_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(5);

            //act
            var result = _treesGraphs.BSTSequences(tree);

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result[0].Length.ShouldBeEquivalentTo(1);
            result[0][0].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void BSTSequences_Should_Check_Example()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(2);
            tree.Insert(1);
            tree.Insert(3);

            var res = new List<int[]>()
            {
                new int[] {2, 1, 3},
                new int[] {2, 3, 1}
            };

            //act
            var result = _treesGraphs.BSTSequences(tree);

            //assert
            result.Count.ShouldBeEquivalentTo(res.Count);
            for (int i = 0; i < result.Count; i++)
            {
                res[i].Length.ShouldBeEquivalentTo(result[i].Length);
                for (int j = 0; j < result[i].Length; j++)
                    res[i][j].ShouldBeEquivalentTo(result[i][j]);
            }
        }

        [Fact]
        public void BSTSequences_Should_Check_Multiple_Depth()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(2);
            tree.Insert(0);
            tree.Insert(-1);
            tree.Insert(1);
            tree.Insert(8);
            tree.Insert(3);

            var res = new List<int[]>()
            {
                new [] {2, 0,-1,1,8,3},
                new [] {2, 0, -1,8,1,3},
                new [] {2, 0,-1,8,3,1},
                new [] {2, 0,8,-1,1,3},
                new [] {2,0,8,-1,3,1},
                new [] {2,0,8,3,-1,1},
                new [] {2,8,0,-1,1,3},
                new [] {2,8,0,-1,3,1},
                new [] {2,8,0,3,-1,1},
                new [] {2,8,3,0,-1,1},
                new [] {2,0,1,-1,8,3},
                new [] {2,0,1,8,-1,3},
                new [] {2,0,1,8,3,-1},
                new [] {2,0,8,1,-1,3},
                new [] {2,0,8,1,3,-1},
                new [] {2,0,8,3,1,-1},
                new [] {2,8,0,1,-1,3},
                new [] {2,8,0,1,3,-1},
                new [] {2,8,0,3,1,-1},
                new [] {2,8,3,0,1,-1}
            };

            //act
            var result = _treesGraphs.BSTSequences(tree);

            //assert
            result.Count.ShouldBeEquivalentTo(res.Count);
            for (int i = 0; i < result.Count; i++)
            {
                res[i].Length.ShouldBeEquivalentTo(result[i].Length);
                for (int j = 0; j < result[i].Length; j++)
                    res[i][j].ShouldBeEquivalentTo(result[i][j]);
            }
        }

        [Fact]
        public void BSTSequences_Should_Check_Complex()
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
            var result = _treesGraphs.BSTSequences(tree);

            //assert
            var inOrderTraversal = tree.InOrderTraversal().ToList();
            foreach (var item in result)
            {
                var tempTree = new MyBinarySearchTree<int>();
                foreach (var value in item)
                    tempTree.Insert(value);

                var tempTraversal = tempTree.InOrderTraversal().ToList();
                tempTraversal.Count.ShouldBeEquivalentTo(inOrderTraversal.Count);

                for (int i = 0; i < tempTraversal.Count; i++)
                    tempTraversal[i].ShouldBeEquivalentTo(inOrderTraversal[i]);
            }
        }

        [Fact]
        public void CheckSubtree_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action actFirst = () => _treesGraphs.CheckSubtree(null, new MyBinarySearchTree<int>());
            Action actSecond = () => _treesGraphs.CheckSubtree(new MyBinarySearchTree<int>(), null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void CheckSubtree_Should_Check_Two_Empty()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckSubtree_Should_Check_Smaller_Empty()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            biggerTree.Insert(4);
            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckSubtree_Should_Check_Bigger_Empty()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            smallerTree.Insert(4);
            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CheckSubtree_Should_Check_Length_One()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            biggerTree.Insert(5);
            smallerTree.Root = biggerTree.Root;

            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckSubtree_Should_Check_Multiple_Depth_True()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            biggerTree.Insert(10);
            biggerTree.Insert(6);
            biggerTree.Insert(15);
            biggerTree.Insert(4);
            biggerTree.Insert(8);
            biggerTree.Insert(13);
            biggerTree.Insert(17);
            biggerTree.Insert(3);
            biggerTree.Insert(5);
            biggerTree.Insert(7);
            biggerTree.Insert(14);
            biggerTree.Insert(2);

            smallerTree.Root = biggerTree.Root.Left.Left;

            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CheckSubtree_Should_Check_Multiple_Depth_False()
        {
            //arrange
            var biggerTree = new MyBinarySearchTree<int>();
            var smallerTree = new MyBinarySearchTree<int>();

            biggerTree.Insert(10);
            biggerTree.Insert(6);
            biggerTree.Insert(15);
            biggerTree.Insert(4);
            biggerTree.Insert(8);
            biggerTree.Insert(13);
            biggerTree.Insert(17);
            biggerTree.Insert(3);
            biggerTree.Insert(5);
            biggerTree.Insert(7);
            biggerTree.Insert(14);
            biggerTree.Insert(2);

            smallerTree.Root = biggerTree.Root.Left.Left;
            biggerTree.Root = biggerTree.Root.Right;

            //act
            var result = _treesGraphs.CheckSubtree(biggerTree, smallerTree);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void RandomNode_Should_Throw_If_Null()
        {
            //arrange
            
            //act
            Action act = ()=>_treesGraphs.RandomNode(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RandomNode_Should_Check_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.RandomNode(tree);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void RandomNode_Should_Check_Length_One()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(4);

            //act
            var result = _treesGraphs.RandomNode(tree);

            //assert
            result.ShouldBeEquivalentTo(tree.Root);
        }

        [Fact]
        public void RandomNode_Should_Check_Multiple_Length()
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
            var result = _treesGraphs.RandomNode(tree);

            //assert
            tree.Contains(result.Data).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void PathsWithSum_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _treesGraphs.PathsWithSum(null, 1);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PathsWithSum_Should_Check_Empty()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();

            //act
            var result = _treesGraphs.PathsWithSum(tree, 1);

            //assert
            result.ShouldBeEquivalentTo(0);
        }


        [Fact]
        public void PathsWithSum_Should_Check_Length_One_False()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(5);

            //act
            var result = _treesGraphs.PathsWithSum(tree, 1);

            //assert
            result.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void PathsWithSum_Should_Check_Length_One_True()
        {
            //arrange
            var tree = new MyBinarySearchTree<int>();
            tree.Insert(5);

            //act
            var result = _treesGraphs.PathsWithSum(tree, 5);

            //assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void PathsWithSum_Should_Check_Multiple_Depth()
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
            tree.Insert(-10);
            
            //act
            var result = _treesGraphs.PathsWithSum(tree, 25);

            //assert
            result.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void PathsWithSum_Should_Check_Different_Depth()
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
            tree.Insert(-10);

            //act
            var result = _treesGraphs.PathsWithSum(tree, 13);

            //assert
            result.ShouldBeEquivalentTo(3);
        }
    }
}
