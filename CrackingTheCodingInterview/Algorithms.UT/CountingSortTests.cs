using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Algorithms.UT
{
    public class CountingSortTests
    {
        [Fact]
        public void CountingSorting_Should_Check_Empty_Array()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = array.CountingSorting().ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void CountingSorting_Should_Check_Sort()
        {
            //Arrange
            var random = new Random();
            int count = 1000;
            var array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = random.Next(0, 10);

            //Act
            var result = array.CountingSorting().ToArray();

            //Assert
            result.SequenceEqual(array.OrderBy(x => x))
                .ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void RadixSort_Should_Check_Empty_Array()
        {
            //Arrange
            var array = Enumerable.Range(0, 0).ToArray();

            //Act
            var result = array.RadixSort().ToArray();

            //Assert
            result.Length.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void RadixSort_Should_Check_Sort()
        {
            //Arrange
            var random = new Random();
            var array = Enumerable.Range(0, 1000)
                .OrderBy(x => random.Next())
                .ToArray();

            //Act
            var result = array.RadixSort().ToArray();

            //Assert
            result.SequenceEqual(array.OrderBy(x => x))
                .ShouldBeEquivalentTo(true);
        }
    }
}
