using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Algorithms.UT
{
    public class SortingTests
    {
        private readonly Sorting _sorting;
        private readonly Random _random;
        public SortingTests()
        {
            _sorting = new Sorting();
            _random = new Random();
        }

        [Fact]
        public void BubbleSort_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _sorting.BubbleSort(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void BubbleSort_Should_Sort()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000).ToArray();
            array = array.OrderBy(x => _random.Next()).ToArray();

            //Act
            var result = _sorting.BubbleSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(array.Length);
            result.SequenceEqual(array.OrderBy(x => x)).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void BubbleSort_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _sorting.BubbleSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(0);
        }
    }
}
