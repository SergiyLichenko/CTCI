using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures;
using FluentAssertions;
using Xunit;

namespace Algorithms.UT
{
    public class JohnsonTests
    {
        private readonly Johnson<char> _jonson;

        public JohnsonTests()
        {
            _jonson = new Johnson<char>();
        }

        [Fact]
        public void Should_Throw_If_Null()
        {
            //arrange
            MyGraphAdj<char> graph = null;

            //act
            Action act = () => _jonson.Compute(graph);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_If_Not_Weighted()
        {
            //arrange
            var graph = new MyGraphAdj<char>(5);
            graph.AddVertex(0, '0');
            graph.AddVertex(1, '1');
            graph.AddVertex(0, '1');

            //act
            Action act = () => _jonson.Compute(graph);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Check_Example()
        {
            //arrange
            var graph = new MyGraphAdj<char>(5, true);
            graph.AddVertex(0, 'A');
            graph.AddVertex(1, 'B');
            graph.AddVertex(2, 'C');
            graph.AddVertex(3, 'D');

            graph.AddEdge(0, 1, -5);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(0, 3, 3);
            graph.AddEdge(1, 2, 4);
            graph.AddEdge(2, 3, 1);

            var distances = new int[,]
            {
                { 0, -5, -1, 0},
                {Int32.MaxValue, 0, 4, 5 },
                {Int32.MaxValue, Int32.MaxValue,0,1 },
                {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0 }
            };

            //act
            var result = _jonson.Compute(graph);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(distances.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(distances.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j].ShouldBeEquivalentTo(distances[i, j]);
        }

        [Fact]
        public void Should_Check_Dijkstra_Negative_Edges()
        {
            //arrange
            var graph = new MyGraphAdj<char>(6, true);
            graph.AddVertex(0, 'A');
            graph.AddVertex(1, 'B');
            graph.AddVertex(2, 'C');
            graph.AddVertex(3, 'D');
            graph.AddVertex(4, 'E');
            graph.AddVertex(5, 'F');

            graph.AddEdge(0, 1, -7);
            graph.AddEdge(0, 3, 7);
            graph.AddEdge(0, 4, 5);
            graph.AddEdge(1, 0, 8);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 1, 2);
            graph.AddEdge(2, 3, 3);
            graph.AddEdge(3, 2, -3);
            graph.AddEdge(3, 0, 5);
            graph.AddEdge(3, 5, 6);
            graph.AddEdge(5, 3, 4);
            graph.AddEdge(5, 4, 8);
            graph.AddEdge(4, 0, -3);
            graph.AddEdge(4, 5, -1);

            var distances = new int[,]
            {
                {0,-7,-6,-3,5,3 },
                {8,0,1,4,13,10 },
                {8,1,0,3,13,9 },
                {5,-2,-3,0,10,6 },
                {-3,-10,-9,-6,0,-1 },
                {5,-2,-1,2,8,0 }
            };

            //act
            var result = _jonson.Compute(graph);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(distances.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(distances.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j].ShouldBeEquivalentTo(distances[i, j]);
        }

        [Fact]
        public void Should_Check_Empty_Graph()
        {
            //arrange
            var graph = new MyGraphAdj<char>(6, true);

            //act
            var result = _jonson.Compute(graph);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(0);
            result.GetLength(1).ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Check_Graph_No_Edges()
        {
            //arrange
            var graph = new MyGraphAdj<char>(3, true);
            graph.AddVertex(0, 'A');
            graph.AddVertex(1, 'B');
            graph.AddVertex(2, 'C');

            var distances = new int[,]
            {
                {0, Int32.MaxValue, Int32.MaxValue},
                {Int32.MaxValue, 0, Int32.MaxValue},
                {Int32.MaxValue, Int32.MaxValue, 0}
            };

            //act
            var result = _jonson.Compute(graph);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(distances.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(distances.GetLength(1));

            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j].ShouldBeEquivalentTo(distances[i, j]);
        }

        [Fact]
        public void Should_Check_Negative_Cycle_Simple()
        {
            //arrange
            var graph = new MyGraphAdj<char>(2, true);
            graph.AddVertex(0, 'A');
            graph.AddVertex(1, 'B');

            graph.AddEdge(0, 1, -3);
            graph.AddEdge(1, 0, -5);

            //act
            Action act = () => _jonson.Compute(graph);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Negative_Cycle_Complex()
        {
            //arrange
            var graph = new MyGraphAdj<char>(6, true);
            graph.AddVertex(0, 'A');
            graph.AddVertex(1, 'B');
            graph.AddVertex(2, 'C');
            graph.AddVertex(3, 'D');
            graph.AddVertex(4, 'E');
            graph.AddVertex(5, 'F');

            graph.AddEdge(0, 1, -7);
            graph.AddEdge(0, 3, 7);
            graph.AddEdge(0, 4, 5);
            graph.AddEdge(1, 0, 8);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 1, 2);
            graph.AddEdge(2, 3, 3);
            graph.AddEdge(3, 2, -3);
            graph.AddEdge(3, 0, 5);
            graph.AddEdge(3, 5, -6);
            graph.AddEdge(5, 3, 4);
            graph.AddEdge(5, 4, 1);
            graph.AddEdge(4, 0, -3);
            graph.AddEdge(4, 5, -1);

            //act
            Action act = ()=> _jonson.Compute(graph);

            //assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}
