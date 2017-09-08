using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class SortingNSearchingTests
    {
        private readonly SortingNSearching _sortingNSearching;
        public SortingNSearchingTests()
        {
            _sortingNSearching = new SortingNSearching();
        }

        [Fact]
        public void SortedMerge_Should_Throw_If_Null()
        {
            //Arrage

            //Act
            Action actFirst = () => _sortingNSearching.SortedMerge(null, new[] { 0 }, 0);
            Action actSecond = () => _sortingNSearching.SortedMerge(new int[] { 0 }, null, 0);

            //Assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SortedMerge_Should_Throw_If_Not_Enought_Buffer()
        {
            //Arrage
            var first = new int[5];
            var second = new int[3];

            //Act
            Action act = () => _sortingNSearching.SortedMerge(first, second, 3);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SortedMerge_Should_Throw_If_StartBufferIndex_Not_In_Range()
        {
            //Arrage
            var first = new int[5];
            var second = new int[3];

            //Act
            Action actLower = () => _sortingNSearching.SortedMerge(first, second, -1);
            Action actHigher = () => _sortingNSearching.SortedMerge(first, second, first.Length + 1);

            //Assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SortedMerge_Should_Throw_If_Array_Not_Sorted()
        {
            //Arrage
            var first = new int[5] { 3, 2, 0, 0, 0 };
            var second = new int[3] { 4, 3, 5 };

            //Act
            Action actLower = () => _sortingNSearching.SortedMerge(first, second, 2);
            Action actHigher = () => _sortingNSearching.SortedMerge(first, second, 2);

            //Assert
            actLower.ShouldThrow<ArgumentException>();
            actHigher.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SortedMerge_Should_Check_First_Empty()
        {
            //Arrage
            var first = new int[5] { 0, 0, 0, 0, 0 };
            var second = new int[3] { 3, 4, 5 };
            var arrayResult = new int[5] { 3, 4, 5, 0, 0 };

            //Act
            var result = _sortingNSearching.SortedMerge(first, second, 0);

            //Assert
            result.SequenceEqual(arrayResult).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void SortedMerge_Should_Check_Second_Empty()
        {
            //Arrage
            var first = new int[5] { 1, 2, 3, 4, 5 };
            var second = new int[0] { };
            var arrayResult = new int[5] { 1, 2, 3, 4, 5 };

            //Act
            var result = _sortingNSearching.SortedMerge(first, second, first.Length);

            //Assert
            result.SequenceEqual(arrayResult).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void SortedMerge_Should_Check_Merge()
        {
            //Arrage
            var first = new int[5] { 3, 5, 8, 0, 0 };
            var second = new int[2] { 1, 6 };
            var arrayResult = new int[5] { 1, 3, 5, 6, 8 };

            //Act
            var result = _sortingNSearching.SortedMerge(first, second, 3);

            //Assert
            result.SequenceEqual(arrayResult).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void SortedMerge_Should_Not_Modify_Initial_Array()
        {
            //Arrage
            var first = new int[5] { 3, 5, 8, 0, 0 };
            var second = new int[2] { 1, 6 };
            var arrayResult = new int[5] { 1, 3, 5, 6, 8 };

            var firstCopy = new int[5];
            var secondCopy = new int[2];
            Array.Copy(first, firstCopy, first.Length);
            Array.Copy(second, secondCopy, second.Length);

            //Act
            var result = _sortingNSearching.SortedMerge(first, second, 3);

            //Assert
            result.SequenceEqual(arrayResult).ShouldBeEquivalentTo(true);
            first.SequenceEqual(firstCopy).ShouldBeEquivalentTo(true);
            second.SequenceEqual(secondCopy).ShouldBeEquivalentTo(true);
        }
    }
}
