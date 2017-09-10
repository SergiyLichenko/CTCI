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
    }
}
