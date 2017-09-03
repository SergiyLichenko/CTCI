using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Algorithms.UT
{
    public class SearchingTests
    {
        private readonly Searching<int> _searching;
        public SearchingTests()
        {
            _searching = new Searching<int>();
        }

        [Fact]
        public void BinarySearchIterative_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _searching.BinarySearchIterative(null, 1);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BinarySearchIterative_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _searching.BinarySearchIterative(array, 0);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void BinarySearchIterative_Should_Return_False_If_Not_Contains()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000000).ToArray();

            //Act
            var result = _searching.BinarySearchIterative(array, -5);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void BinarySearchIterative_Should_Check_Search_True()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000000).ToArray();
            int item = 555555;
            var index = Array.FindIndex(array, 0, x => x == item);

            //Act
            var result = _searching.BinarySearchIterative(array, item);

            //Assert
            result.ShouldBeEquivalentTo(index);
        }

        [Fact]
        public void BinarySearchRecursive_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _searching.BinarySearchRecursive(null, 1);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BinarySearchRecursive_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _searching.BinarySearchRecursive(array, 0);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void BinarySearchRecursive_Should_Return_False_If_Not_Contains()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000000).ToArray();

            //Act
            var result = _searching.BinarySearchRecursive(array, -5);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void BinarySearchRecursive_Should_Check_Search_True()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000000).ToArray();
            int item = 555555;
            var index = Array.FindIndex(array, 0, x => x == item);

            //Act
            var result = _searching.BinarySearchRecursive(array, item);

            //Assert
            result.ShouldBeEquivalentTo(index);
        }
    }
}
