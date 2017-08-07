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
            var values = new int[] {1};
            //act
           var result =  _treesGraphs.MinimalTree(values);

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result.Root.Data.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void MinimalTree_Should_Create_Empty()
        {
            //arrange
            var values = new int[] {  };
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
            var values = new int[] {1,2,3,4,5,6,7 };
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
    }
}
