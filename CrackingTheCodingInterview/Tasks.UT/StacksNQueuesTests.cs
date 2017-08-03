using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class StacksNQueuesTests
    {
        [Fact]
        public void ThreeInOne_Should_Create_Default()
        {
            //arrange

            //act
            var stack = new ThreeInOneStack<int>();

            //assert
            stack.CountTotal.ShouldBeEquivalentTo(0);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
            stack.CapacityTotal.ShouldBeEquivalentTo(12);
        }

        [Fact]
        public void ThreeInOne_Should_Push_Throw_When_StackNumber_Is_Not_Valid()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            Action actLower = () => stack.Push(1, -1);
            Action actHigher = () => stack.Push(1, 4);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ThreeInOne_Should_Push_One_First_Stack()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);

            //assert
            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(1);
        }
        [Fact]
        public void ThreeInOne_Should_Push_One_Second_Stack()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 1);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(1);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ThreeInOne_Should_Push_One_Third_Stack()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(1);
            stack.CountTotal.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ThreeInOne_Should_Push_Two_First_Stack()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);

            //assert
            stack.Count1.ShouldBeEquivalentTo(2);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void ThreeInOne_Should_Float_Overflow_Stack_One()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(4, 0);
            stack.Push(5, 0);

            //assert
            stack.Count1.ShouldBeEquivalentTo(5);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(5);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(5);
            stack.Capacity2.ShouldBeEquivalentTo(3);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Not_Reallocate_When_First_Stack_Is_Max()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(4, 0);
            stack.Push(5, 0);
            stack.Push(6, 0);
            stack.Push(7, 0);
            stack.Push(8, 0);
            stack.Push(9, 0);
            stack.Push(10, 0);
            stack.Push(11, 0);
            stack.Push(12, 0);

            //assert
            stack.Count1.ShouldBeEquivalentTo(12);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(12);
            stack.Capacity2.ShouldBeEquivalentTo(0);
            stack.Capacity3.ShouldBeEquivalentTo(0);
        }


        [Fact]
        public void ThreeInOne_Should_Not_Reallocate_When_Second_Stack_Is_Max()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 1);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 1);
            stack.Push(5, 1);
            stack.Push(6, 1);
            stack.Push(7, 1);
            stack.Push(8, 1);
            stack.Push(9, 1);
            stack.Push(10, 1);
            stack.Push(11, 1);
            stack.Push(12, 1);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(12);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(0);
            stack.Capacity2.ShouldBeEquivalentTo(12);
            stack.Capacity3.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void ThreeInOne_Should_Not_Reallocate_When_Third_Stack_Is_Max()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 2);
            stack.Push(2, 2);
            stack.Push(3, 2);
            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 2);
            stack.Push(7, 2);
            stack.Push(8, 2);
            stack.Push(9, 2);
            stack.Push(10, 2);
            stack.Push(11, 2);
            stack.Push(12, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(12);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(0);
            stack.Capacity2.ShouldBeEquivalentTo(0);
            stack.Capacity3.ShouldBeEquivalentTo(12);
        }

        [Fact]
        public void ThreeInOne_Should_Not_Reallocate_When_Multiple_Overlfow_But_Space_Exists()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(4, 1);
            stack.Push(5, 2);
            stack.Push(6, 2);

            stack.Push(7, 1);
            stack.Push(8, 1);
            stack.Push(9, 1);
            stack.Push(10, 1);
            stack.Push(11, 2);
            stack.Push(12, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(3);
            stack.Count2.ShouldBeEquivalentTo(5);
            stack.Count3.ShouldBeEquivalentTo(4);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(3);
            stack.Capacity2.ShouldBeEquivalentTo(5);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Not_Reallocate_When_All_Overlfow_But_Space_Exists()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 1);
            stack.Push(3, 2);

            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 0);
            stack.Push(7, 0);
            stack.Push(8, 1);
            stack.Push(9, 1);

            stack.Push(10, 2);
            stack.Push(11, 2);
            stack.Push(12, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(3);
            stack.Count2.ShouldBeEquivalentTo(3);
            stack.Count3.ShouldBeEquivalentTo(6);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(3);
            stack.Capacity2.ShouldBeEquivalentTo(3);
            stack.Capacity3.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Realocation_Of_Space_Stack_One()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(4, 0);
            stack.Push(5, 0);
            stack.Push(6, 0);
            stack.Push(7, 0);
            stack.Push(8, 0);
            stack.Push(9, 0);
            stack.Push(10, 0);
            stack.Push(11, 0);
            stack.Push(12, 0);
            stack.Push(13, 0);

            //assert
            stack.Count1.ShouldBeEquivalentTo(13);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(13);
            stack.Capacity2.ShouldBeEquivalentTo(3);
            stack.Capacity3.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Realocation_Of_Space_Stack_Two()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 1);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 1);
            stack.Push(5, 1);
            stack.Push(6, 1);
            stack.Push(7, 1);
            stack.Push(8, 1);
            stack.Push(9, 1);
            stack.Push(10, 1);
            stack.Push(11, 1);
            stack.Push(12, 1);
            stack.Push(13, 1);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(13);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(8);
            stack.Capacity2.ShouldBeEquivalentTo(13);
            stack.Capacity3.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Realocation_Of_Space_Stack_Three()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 2);
            stack.Push(2, 2);
            stack.Push(3, 2);
            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 2);
            stack.Push(7, 2);
            stack.Push(8, 2);
            stack.Push(9, 2);
            stack.Push(10, 2);
            stack.Push(11, 2);
            stack.Push(12, 2);
            stack.Push(13, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(13);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(3);
            stack.Capacity2.ShouldBeEquivalentTo(8);
            stack.Capacity3.ShouldBeEquivalentTo(13);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Realocation_Of_Space_Three_Stacks()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 2);
            stack.Push(2, 2);
            stack.Push(3, 2);
            stack.Push(4, 2);
            stack.Push(5, 2);
            stack.Push(6, 2);
            stack.Push(7, 0);
            stack.Push(8, 0);
            stack.Push(9, 0);
            stack.Push(10, 1);
            stack.Push(11, 1);
            stack.Push(12, 1);
            stack.Push(13, 1);

            //assert
            stack.Count1.ShouldBeEquivalentTo(3);
            stack.Count2.ShouldBeEquivalentTo(4);
            stack.Count3.ShouldBeEquivalentTo(6);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(8);
            stack.Capacity2.ShouldBeEquivalentTo(8);
            stack.Capacity3.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Realocation_When_Two_Stacks()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            stack.Push(1, 0);
            stack.Push(2, 0);
            stack.Push(3, 0);
            stack.Push(4, 0);
            stack.Push(5, 0);
            stack.Push(6, 0);
            stack.Push(7, 1);
            stack.Push(8, 1);
            stack.Push(9, 1);
            stack.Push(10, 1);
            stack.Push(11, 1);
            stack.Push(12, 1);
            stack.Push(13, 2);

            //assert
            stack.Count1.ShouldBeEquivalentTo(6);
            stack.Count2.ShouldBeEquivalentTo(6);
            stack.Count3.ShouldBeEquivalentTo(1);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(8);
            stack.Capacity2.ShouldBeEquivalentTo(8);
            stack.Capacity3.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void ThreeInOne_Should_Peek_Stack_One()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);

            //act
            var result = stack.Peek(0);

            //assert
            result.ShouldBeEquivalentTo(1);
            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(1);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Throw_Peek_If_Empty()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);

            //act
            Action act = () => stack.Peek(1);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(1);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Peek_Multiple()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);
            stack.Push(2, 1);
            stack.Push(3, 2);

            //act
            var first = stack.Peek(0);
            var second = stack.Peek(1);
            var third = stack.Peek(2);

            //assert
            first.ShouldBeEquivalentTo(1);
            second.ShouldBeEquivalentTo(2);
            third.ShouldBeEquivalentTo(3);

            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(1);
            stack.Count3.ShouldBeEquivalentTo(1);
            stack.CountTotal.ShouldBeEquivalentTo(3);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Peek_Stack_Index_Range()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            Action actLower = () => stack.Peek(-1);
            Action actHigher = () => stack.Peek(4);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_Stack_Index_Range()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            Action actLower = () => stack.Pop(-1);
            Action actHigher = () => stack.Pop(4);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_Throw_If_Is_Empty()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);
            //act
            Action act = () => stack.Pop(1);

            //assert
            act.ShouldThrow<InvalidOperationException>();

            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(1);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_One_For_Multiple_Stacks()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);
            stack.Push(2, 1);
            stack.Push(3, 2);

            //act
            var first = stack.Pop(0);
            var second = stack.Pop(1);
            var third = stack.Pop(2);

            Action actFirst = () => stack.Pop(0);
            Action actSecond = () => stack.Pop(1);
            Action actThird = () => stack.Pop(2);

            //assert
            first.ShouldBeEquivalentTo(1);
            second.ShouldBeEquivalentTo(2);
            third.ShouldBeEquivalentTo(3);

            actFirst.ShouldThrow<InvalidOperationException>();
            actSecond.ShouldThrow<InvalidOperationException>();
            actThird.ShouldThrow<InvalidOperationException>();

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Pop_Full()
        {
            //arrange
            var values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            var stack = new ThreeInOneStack<int>();
            foreach (var item in values)
                stack.Push(item, 0);

            var result = new int[values.Length];
            //act
            for (int i = 0; i < result.Length; i++)
                result[result.Length - 1 - i] = stack.Pop(0);

            //assert
            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(values[i]);

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(12);
            stack.Capacity2.ShouldBeEquivalentTo(0);
            stack.Capacity3.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_Order()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 1);
            stack.Push(5, 1);
            stack.Push(6, 1);
            stack.Push(7, 2);
            stack.Push(8, 2);
            stack.Push(9, 2);
            stack.Push(10, 2);
            stack.Push(11, 2);
            stack.Push(12, 2);

            //act

            //assert
            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(5);
            stack.Count3.ShouldBeEquivalentTo(6);
            stack.CountTotal.ShouldBeEquivalentTo(12);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(1);
            stack.Capacity2.ShouldBeEquivalentTo(5);
            stack.Capacity3.ShouldBeEquivalentTo(6);

            stack.Pop(0).ShouldBeEquivalentTo(1);
            stack.Pop(2).ShouldBeEquivalentTo(12);
            stack.Pop(2).ShouldBeEquivalentTo(11);
            stack.Pop(2).ShouldBeEquivalentTo(10);
            stack.Pop(2).ShouldBeEquivalentTo(9);
            stack.Pop(2).ShouldBeEquivalentTo(8);
            stack.Pop(2).ShouldBeEquivalentTo(7);
            stack.Pop(1).ShouldBeEquivalentTo(6);
            stack.Pop(1).ShouldBeEquivalentTo(5);
            stack.Pop(1).ShouldBeEquivalentTo(4);
            stack.Pop(1).ShouldBeEquivalentTo(3);
            stack.Pop(1).ShouldBeEquivalentTo(2);

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(1);
            stack.Capacity2.ShouldBeEquivalentTo(5);
            stack.Capacity3.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_Order_With_Overflow()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(1, 0);
            stack.Push(2, 1);
            stack.Push(3, 1);
            stack.Push(4, 1);
            stack.Push(5, 1);
            stack.Push(6, 1);
            stack.Push(7, 2);
            stack.Push(8, 2);
            stack.Push(9, 2);
            stack.Push(10, 2);
            stack.Push(11, 2);
            stack.Push(12, 2);

            stack.Push(13, 0);

            //act

            //assert
            stack.Count1.ShouldBeEquivalentTo(2);
            stack.Count2.ShouldBeEquivalentTo(5);
            stack.Count3.ShouldBeEquivalentTo(6);
            stack.CountTotal.ShouldBeEquivalentTo(13);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(8);
            stack.Capacity2.ShouldBeEquivalentTo(8);
            stack.Capacity3.ShouldBeEquivalentTo(8);

            stack.Pop(0).ShouldBeEquivalentTo(13);
            stack.Pop(0).ShouldBeEquivalentTo(1);
            stack.Pop(2).ShouldBeEquivalentTo(12);
            stack.Pop(2).ShouldBeEquivalentTo(11);
            stack.Pop(2).ShouldBeEquivalentTo(10);
            stack.Pop(2).ShouldBeEquivalentTo(9);
            stack.Pop(2).ShouldBeEquivalentTo(8);
            stack.Pop(2).ShouldBeEquivalentTo(7);
            stack.Pop(1).ShouldBeEquivalentTo(6);
            stack.Pop(1).ShouldBeEquivalentTo(5);
            stack.Pop(1).ShouldBeEquivalentTo(4);
            stack.Pop(1).ShouldBeEquivalentTo(3);
            stack.Pop(1).ShouldBeEquivalentTo(2);

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(24);
            stack.Capacity1.ShouldBeEquivalentTo(8);
            stack.Capacity2.ShouldBeEquivalentTo(8);
            stack.Capacity3.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Pop_With_Multiple_Overflow()
        {
            //arrange
            var values = Enumerable.Range(0, 100);
            var result = new int[values.Count()];
            var stack = new ThreeInOneStack<int>();
            foreach (var value in values)
                stack.Push(value, 0);

            //act
            for (int i = 0; i < values.Count(); i++)
                result[result.Length - 1 - i] = stack.Pop(0);

            //assert
            for (int i = 0; i < result.Length; i++)
                result[i].ShouldBeEquivalentTo(values.ElementAt(i));

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(192);
            stack.Capacity1.ShouldBeEquivalentTo(100);
            stack.Capacity2.ShouldBeEquivalentTo(28);
            stack.Capacity3.ShouldBeEquivalentTo(64);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Is_Empty_Stack_Index_Range()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            Action actLower = () => stack.IsEmpty(-1);
            Action actHigher = () => stack.IsEmpty(4);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Is_Empty_False()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();
            stack.Push(0,0);
            stack.Push(1, 1);
            stack.Push(2, 2);

            //act
            var first = stack.IsEmpty(0);
            var second = stack.IsEmpty(1);
            var third = stack.IsEmpty(2);

            //assert
            first.ShouldBeEquivalentTo(false);
            second.ShouldBeEquivalentTo(false);
            third.ShouldBeEquivalentTo(false);

            stack.Count1.ShouldBeEquivalentTo(1);
            stack.Count2.ShouldBeEquivalentTo(1);
            stack.Count3.ShouldBeEquivalentTo(1);
            stack.CountTotal.ShouldBeEquivalentTo(3);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void ThreeInOne_Should_Check_Is_Empty_True()
        {
            //arrange
            var stack = new ThreeInOneStack<int>();

            //act
            var first = stack.IsEmpty(0);
            var second = stack.IsEmpty(1);
            var third = stack.IsEmpty(2);

            //assert
            first.ShouldBeEquivalentTo(true);
            second.ShouldBeEquivalentTo(true);
            third.ShouldBeEquivalentTo(true);

            stack.Count1.ShouldBeEquivalentTo(0);
            stack.Count2.ShouldBeEquivalentTo(0);
            stack.Count3.ShouldBeEquivalentTo(0);
            stack.CountTotal.ShouldBeEquivalentTo(0);

            stack.CapacityTotal.ShouldBeEquivalentTo(12);
            stack.Capacity1.ShouldBeEquivalentTo(4);
            stack.Capacity2.ShouldBeEquivalentTo(4);
            stack.Capacity3.ShouldBeEquivalentTo(4);
        }
    }
}
