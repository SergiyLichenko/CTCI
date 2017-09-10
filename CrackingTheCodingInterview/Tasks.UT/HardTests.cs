using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class HardTests
    {
        private readonly Hard _subject;
        public HardTests()
        {
            _subject = new Hard();
        }

        [Fact]
        public void AddWithPlus_Should_Add_Positive_Numbers()
        {
            //Arrange
            int a = 5;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Zero()
        {
            //Arrange
            int a = 0;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Negative_Number()
        {
            //Arrange
            int a = -2;
            int b = 7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Add_Two_Negative_Numbers()
        {
            //Arrange
            int a = -2;
            int b = -7;

            //Act
            var result = _subject.AddWithoutPlus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a + b);
        }

        [Fact]
        public void AddWithPlus_Should_Check_Load_With_Random_Numbers()
        {
            //Arrange
            int count = 10000;
            var random = new Random();

            //Assert
            while (count-- >= 0)
            {
                var first = random.Next();
                var second = random.Next();

                var result = _subject.AddWithoutPlus(first, second);
                result.ShouldBeEquivalentTo(first + second);
            }
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substact_Positive_Numbers()
        {
            //Arrange
            int a = 5;
            int b = 7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Zero()
        {
            //Arrange
            int a = 7;
            int b = 0;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Negative_Number()
        {
            //Arrange
            int a = 2;
            int b = -7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Substract_Two_Negative_Numbers()
        {
            //Arrange
            int a = -2;
            int b = -7;

            //Act
            var result = _subject.SubstractWithoutMinus(a, b);

            //Assert
            result.ShouldBeEquivalentTo(a - b);
        }

        [Fact]
        public void SubstractWithoutMinus_Should_Check_Load_With_Random_Numbers()
        {
            //Arrange
            int count = 10000;
            var random = new Random();

            //Assert
            while (count-- >= 0)
            {
                var first = random.Next();
                var second = random.Next();

                var result = _subject.SubstractWithoutMinus(first, second);
                result.ShouldBeEquivalentTo(first - second);
            }
        }

        [Fact]
        public void Shuffle_Should_Throw_If_Null()
        {
            //Act
            Action act = () => _subject.Shuffle(null).ToArray();

            //Assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void Shuffle_Should_Shuffle()
        {
            //Arrange
            var cards = Enumerable.Range(1, 52).ToArray();

            //Act
            var result = _subject.Shuffle(cards).ToArray();

            //Assert
            result.SequenceEqual(cards).ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Shuffle_Should_Not_Be_Immutable()
        {
            //Arrange
            var cards = Enumerable.Range(1, 52).ToArray();
            var copyCards = new int[cards.Length];
            Array.Copy(cards,copyCards, cards.Length);

            //Act
            var result = _subject.Shuffle(cards).ToArray();

            //Assert
            result.SequenceEqual(cards).ShouldBeEquivalentTo(false);
            cards.SequenceEqual(copyCards).ShouldBeEquivalentTo(true);
        }
    }
}
