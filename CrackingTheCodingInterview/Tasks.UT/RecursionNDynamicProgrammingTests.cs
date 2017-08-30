using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class RecursionNDynamicProgrammingTests
    {
        public RecursionNDynamicProgrammingTests()
        {
            _recursionNDynamicProgramming = new RecursionNDynamicProgramming();
        }
        private readonly RecursionNDynamicProgramming _recursionNDynamicProgramming;

        [Fact]
        public void Triple_Step_Should_Check_First_Three()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(1);
            var second = _recursionNDynamicProgramming.TripleStep(2);
            var third = _recursionNDynamicProgramming.TripleStep(3);

            //assert
            first.ShouldBeEquivalentTo(1);
            second.ShouldBeEquivalentTo(2);
            third.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Triple_Step_Should_Throw_If_Not_In_Range()
        {
            //arrange

            //act
            Action actZero = () => _recursionNDynamicProgramming.TripleStep(0);
            Action actNegative = () => _recursionNDynamicProgramming.TripleStep(-1);

            //assert
            actZero.ShouldThrow<ArgumentOutOfRangeException>();
            actNegative.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Triple_Step_Should_Check_Example()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(4);

            //assert
            first.ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Triple_Step_Should_Check_Example_Higher()
        {
            //arrange

            //act
            var first = _recursionNDynamicProgramming.TripleStep(6);

            //assert
            first.ShouldBeEquivalentTo(24);
        }

        [Fact]
        public void MagicIndex_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _recursionNDynamicProgramming.MagicIndex(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void MagicIndex_Should_Check_Middle()
        {
            //arrange
            int[] array = new int[] { -1, 0, 2, 5, 6 };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void MagicIndex_Should_Check_Example()
        {
            //arrange
            int[] array = new int[] { -1, 0, 1, 2, 4, 8, 9, 10 };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void MagicIndex_Should_Check_Example_With_Duplicates_Right()
        {
            //arrange
            int[] array = new int[] { 1, 3, 3, 5, 5, 5 };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(5);
        }
        [Fact]
        public void MagicIndex_Should_Check_Example_With_Duplicates_Left()
        {
            //arrange
            int[] array = new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void MagicIndex_Should_Check_False()
        {
            //arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(-1);
        }


        [Fact]
        public void MagicIndex_Should_Check_Empty()
        {
            //arrange
            int[] array = new int[] { };

            //act
            var result = _recursionNDynamicProgramming.MagicIndex(array);

            //assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void RecursiveMutliply_Should_Check_Zero()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.RecursiveMutliply(10, 0);

            //assert
            result.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void RecursiveMutliply_Should_Two_Odd_Numbers()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.RecursiveMutliply(9, 7);

            //assert
            result.ShouldBeEquivalentTo(63);
        }

        [Fact]
        public void RecursiveMutliply_Should_Check_Odd_And_Even_Numbers()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.RecursiveMutliply(7, 10);

            //assert
            result.ShouldBeEquivalentTo(70);
        }

        [Fact]
        public void RecursiveMutliply_Should_Check_Even_And_Odd_Numbers()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.RecursiveMutliply(6, 5);

            //assert
            result.ShouldBeEquivalentTo(30);
        }

        [Fact]
        public void RecursiveMutliply_Should_Check_Even_Numbers()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.RecursiveMutliply(6, 6);

            //assert
            result.ShouldBeEquivalentTo(36);
        }

        [Fact]
        public void RecursiveMutliply_Should_Throw_If_Negative()
        {
            //arrange

            //act
            Action actFirst = () => _recursionNDynamicProgramming.RecursiveMutliply(-6, 6);
            Action actSecond = () => _recursionNDynamicProgramming.RecursiveMutliply(6, -6);

            //assert
            actFirst.ShouldThrow<ArgumentOutOfRangeException>();
            actSecond.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void TowersOfHanoi_Should_Check_Example()
        {
            //arrange
            var towers = new List<int>[]
            {
                new List<int>(){1,2,3,4,5},
                new List<int>() { },
                new List<int>() { }
            };

            //act
            var result = _recursionNDynamicProgramming.TowersOfHanoi(towers);

            //assert
            result.Length.ShouldBeEquivalentTo(3);
            result[0].Count.ShouldBeEquivalentTo(0);
            result[1].Count.ShouldBeEquivalentTo(0);
            result[2].Count.ShouldBeEquivalentTo(towers[0].Count);
            result[2].SequenceEqual(towers[0]).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void TowersOfHanoi_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => _recursionNDynamicProgramming.TowersOfHanoi(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void TowersOfHanoi_Should_Throw_If_Not_Sorted_By_Ascending()
        {
            //arrange
            var towers = new List<int>[]
            {
                new List<int>(){4,5,32,1},
                new List<int>() { },
                new List<int>() { }
            };
            //act
            Action act = () => _recursionNDynamicProgramming.TowersOfHanoi(towers);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void TowersOfHanoi_Should_Throw_If_Invalid_Number_Of_Towers()
        {
            //arrange
            var towersMore = new List<int>[]
            {
                new List<int>(){4,5,32,1},
                new List<int>() { },
                new List<int>() { },
                new List<int>() { }
            };
            var towersLess = new List<int>[]
            {
                new List<int>(){4,5,32,1},
                new List<int>() { }
            };

            //act
            Action actMore = () => _recursionNDynamicProgramming.TowersOfHanoi(towersMore);
            Action actLess = () => _recursionNDynamicProgramming.TowersOfHanoi(towersLess);

            //assert
            actMore.ShouldThrow<ArgumentException>();
            actLess.ShouldThrow<ArgumentException>();
        }


        [Fact]
        public void TowersOfHanoi_Should_Throw_If_Other_Towers_Are_Not_Empty()
        {
            //arrange
            var towersFirst = new List<int>[]
            {
                new List<int>(){ },
                new List<int>() { 1},
                new List<int>() { }
            };
            var towersSecond = new List<int>[]
            {
                new List<int>(){ },
                new List<int>() { },
                new List<int>() {1 }
            };

            //act
            Action actFirst = () => _recursionNDynamicProgramming.TowersOfHanoi(towersFirst);
            Action actSecond = () => _recursionNDynamicProgramming.TowersOfHanoi(towersSecond);

            //assert
            actFirst.ShouldThrow<InvalidOperationException>();
            actSecond.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void TowersOfHanoi_Should_Check_Empty_Towers()
        {
            //arrange
            var towers = new List<int>[]
            {
                new List<int>(){  },
                new List<int>() { },
                new List<int>() { }
            };

            //act
            var result = _recursionNDynamicProgramming.TowersOfHanoi(towers);

            //assert
            result.Length.ShouldBeEquivalentTo(3);
            result[0].Count.ShouldBeEquivalentTo(0);
            result[1].Count.ShouldBeEquivalentTo(0);
            result[2].Count.ShouldBeEquivalentTo(towers[0].Count);
            result[2].SequenceEqual(towers[0]).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void TowersOfHanoi_Should_Check_High_Tower()
        {
            //arrange
            var towers = new List<int>[]
            {
                Enumerable.Range(1, 20).ToList(),
                new List<int>() { },
                new List<int>() { }
            };

            //act
            var result = _recursionNDynamicProgramming.TowersOfHanoi(towers);

            //assert
            result.Length.ShouldBeEquivalentTo(3);
            result[0].Count.ShouldBeEquivalentTo(0);
            result[1].Count.ShouldBeEquivalentTo(0);
            result[2].Count.ShouldBeEquivalentTo(towers[0].Count);
            result[2].SequenceEqual(towers[0]).ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Parens_Should_Check_Example()
        {
            //arrange
            var parens = new List<string>
            {
                "((()))", "(()())", "(())()", "()(())","()()()"
            };

            //act
            var result = _recursionNDynamicProgramming.Parens(3).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(parens.Count);
            foreach (var item in parens)
            {
                result.Contains(item).ShouldBeEquivalentTo(true);
                result.Remove(item);
            }
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Parens_Should_Throw_If_Negative()
        {
            //arrange

            //act
            Action act = () => _recursionNDynamicProgramming.Parens(-3).ToList();

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Parens_Should_Check_N_Zero()
        {
            //arrange

            //act
            var result = _recursionNDynamicProgramming.Parens(0).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(1);
            result[0].ShouldBeEquivalentTo(string.Empty);
        }

        [Fact]
        public void Parens_Should_Check_N_One()
        {
            //arrange
            var parens = new List<string>
            {
                "()"
            };

            //act
            var result = _recursionNDynamicProgramming.Parens(1).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(parens.Count);
            foreach (var item in parens)
            {
                result.Contains(item).ShouldBeEquivalentTo(true);
                result.Remove(item);
            }
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Parens_Should_Check_N_Two()
        {
            //arrange
            var parens = new List<string>
            {
                "(())", "()()"
            };

            //act
            var result = _recursionNDynamicProgramming.Parens(2).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(parens.Count);
            foreach (var item in parens)
            {
                result.Contains(item).ShouldBeEquivalentTo(true);
                result.Remove(item);
            }
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Parens_Should_Check_N_Four()
        {
            //arrange
            var parens = new List<string>
            {
                "(((())))","((()))()","((())())","(()()())",
                "(())(())","(())()()","((()()))","(()(()))",
                "(()())()","()((()))","()(())()","()(()())",
                "()()(())","()()()()"
            };

            //act
            var result = _recursionNDynamicProgramming.Parens(4).ToList();

            //assert
            result.Count.ShouldBeEquivalentTo(parens.Count);
            foreach (var item in parens)
            {
                result.Contains(item).ShouldBeEquivalentTo(true);
                result.Remove(item);
            }
            result.Count.ShouldBeEquivalentTo(0);
        }
    }
}
