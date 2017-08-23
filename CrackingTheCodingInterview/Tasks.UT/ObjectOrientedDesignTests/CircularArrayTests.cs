using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class CircularArrayTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange
            int capacity = 5;

            //act
            var result = new CircularArray<int>(capacity);

            //assert
            result.Capacity.ShouldBeEquivalentTo(capacity);
            result.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_Default_If_Negative_Capacity()
        {
            //arrange
            int capacity = -5;

            //act
            Action act = () => new CircularArray<int>(capacity);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Check_Set_Get_Index()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            array[0] = 5;
            array[1] = 3;
            array[2] = -3;
            array[3] = 4;

            //assert
            array[0].ShouldBeEquivalentTo(5);
            array[1].ShouldBeEquivalentTo(3);
            array[2].ShouldBeEquivalentTo(-3);
            array[3].ShouldBeEquivalentTo(4);
            array[4].ShouldBeEquivalentTo(0);
            array.Count.ShouldBeEquivalentTo(capacity - 1);
        }

        [Fact]
        public void Should_Check_Foreach()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = new int[] { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            //act
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(values).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(values.Length);
        }

        [Fact]
        public void Should_Throw_Rotate_If_Zero()
        {
            //arrange
            int capacity = 5;

            //act
            Action act = () => new CircularArray<int>(capacity).Rotate(0);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Check_Rotate()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            int[] resultValues = { -3, 4, 1, 5, 3 };

            //act
            array.Rotate(2);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(resultValues.Length);
        }

        [Fact]
        public void Should_Check_Rotate_Negative()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            int[] resultValues = { 4, 1, 5, 3, -3 };

            //act
            array.Rotate(-2);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(resultValues.Length);
        }

        [Fact]
        public void Should_Check_Rotate_Negative_Overflow()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            int[] resultValues = { 4, 1, 5, 3, -3 };

            //act
            array.Rotate(-12);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(resultValues.Length);
        }

        [Fact]
        public void Should_Check_Rotate_Overflow()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            int[] resultValues = { -3, 4, 1, 5, 3 };

            //act
            array.Rotate(12);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(resultValues.Length);
        }

        [Fact]
        public void Should_Check_Rotate_Full_Length_Positive()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            //act
            array.Rotate(values.Length);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(values).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(values.Length);
        }

        [Fact]
        public void Should_Check_Rotate_Full_Length_Negative()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            //act
            array.Rotate(-values.Length);
            var result = new List<int>();
            foreach (var item in array)
                result.Add(item);

            //assert
            result.SequenceEqual(values).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(values.Length);
        }

        [Fact]
        public void Should_Check_Clone()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];
            array.Rotate(2);

            int[] resultValues = new[] { -3, 4, 1, 5, 3 };

            //act
            var clone = array.Clone();
            var result = new List<int>();
            foreach (var item in clone)
                result.Add(item);

            //assert
            result.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            result.Count.ShouldBeEquivalentTo(resultValues.Length);
            clone.Capacity.ShouldBeEquivalentTo(array.Capacity);
            clone.Count.ShouldBeEquivalentTo(array.Count);

            clone.ShouldBeEquivalentTo(array);
            clone.Equals(array).ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Copy_To()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];
            array.Rotate(2);

            int[] resultValues = new[] { 0, -3, 4, 1, 5, 3 };

            //act
            var mass = new int[capacity + 1];
            array.CopyTo(mass, 1);

            //assert
            mass.SequenceEqual(resultValues).ShouldBeEquivalentTo(true);
            mass.Length.ShouldBeEquivalentTo(resultValues.Length);
        }

        [Fact]
        public void Should_Check_Copy_To_Throw_If_Destination_Index_Not_In_Range()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);
            int[] mass = new int[capacity];

            //act
            Action actLower = () => array.CopyTo(mass, -1);
            Action actHigher = () => array.CopyTo(mass, mass.Length);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Check_Copy_To_Throw_If_Null()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            Action act = () => array.CopyTo(null, 1);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Check_Copy_To_Throw_If_Not_Enough_Space()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);
            int[] mass = new int[capacity];

            //act
            Action act = () => array.CopyTo(mass, 1);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Get_Length()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            var result = array.GetLength();

            //assert
            result.ShouldBeEquivalentTo(capacity);
        }

        [Fact]
        public void Should_Check_Get_Set_Value()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            array.SetValue(5, 0);
            array.SetValue(3, 1);
            array.SetValue(-3, 2);
            array.SetValue(4, 3);

            //assert
            ((int)array.GetValue(0)).ShouldBeEquivalentTo(5);
            ((int)array.GetValue(1)).ShouldBeEquivalentTo(3);
            ((int)array.GetValue(2)).ShouldBeEquivalentTo(-3);
            ((int)array.GetValue(3)).ShouldBeEquivalentTo(4);
            ((int)array.GetValue(4)).ShouldBeEquivalentTo(0);
            array.Count.ShouldBeEquivalentTo(capacity - 1);
        }

        [Fact]
        public void Should_Check_Set_Value_Throw_If_Invalid_Type()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            array.SetValue(5, 0);
            array.SetValue(3, 1);
            Action act = () => array.SetValue("s", 2);
            array.SetValue(4, 3);

            //assert
            act.ShouldThrow<InvalidCastException>();

            ((int)array.GetValue(0)).ShouldBeEquivalentTo(5);
            ((int)array.GetValue(1)).ShouldBeEquivalentTo(3);
            ((int)array.GetValue(2)).ShouldBeEquivalentTo(0);
            ((int)array.GetValue(3)).ShouldBeEquivalentTo(4);
            ((int)array.GetValue(4)).ShouldBeEquivalentTo(0);
            array.Count.ShouldBeEquivalentTo(capacity - 2);
        }

        [Fact]
        public void Should_Check_Access_Via_Minus_Index()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];
            array.Rotate(2);

            //assert
            array[-1].ShouldBeEquivalentTo(3);
            array[-2].ShouldBeEquivalentTo(5);
            array[-3].ShouldBeEquivalentTo(1);
            array[-4].ShouldBeEquivalentTo(4);
            array[-5].ShouldBeEquivalentTo(-3);
        }

        [Fact]
        public void Should_Check_Access_Via_Overflow_Index()
        {
            //arrange
            int capacity = 5;
            var array = new CircularArray<int>(capacity);

            //act
            int[] values = { 5, 3, -3, 4, 1 };
            for (int i = 0; i < values.Length; i++)
                array[i] = values[i];

            //assert
            array[11].ShouldBeEquivalentTo(3);
            array[22].ShouldBeEquivalentTo(-3);
            array[-13].ShouldBeEquivalentTo(-3);
            array[-5].ShouldBeEquivalentTo(5);
            array[4].ShouldBeEquivalentTo(1);
        }
    }
}
