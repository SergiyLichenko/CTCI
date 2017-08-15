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
        private readonly Johnson _jonson;

        public JohnsonTests()
        {
            _jonson = new Johnson();
        }

        [Fact]
        public void Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _jonson.Compute(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_If_Not_Weighted()
        {
            //arrange
            var graph = new MyGraphAdj<int>(5);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(0, 1);

            //act
            Action act = () => _jonson.Compute(graph);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Check_Example()
        {
            //arrange
            var graph = new MyGraphAdj<int>(5, true);
            graph.AddVertex(0, 0);
            graph.AddVertex(1, 1);
            graph.AddVertex(2, 2);
            graph.AddVertex(3, 3);

            graph.AddEdge(0, 1, -5);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(0, 3, 3);
            graph.AddEdge(1, 2, 4);
            graph.AddEdge(2, 3, 1);

            //act
            var result =  _jonson.Compute(graph);

            //assert
            


        }
    }
}
