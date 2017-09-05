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
        private readonly Sorting<int> _sorting;
        private readonly Random _random;
        public SortingTests()
        {
            _sorting = new Sorting<int>();
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

        [Fact]
        public void SelectionSort_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _sorting.SelectionSort(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SelectionSort_Should_Sort()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000).ToArray();
            array = array.OrderBy(x => _random.Next()).ToArray();

            //Act
            var result = _sorting.SelectionSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(array.Length);
            result.SequenceEqual(array.OrderBy(x => x)).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void SelectionSort_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _sorting.SelectionSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void MergeSort_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _sorting.MergeSort(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MergeSort_Should_Sort()
        {
            //Arrange
            var array = Enumerable.Range(0, 1000).ToArray();
            array = array.OrderBy(x => _random.Next()).ToArray();

            //Act
            var result = _sorting.MergeSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(array.Length);
            result.SequenceEqual(array.OrderBy(x => x)).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void MergeSort_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _sorting.MergeSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void QuickSort_Should_Throw_If_Null()
        {
            //Arrange

            //Act
            Action act = () => _sorting.QuickSort(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void QuickSort_Should_Sort()
        {
            //Arrange
            var array = Enumerable.Range(0, 5).ToArray();
            array = array.OrderBy(x => _random.Next()).ToArray();

            //Act
            var result = _sorting.QuickSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(array.Length);
            result.SequenceEqual(array.OrderBy(x => x)).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void QuickSort_Should_Check_Empty()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = _sorting.QuickSort(array).ToList();

            //Assert
            result.Count.ShouldBeEquivalentTo(0);
        }
    }
}
