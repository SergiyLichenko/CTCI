using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Tasks.SortingNSearching;
using Xunit;

namespace Tasks.UT.SortingNSearching
{
    public class SortingNSearchingTests
    {
        private readonly Tasks.SortingNSearching.SortingNSearching _sortingNSearching;
        public SortingNSearchingTests()
        {
            _sortingNSearching = new Tasks.SortingNSearching.SortingNSearching();
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

        [Fact]
        public void GroupAnagrams_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.GroupAnagrams(null);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void GroupAnagrams_Should_Check_Empty()
        {
            //Arrange
            var words = new string[0];

            //Act
            var result = _sortingNSearching.GroupAnagrams(words);

            //Assert
            result.ShouldBeEquivalentTo(words);
        }

        [Fact]
        public void GroupAnagrams_Should_Check_Sorted_Anagrams()
        {
            //Arrange
            var words = new string[10] { "abvc", "bf", "fb", "fb", "bcab", "cvba", "sdf", "fds", "s", "sssaa" };
            var resultWords = new string[10] { "s", "bf", "fb", "fb", "sdf", "fds", "abvc", "bcab", "cvba", "sssaa" };

            //Act
            var result = _sortingNSearching.GroupAnagrams(words);

            //Assert
            result.SequenceEqual(resultWords).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void SearchInRotatedArray_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.SearchInRotatedArray(null, 1);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SearchInRotatedArray_Should_Check_Example()
        {
            //Arrange
            var array = new int[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };

            //Act
            var result = _sortingNSearching.SearchInRotatedArray(array, 5);

            //Assert
            result.ShouldBeEquivalentTo(8);
        }


        [Fact]
        public void SearchInRotatedArray_Should_Check_Not_Contains()
        {
            //Arrange
            var array = new int[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 };

            //Act
            var result = _sortingNSearching.SearchInRotatedArray(array, 2);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void SearchInRotatedArray_Should_Check_If_Empty()
        {
            //Arrange
            var array = new int[0];

            //Act
            Action act = () => _sortingNSearching.SearchInRotatedArray(array, 2);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SearchInRotatedArray_Should_Check_Not_Rotated()
        {
            //Arrange
            var array = new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 };

            //Act
            var result = _sortingNSearching.SearchInRotatedArray(array, 8);

            //Assert
            result.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void SearchInRotatedArray_Should_Check_Max_Element_Right_Side()
        {
            //Arrange
            var array = new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10, -1, 0 };

            //Act
            var result = _sortingNSearching.SearchInRotatedArray(array, 2);

            //Assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void SearchInRotatedArray_Should_Check_Duplicates()
        {
            //Arrange
            var array = new int[] { 1, 2, 4, 5, 6, 6, 6, 7, 8, 8, 9, 9, 9, 10, -1, 0 };

            //Act
            var result = _sortingNSearching.SearchInRotatedArray(array, 9);

            //Assert
            result.ShouldBeEquivalentTo(11);
        }

        [Fact]
        public void SortedSearchNoSize_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.SortedSearchNoSize(null, 2);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void SortedSearchNoSize_Should_Throw_If_Target_Negative()
        {
            //Act
            Action act = () => _sortingNSearching.SortedSearchNoSize(new Listy(), -2);

            //Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SortedSearchNoSize_Should_Find_Value()
        {
            //Arrange
            var listy = new Listy();
            listy[0] = 0;
            listy[1] = 1;
            listy[2] = 2;
            listy[3] = 3;
            listy[4] = 4;
            listy[5] = 5;
            listy[6] = 6;
            listy[7] = 7;
            listy[8] = 8;
            listy[9] = 9;
            listy[10] = 10;

            //Act
            var result = _sortingNSearching.SortedSearchNoSize(listy, 7);

            //Assert
            result.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void SortedSearchNoSize_Should_Find_Value_With_Duplicates()
        {
            //Arrange
            var listy = new Listy();
            listy[0] = 0;
            listy[1] = 1;
            listy[2] = 1;
            listy[3] = 3;
            listy[4] = 4;
            listy[5] = 4;
            listy[6] = 4;
            listy[7] = 7;
            listy[8] = 8;
            listy[9] = 8;
            listy[10] = 9;
            listy[11] = 9;

            //Act
            var result = _sortingNSearching.SortedSearchNoSize(listy, 8);

            //Assert
            result.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void SortedSearchNoSize_Should_Not_Find_Value_If_No_Exists()
        {
            //Arrange
            var listy = new Listy();
            listy[0] = 0;
            listy[1] = 1;
            listy[2] = 1;
            listy[3] = 3;
            listy[4] = 4;
            listy[5] = 4;
            listy[6] = 4;
            listy[7] = 7;
            listy[8] = 8;
            listy[9] = 8;
            listy[10] = 9;
            listy[11] = 9;

            //Act
            var result = _sortingNSearching.SortedSearchNoSize(listy, 10);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }


        [Fact]
        public void SparseSearch_Should_Search_In_Left_Side()
        {
            //Arrange
            var target = "ball";
            var words = new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };

            //Act
            var result = _sortingNSearching.SparseSearch(words, target);

            //Assert
            result.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void SparseSearch_Should_Search_In_Right_Side()
        {
            //Arrange
            var target = "dad";
            var words = new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };

            //Act
            var result = _sortingNSearching.SparseSearch(words, target);

            //Assert
            result.ShouldBeEquivalentTo(10);
        }

        [Fact]
        public void SparseSearch_Should_Not_Find_If_Not_Contains()
        {
            //Arrange
            var target = "bull";
            var words = new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };

            //Act
            var result = _sortingNSearching.SparseSearch(words, target);

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void SparseSearch_Should_Throw_If_Target_Is_Empty_String()
        {
            //Arrange
            var target = "";
            var words = new string[] { "ball" };

            //Act
            Action act = () => _sortingNSearching.SparseSearch(words, target);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SparseSearch_Should_Throw_If_Words_Are_Empty()
        {
            //Arrange
            var target = "str";
            var words = new string[] { };

            //Act
            Action act = () => _sortingNSearching.SparseSearch(words, target);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SparseSearch_Should_Throw_If_Null()
        {
            //Arrange
            var str = "str";
            var words = new string[] { "word" };
            //Act
            Action actFirst = () => _sortingNSearching.SparseSearch(null, str);
            Action actSecond = () => _sortingNSearching.SparseSearch(words, null);

            //Assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SparseSearch_Should_Check_Left_Side_Full_Empty_Strings()
        {
            //Arrange
            var str = "dad";
            var words = new string[] { "", "", "", "", "", "", "", "car", "", "", "dad", "", "" };

            //Act
            var result = _sortingNSearching.SparseSearch(words, str);

            //Assert
            result.ShouldBeEquivalentTo(10);
        }

        [Fact]
        public void SparseSearch_Should_Check_Right_Side_Full_Empty_Strings()
        {
            //Arrange
            var str = "car";
            var words = new string[] { "", "car", "", "dad", "", "", "", "", "", "", "", "", "" };

            //Act
            var result = _sortingNSearching.SparseSearch(words, str);

            //Assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void MissingInt_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.MissingInt(null);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MissingInt_Should_Check_Million()
        {
            //Arrange
            var mass = Enumerable.Range(0, 1000000).Select(x => (uint)x).ToList();


            //Act
            var result = _sortingNSearching.MissingInt(mass.ToArray());

            //Assert
            result.ShouldBeEquivalentTo(1000000);
        }

        [Fact]
        public void MissingInt_Should_Check_First_Million()
        {
            //Arrange
            var mass = Enumerable.Range(1000000, 1000000).Select(x => (uint)x).ToList();


            //Act
            var result = _sortingNSearching.MissingInt(mass.ToArray());

            //Assert
            result.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void FindDuplicates_Should_Find_Duplicates()
        {
            //Arrange
            int count = 50000;
            var list = new List<int>(count);
            var random = new Random();
            var upperBound = 32000;

            for (int i = 0; i < count; i++)
                list.Add(random.Next(upperBound));
            var duplicates = list.GroupBy(x => x)
                 .ToDictionary(x => x, x => x.Count())
                 .Where(x => x.Value > 1)
                 .Select(x => x.Key).ToArray();

            //Act
            var result = _sortingNSearching.FindDuplicates(list.ToArray()).ToArray();

            //Assert

            duplicates.Select(x => x.Key)
                .OrderBy(x => x)
                .SequenceEqual(result.OrderBy(x => x))
                .ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void FindDuplicates_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.FindDuplicates(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void FindDuplicates_Should_Check_No_Duplicates()
        {
            //Arrange
            var upperBound = 32000;
            var array = Enumerable.Range(0, upperBound).ToArray();

            //Act
            var result = _sortingNSearching.FindDuplicates(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void SortedMatrixSearch_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.SortedMatrixSearch(null, 0);

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SortedMatrixSearch_Should_Throw_Matrix_Zero_Length()
        {
            //Arrange
            var matrix = new int[0, 0];

            //Act
            Action act = () => _sortingNSearching.SortedMatrixSearch(matrix, 0);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void SortedMatrixSearch_Should_Find_Element_True()
        {
            //Arrange
            var matrix = new int[,]
            {
                {1, 6, 7, 8, 9, 10},
                {2, 11, 15, 16, 17, 18},
                {3, 12, 19, 22, 23, 24},
                {4, 13, 20, 25, 27, 28},
                {5, 14, 21, 26, 29, 30}
            };

            //Assert
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    var result = _sortingNSearching.SortedMatrixSearch(
                        matrix, matrix[i, j]);
                    result[0].ShouldBeEquivalentTo(i);
                    result[1].ShouldBeEquivalentTo(j);
                }
            }
        }

        [Fact]
        public void SortedMatrixSearch_Should_Find_Element_False()
        {
            //Arrange
            var matrix = new int[,]
            {
                {1, 6, 7, 8, 9, 10},
                {2, 11, 15, 16, 17, 18},
                {3, 12, 19, 22, 23, 24},
                {4, 13, 20, 25, 27, 28},
                {5, 14, 21, 26, 29, 30}
            };

            //Act
            var result = _sortingNSearching.SortedMatrixSearch(matrix, 31);

            //Assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void SortedMatrixSearch_Should_Find_Element_With_Duplicates()
        {
            //Arrange
            var matrix = new int[,]
            {
                {1, 6, 6, 8, 9, 10},
                {2, 6, 15, 16, 17, 18},
                {3, 6, 20, 20, 20, 24},
                {4, 6, 20, 25, 27, 28},
                {5, 14, 20, 26, 29, 30}
            };

            //Act
            var result = _sortingNSearching.SortedMatrixSearch(matrix, 29);

            //Assert
            result[0].ShouldBeEquivalentTo(4);
            result[1].ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void PeaksAndValleys_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _sortingNSearching.PeaksAndValleys(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PeaksAndValleys_Should_Check_Example()
        {
            //Arrange
            var array = new int[] { 5, 3, 1, 2, 3 };

            //Act
            var result = _sortingNSearching.PeaksAndValleys(array).ToArray();

            //Assert
            bool isPeak = false;
            for (int i = 1; i < result.Length; i++)
            {
                if (isPeak)
                    result[i].Should().BeGreaterOrEqualTo(result[i - 1]);
                else
                    result[i].Should().BeLessOrEqualTo(result[i - 1]);
                isPeak = !isPeak;
            }
        }

        [Fact]
        public void PeaksAndValleys_Should_Check_Random()
        {
            //Arrange
            int count = 1000000;
            var random = new Random();
            var array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = random.Next();

            //Act
            var result = _sortingNSearching.PeaksAndValleys(array).ToArray();

            //Assert
            bool isPeak = false;
            for (int i = 1; i < result.Length; i++)
            {
                if (isPeak)
                    result[i].Should().BeGreaterOrEqualTo(result[i - 1]);
                else
                    result[i].Should().BeLessOrEqualTo(result[i - 1]);
                isPeak = !isPeak;
            }
        }

        [Fact]
        public void PeaksAndValleys_Should_Check_Empty()
        {
            //Arrange
            var array = new int[0];

            //Act
            var result = _sortingNSearching.PeaksAndValleys(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void PeaksAndValleys_Should_Check_Length_One()
        {
            //Arrange
            var array = new int[1] { 5 };

            //Act
            var result = _sortingNSearching.PeaksAndValleys(array).ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(array[0]);
        }
    }
}
