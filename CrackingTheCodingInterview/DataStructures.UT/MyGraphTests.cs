using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyGraphTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange
            int capacity = 5;

            //act
            var graph = new MyGraph<int>(capacity);

            //assert
            graph.Capacity.ShouldBeEquivalentTo(capacity);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_Default_Throw_If_Capacity_Negative()
        {
            //arrange
            int capacity = -5;

            //act
            Action act = () => new MyGraph<int>(capacity);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_AddVertex()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            graph.AddVertex(0, 1);

            //assert
            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_AddVertex_Throw_If_Out_Of_Range()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action actLower = () => graph.AddVertex(-1, 1);
            Action actHigher = () => graph.AddVertex(6, 1);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_AddEdge_Throw_If_Out_Of_Range()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action actLowerFrom = () => graph.AddEdge(-1, 1);
            Action actHigherFrom = () => graph.AddEdge(6, 1);

            Action actLowerTo = () => graph.AddEdge(1, -1);
            Action actHigherTo = () => graph.AddEdge(1, 6);

            //assert
            actLowerFrom.ShouldThrow<ArgumentOutOfRangeException>();
            actHigherFrom.ShouldThrow<ArgumentOutOfRangeException>();
            actLowerTo.ShouldThrow<ArgumentOutOfRangeException>();
            actHigherTo.ShouldThrow<ArgumentOutOfRangeException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_BreadthFirstSearch_Throw_If_Out_Of_Range_Index()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action actLower = () => graph.BreadthFirstSearch(-1).ToArray();
            Action actHigher = () => graph.BreadthFirstSearch(6).ToArray();

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_BreadthFirstSearch_Throw_If_Node_Is_Null()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action act = () => graph.BreadthFirstSearch(1).ToArray();

            //assert
            act.ShouldThrow<ArgumentException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_BreadthFirstSearch()
        {
            //arrange
            var graph = new MyGraph<int>(6);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);

            graph.AddEdge(0, 5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 1);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 4);

            var resBfs = new[] { 0, 5, 1, 4, 3, 2 };

            //act
            var result = graph.BreadthFirstSearch(0).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(resBfs.Length);
            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(resBfs[i]);

            graph.Capacity.ShouldBeEquivalentTo(6);
            graph.Count.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void Should_BreadthFirstSearch_Length_One()
        {
            //arrange
            var graph = new MyGraph<int>(6);
            graph.AddVertex(0, 0);

            //act
            var result = graph.BreadthFirstSearch(0).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(0);

            graph.Capacity.ShouldBeEquivalentTo(6);
            graph.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_DepthFirstSearch_Throw_If_Out_Of_Range_Index()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action actLower = () => graph.DepthFirstSearch(-1).ToArray();
            Action actHigher = () => graph.DepthFirstSearch(6).ToArray();

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_DepthFirstSearch_Throw_If_Node_Is_Null()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action act = () => graph.DepthFirstSearch(1).ToArray();

            //assert
            act.ShouldThrow<ArgumentException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_DepthFirstSearch()
        {
            //arrange
            var graph = new MyGraph<int>(6);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);

            graph.AddEdge(0, 5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 1);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 4);

            var resDfs = new[] { 0, 4, 1, 3, 2, 5 };

            //act
            var result = graph.DepthFirstSearch(0).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(resDfs.Length);
            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(resDfs[i]);

            graph.Capacity.ShouldBeEquivalentTo(6);
            graph.Count.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void Should_DepthFirstSearch_Length_One()
        {
            //arrange
            var graph = new MyGraph<int>(6);
            graph.AddVertex(0, 0);

            //act
            var result = graph.DepthFirstSearch(0).ToArray();

            //assert
            result.Length.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(0);

            graph.Capacity.ShouldBeEquivalentTo(6);
            graph.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_BidirectionalSearch_Throw_If_Out_Of_Range()
        {
            //arrange
            var graph = new MyGraph<int>(5);

            //act
            Action actLowerFrom = () => graph.BidirectionalSearch(-1, 1);
            Action actHigherFrom = () => graph.BidirectionalSearch(6, 1);

            Action actLowerTo = () => graph.BidirectionalSearch(1, -1);
            Action actHigherTo = () => graph.BidirectionalSearch(1, 6);

            //assert
            actLowerFrom.ShouldThrow<ArgumentOutOfRangeException>();
            actHigherFrom.ShouldThrow<ArgumentOutOfRangeException>();
            actLowerTo.ShouldThrow<ArgumentOutOfRangeException>();
            actHigherTo.ShouldThrow<ArgumentOutOfRangeException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_BidirectionalSearch_Throw_If_Node_Is_Null()
        {
            //arrange
            var graph = new MyGraph<int>(5);
            graph.AddVertex(0, 0);

            //act
            Action actFrom = () => graph.BidirectionalSearch(1, 0).ToArray();
            Action actTo = () => graph.BidirectionalSearch(0, 1).ToArray();

            //assert
            actFrom.ShouldThrow<ArgumentException>();
            actTo.ShouldThrow<ArgumentException>();

            graph.Capacity.ShouldBeEquivalentTo(5);
            graph.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_BidirectionalSearch()
        {
            //arrange
            var graph = new MyGraph<int>(15);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);
            graph.AddVertex(6, 6);
            graph.AddVertex(7, 7);
            graph.AddVertex(8, 8);
            graph.AddVertex(9, 9);
            graph.AddVertex(10, 10);
            graph.AddVertex(11, 11);
            graph.AddVertex(12, 12);
            graph.AddVertex(13, 13);
            graph.AddVertex(14, 14);

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
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 6);
            graph.AddEdge(7, 8);
            graph.AddEdge(8, 7);
            graph.AddEdge(8, 9);
            graph.AddEdge(8, 10);
            graph.AddEdge(9, 8);
            graph.AddEdge(9, 11);
            graph.AddEdge(9, 12);
            graph.AddEdge(10, 8);
            graph.AddEdge(10, 13);
            graph.AddEdge(10, 14);
            graph.AddEdge(11, 9);
            graph.AddEdge(12, 9);
            graph.AddEdge(13, 10);
            graph.AddEdge(14, 10);

            var fromSearch = new[] { 1, 4, 0, 6, 5, 7 };
            var toSearch = new[] { 14, 10, 8, 13, 7, 9 };

            //act
            var result = graph.BidirectionalSearch(1, 14);

            //assert
            result[0].Count().ShouldBeEquivalentTo(fromSearch.Length);
            result[1].Count().ShouldBeEquivalentTo(toSearch.Length);

            for (int i = 0; i < fromSearch.Length; i++)
                fromSearch[i].ShouldBeEquivalentTo(result[0].ElementAt(i));
            for (int i = 0; i < toSearch.Length; i++)
                toSearch[i].ShouldBeEquivalentTo(result[1].ElementAt(i));

            graph.Capacity.ShouldBeEquivalentTo(15);
            graph.Count.ShouldBeEquivalentTo(15);
        }

        [Fact]
        public void Should_BidirectionalSearch_False()
        {
            //arrange
            var graph = new MyGraph<int>(15);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);
            graph.AddVertex(4, 4);
            graph.AddVertex(5, 5);
            graph.AddVertex(6, 6);

            graph.AddVertex(8, 8);
            graph.AddVertex(9, 9);
            graph.AddVertex(10, 10);
            graph.AddVertex(11, 11);
            graph.AddVertex(12, 12);
            graph.AddVertex(13, 13);
            graph.AddVertex(14, 14);

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
            graph.AddEdge(8, 9);
            graph.AddEdge(8, 10);
            graph.AddEdge(9, 8);
            graph.AddEdge(9, 11);
            graph.AddEdge(9, 12);
            graph.AddEdge(10, 8);
            graph.AddEdge(10, 13);
            graph.AddEdge(10, 14);
            graph.AddEdge(11, 9);
            graph.AddEdge(12, 9);
            graph.AddEdge(13, 10);
            graph.AddEdge(14, 10);

            //act
            var result = graph.BidirectionalSearch(1, 14);

            //assert
            result.ShouldBeEquivalentTo(null);

            graph.Capacity.ShouldBeEquivalentTo(15);
            graph.Count.ShouldBeEquivalentTo(14);
        }

        [Fact]
        public void Should_BidirectionalSearch_Length_One()
        {
            //arrange
            var graph = new MyGraph<int>(1);
            graph.AddVertex(0, 0);

            //act
            var result = graph.BidirectionalSearch(0, 0);

            //assert
            result[0].Count().ShouldBeEquivalentTo(1);
            result[1].Count().ShouldBeEquivalentTo(1);

            result[0].ElementAt(0).ShouldBeEquivalentTo(0);
            result[1].ElementAt(0).ShouldBeEquivalentTo(0);

            graph.Capacity.ShouldBeEquivalentTo(1);
            graph.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Remove()
        {
            //arrange
            var graph = new MyGraph<int>(4);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);

            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 2);

            //act
            graph.Remove(2);

            var first = graph.BreadthFirstSearch(0).ToArray();
            var second = graph.BreadthFirstSearch(1).ToArray();
            var third = graph.BreadthFirstSearch(3).ToArray();
            Action act = () => graph.BreadthFirstSearch(2).ToArray();

            //assert
            first.Length.ShouldBeEquivalentTo(1);
            second.Length.ShouldBeEquivalentTo(1);
            third.Length.ShouldBeEquivalentTo(1);

            first[0].ShouldBeEquivalentTo(0);
            second[0].ShouldBeEquivalentTo(1);
            third[0].ShouldBeEquivalentTo(3);

            act.ShouldThrow<ArgumentException>();

            graph.Capacity.ShouldBeEquivalentTo(4);
            graph.Count.ShouldBeEquivalentTo(3);
        }
    }
}
