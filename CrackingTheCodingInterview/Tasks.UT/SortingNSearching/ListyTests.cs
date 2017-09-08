using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.SortingNSearching;
using Xunit;

namespace Tasks.UT.SortingNSearching
{
    public class ListyTests
    {
        [Fact]
        public void Should_Throw_If_SetterIndexer_Not_In_Range()
        {
            //Arrange
            var listy = new Listy();

            //Act
            Action actLower = () => listy[-1] = 2;
            Action actHigher = () => listy[5] = 3;

            //Assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_If_Add_Negative_Number()
        {
            //Arrange
            var listy = new Listy();

            //Act
            Action act = () => listy[0] = -2;

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_GetIndexer()
        {
            //Arrange
            var listy = new Listy();

            //Act
            listy[0] = 1;
            listy[1] = 5;

            //Assert
            listy[0].ShouldBeEquivalentTo(1);
            listy[1].ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_GetIndexer_Not_In_Range_High()
        {
            //Arrange
            var listy = new Listy();

            //Act
            var result = listy[5];

            //Assert
            result.ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void Should_Throw_GetIndexer_Not_In_Range_Low()
        {
            //Arrange
            var listy = new Listy();
            int temp;
            //Act
            Action act = () => temp = listy[-1];

            //Assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Check_Resize()
        {
            //Arrange
            var listy = new Listy();
            var values = new int[] { 1, 2, 3, 4, 5 };

            //Act
            for (int i = 0; i < values.Length; i++)
                listy[i] = values[i];

            //Assert
            for (int i = 0; i < values.Length; i++)
                listy[i].ShouldBeEquivalentTo(values[i]);
        }

        [Fact]
        public void Should_Should_Initialize_With_Default_Max_Int_Element()
        {
            //Act
            var listy = new Listy();

            //Assert
            listy[0].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[1].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[2].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[3].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[4].ShouldBeEquivalentTo(-1);
        }

        [Fact]
        public void Should_Should_Rearange_With_Default_Max_Int_Element()
        {
            var listy = new Listy();
            var values = new int[] { 1, 2, 3, 4, 5 };

            //Act
            for (int i = 0; i < values.Length; i++)
                listy[i] = values[i];

            //Assert
            for (int i = 0; i < values.Length; i++)
                listy[i].ShouldBeEquivalentTo(values[i]);
            listy[5].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[6].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[7].ShouldBeEquivalentTo(Int32.MaxValue);
            listy[8].ShouldBeEquivalentTo(-1);
        }
    }
}
