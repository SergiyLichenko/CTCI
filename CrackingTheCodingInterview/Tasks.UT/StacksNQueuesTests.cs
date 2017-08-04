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
            stack.Push(0, 0);
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

        [Fact]
        public void StackMin_Should_Create_Default()
        {
            //arrange

            //act
            var stack = new StackMin();

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackMin_Should_Create_With_Collection()
        {
            //arrange
            var data = new int[] { 1, 2, 3 };
            //act
            var stack = new StackMin(data);

            //assert
            stack.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void StackMin_Should_Create_With_Collection_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => new StackMin(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StackMin_Should_Push()
        {
            //arrange
            var stack = new StackMin();

            //act
            stack.Push(1);
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackMin_Should_Peek()
        {
            //arrange
            var stack = new StackMin(new[] { 1 });

            //act
            var result = stack.Peek();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackMin_Should_Peek_Throw_If_Empty()
        {
            //arrange
            var stack = new StackMin();

            //act
            Action act = () => stack.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StackMin_Should_Pop()
        {
            //arrange
            var stack = new StackMin(new[] { 1 });

            //act
            var result = stack.Pop();

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackMin_Should_Pop_Throw_If_Empty()
        {
            //arrange
            var stack = new StackMin();

            //act
            Action act = () => stack.Pop();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StackMin_Should_Check_Is_Empty_True()
        {
            //arrange
            var stack = new StackMin();

            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StackMin_Should_Check_Is_Empty_False()
        {
            //arrange
            var stack = new StackMin();
            stack.Push(1);

            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
        }


        [Fact]
        public void StackMin_Should_Min_Throw_If_Empty()
        {
            //arrange
            var stack = new StackMin();

            //act
            Action act = () => stack.Min();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StackMin_Should_Check_Min()
        {
            //arrange
            var stack = new StackMin();
            stack.Push(1);
            stack.Push(3);
            stack.Push(5);
            stack.Push(-1);
            stack.Push(5);

            //act
            var result = stack.Min();

            //assert
            result.ShouldBeEquivalentTo(-1);
            stack.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void StackMin_Should_Check_Min_When_Pop()
        {
            //arrange
            var stack = new StackMin();
            stack.Push(1);
            stack.Push(3);
            stack.Push(5);
            stack.Push(-1);
            stack.Push(5);

            stack.Pop();
            stack.Pop();
            //act
            var result = stack.Min();

            //assert
            result.ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void StackOfPlates_Should_Create_Default()
        {
            //arrange
            int maxInnerStackSize = 3;

            //act
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_Create_Default_Throw_If_Size_Is_Negative()
        {
            //arrange
            int maxInnerStackSize = -3;

            //act
            Action act = () => new SetOfStacks<int>(maxInnerStackSize);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void StackOfPlates_Should_Create_With_Collection()
        {
            //arrange
            int maxInnerStackSize = 3;
            var array = new[] { 1, 2, 3, 4 };

            //act
            var stack = new SetOfStacks<int>(array, maxInnerStackSize);

            //assert
            stack.Count.ShouldBeEquivalentTo(array.Length);
        }

        [Fact]
        public void StackOfPlates_Should_Create_With_Collection_Throw_If_Null()
        {
            //arrange
            int maxInnerStackSize = 3;

            //act
            Action act = () => new SetOfStacks<int>(null, maxInnerStackSize);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StackOfPlates_Should_Push()
        {
            //arrange
            int maxInnerStackSize = 3;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            stack.Push(1);

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackOfPlates_Should_Push_Multiple_Inner_Stacks()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(3);

            //assert
            stack.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void StackOfPlates_Should_Peek()
        {
            //arrange
            int maxInnerStackSize = 2;

            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);

            //act
            var result = stack.Peek();

            //assert
            result.ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackOfPlates_Should_Peek_Throw_If_Empty()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            Action act = () => stack.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StackOfPlates_Should_Pop()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);

            //act
            var result = stack.Pop();

            //assert
            result.ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_Pop_Throw_If_Empty()
        {

            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            Action act = () => stack.Pop();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void StackOfPlates_Should_Pop_Multiple()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            //act

            //assert
            stack.Pop().ShouldBeEquivalentTo(5);
            stack.Pop().ShouldBeEquivalentTo(4);
            stack.Pop().ShouldBeEquivalentTo(3);
            stack.Pop().ShouldBeEquivalentTo(2);
            stack.Pop().ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_Push_Pop_Check_Order()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            //act
            stack.Pop();
            stack.Pop();
            stack.Push(6);
            stack.Push(7);

            stack.Pop();
            stack.Pop();
            stack.Pop();
            stack.Pop();

            stack.Push(8);
            stack.Push(9);

            //assert
            stack.Pop().ShouldBeEquivalentTo(9);
            stack.Pop().ShouldBeEquivalentTo(8);
            stack.Pop().ShouldBeEquivalentTo(1);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_Push_Pop_Check_Two_Elements()
        {
            //arrange
            int maxInnerStackSize = 1;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            stack.Push(1);
            stack.Push(2);
            stack.Pop();
            stack.Pop();
            stack.Push(3);
            stack.Pop();
            stack.Push(4);
            stack.Push(5);

            //assert
            stack.Pop().ShouldBeEquivalentTo(5);
            stack.Pop().ShouldBeEquivalentTo(4);
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_Check_Is_Empty_True()
        {
            //arrange
            int maxInnerStackSize = 1;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);
            stack.Pop();

            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StackOfPlates_Should_Check_Is_Empty_False()
        {
            //arrange
            int maxInnerStackSize = 1;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);

            //act
            var result = stack.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
        }


        [Fact]
        public void StackOfPlates_Should_PopAt()
        {
            //arrange
            int maxInnerStackSize = 1;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);

            //act
            var result = stack.PopAt(0);

            //assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void StackOfPlates_Should_PopAt_Throw_If_Not_In_Stack_Range()
        {
            //arrange
            int maxInnerStackSize = 1;
            var stack = new SetOfStacks<int>(maxInnerStackSize);

            //act
            Action actLower = () => stack.PopAt(-1);
            Action actHigher = () => stack.PopAt(4);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void StackOfPlates_Should_PopAt_Check_Rolling()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            //act
            var result = stack.PopAt(1);
            stack.Push(6);

            //assert
            result.ShouldBeEquivalentTo(4);
            stack.Count.ShouldBeEquivalentTo(5);

            stack.Pop().ShouldBeEquivalentTo(6);
            stack.Pop().ShouldBeEquivalentTo(5);
            stack.Pop().ShouldBeEquivalentTo(3);
            stack.Pop().ShouldBeEquivalentTo(2);
            stack.Pop().ShouldBeEquivalentTo(1);

            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void StackOfPlates_Should_PopAt_Check_Last()
        {
            //arrange
            int maxInnerStackSize = 2;
            var stack = new SetOfStacks<int>(maxInnerStackSize);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            //act

            //assert
            stack.Count.ShouldBeEquivalentTo(5);

            stack.PopAt(2).ShouldBeEquivalentTo(5);
            stack.PopAt(1).ShouldBeEquivalentTo(4);
            stack.PopAt(1).ShouldBeEquivalentTo(3);
            stack.PopAt(0).ShouldBeEquivalentTo(2);
            stack.PopAt(0).ShouldBeEquivalentTo(1);

            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void QueueViaStacks_Should_Create_Default()
        {
            //arrange

            //act
            var queue = new MyQueue<int>();

            //assert
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void QueueViaStacks_Should_Create_With_Collection()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4, 5 };

            //act
            var queue = new MyQueue<int>(array);

            //assert
            queue.Count.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void QueueViaStacks_Should_Create_With_Collection_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => new MyQueue<int>(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void QueueViaStacks_Should_Enqueue()
        {
            //arrange
            var queue = new MyQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(2);

            //assert
            queue.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void QueueViaStacks_Should_Peek()
        {
            //arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            //act
            var result = queue.Peek();

            //assert
            queue.Count.ShouldBeEquivalentTo(2);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void QueueViaStacks_Should_Peek_Throw_If_Empty()
        {
            //arrange
            var queue = new MyQueue<int>();

            //act
            Action act = () => queue.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void QueueViaStacks_Should_Dequeue_Throw_If_Empty()
        {
            //arrange
            var queue = new MyQueue<int>();

            //act
            Action act = () => queue.Dequeue();

            //assert
            act.ShouldThrow<InvalidOperationException>();
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void QueueViaStacks_Should_Dequeue()
        {
            //arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            //act
            var result = queue.Dequeue();

            //assert
            queue.Count.ShouldBeEquivalentTo(2);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void QueueViaStacks_Should_Check_Enqueue_Dequeue_Order()
        {
            //arrange
            var queue = new MyQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            queue.Dequeue();
            queue.Dequeue();

            queue.Enqueue(4);
            queue.Enqueue(5);

            //assert
            queue.Count.ShouldBeEquivalentTo(3);
            queue.Dequeue().ShouldBeEquivalentTo(3);
            queue.Dequeue().ShouldBeEquivalentTo(4);
            queue.Dequeue().ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void QueueViaStacks_Should_Check_Is_Empty_False()
        {
            //arrange
            var queue = new MyQueue<int>();
            queue.Enqueue(2);

            //act
            var result = queue.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
            queue.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void QueueViaStacks_Should_Check_Is_Empty_True()
        {
            //arrange
            var queue = new MyQueue<int>();

            //act
            var result = queue.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void SortStack_Should_Create_Default()
        {
            //arrange

            //act
            var stack = new SortedStack<int>();

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void SortStack_Should_Create_With_Collection()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4, 5, 6 };

            //act
            var stack = new SortedStack<int>(array);

            //assert
            stack.Count.ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void SortStack_Should_Create_With_Collection_Throw_If_Empty()
        {
            //arrange

            //act
            Action act = () => new SortedStack<int>(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void SortStack_Should_Push()
        {
            //arrange
            var stack = new SortedStack<int>();

            //act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            //assert
            stack.Count.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void SortStack_Should_Peek_Throw_If_Empty()
        {
            //arrange
            var stack = new SortedStack<int>();

            //act
            Action act = () => stack.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SortStack_Should_Pop_Throw_If_Empty()
        {
            //arrange
            var stack = new SortedStack<int>();

            //act
            Action act = () => stack.Pop();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void SortStack_Should_Peek()
        {
            //arrange
            var stack = new SortedStack<int>();
            stack.Push(2);
            stack.Push(-1);
            stack.Push(4);
            stack.Push(3);

            //act
            var result = stack.Peek();

            //assert
            result.ShouldBeEquivalentTo(-1);
            stack.Count.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void SortStack_Should_Pop()
        {
            //arrange
            var stack = new SortedStack<int>();
            stack.Push(2);
            stack.Push(-1);
            stack.Push(4);
            stack.Push(3);

            //act
            var result = stack.Pop();

            //assert
            result.ShouldBeEquivalentTo(-1);
            stack.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void SortStack_Should_Check_Pop_Order()
        {
            //arrange
            var stack = new SortedStack<int>();
            stack.Push(2);
            stack.Push(-1);
            stack.Push(4);
            stack.Push(3);

            //act

            //assert
            stack.Count.ShouldBeEquivalentTo(4);

            stack.Pop().ShouldBeEquivalentTo(-1);
            stack.Pop().ShouldBeEquivalentTo(2);
            stack.Pop().ShouldBeEquivalentTo(3);
            stack.Pop().ShouldBeEquivalentTo(4);

            stack.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void SortStack_Should_Check_Is_Empty_False()
        {
            //arrange
            var stack = new SortedStack<int>();
            stack.Push(2);

            //act
            var result = stack.IsEmpty();

            //assert
            stack.Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void SortStack_Should_Check_Is_Empty_True()
        {
            //arrange
            var stack = new SortedStack<int>();
            stack.Push(2);
            stack.Pop();

            //act
            var result = stack.IsEmpty();

            //assert
            stack.Count.ShouldBeEquivalentTo(0);
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void AnimalShelter_Should_Create_Default()
        {
            //arrange

            //act
            var shelter = new AnimalShelterQueue();

            //assert
            shelter.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void AnimalShelter_Should_Enqueue_Dogs()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            //act
            shelter.Enqueue(new Dog());
            shelter.Enqueue(new Dog());

            //assert
            shelter.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void AnimalShelter_Should_Enqueue_Cats()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            //act
            shelter.Enqueue(new Cat());
            shelter.Enqueue(new Cat());

            //assert
            shelter.Count.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void AnimalShelter_Should_Throw_DequeueAny_If_Empty()
        {
            //arrange
            var shelter = new AnimalShelterQueue();
            shelter.Enqueue(new Cat());
            shelter.DequeueAny();

            //act
            Action act = () => shelter.DequeueAny();


            //assert
            act.ShouldThrow<InvalidOperationException>();
            shelter.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void AnimalShelter_Should_Throw_DequeueCat_If_Empty()
        {
            //arrange
            var shelter = new AnimalShelterQueue();
            shelter.Enqueue(new Dog());

            //act
            Action act = () => shelter.DequeueCat();


            //assert
            act.ShouldThrow<InvalidOperationException>();
            shelter.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void AnimalShelter_Should_Throw_DequeueDog_If_Empty()
        {
            //arrange
            var shelter = new AnimalShelterQueue();
            shelter.Enqueue(new Cat());

            //act
            Action act = () => shelter.DequeueDog();


            //assert
            act.ShouldThrow<InvalidOperationException>();
            shelter.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void AnimalShelter_Should_DequeueDog()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            var dog1 = new Dog();
            var dog2 = new Dog();
            var dog3 = new Dog();

            var cat1 = new Cat();
            var cat2 = new Cat();
            var cat3 = new Cat();

            shelter.Enqueue(cat1);
            shelter.Enqueue(dog1);
            shelter.Enqueue(cat2);
            shelter.Enqueue(dog2);
            shelter.Enqueue(dog3);
            shelter.Enqueue(cat3);

            //act

            //assert
            shelter.Count.ShouldBeEquivalentTo(6);

            shelter.DequeueDog().ShouldBeEquivalentTo(dog1);
            shelter.DequeueDog().ShouldBeEquivalentTo(dog2);
            shelter.DequeueDog().ShouldBeEquivalentTo(dog3);

            shelter.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void AnimalShelter_Should_DequeueCat()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            var dog1 = new Dog();
            var dog2 = new Dog();
            var dog3 = new Dog();

            var cat1 = new Cat();
            var cat2 = new Cat();
            var cat3 = new Cat();

            shelter.Enqueue(cat1);
            shelter.Enqueue(dog1);
            shelter.Enqueue(cat2);
            shelter.Enqueue(dog2);
            shelter.Enqueue(dog3);
            shelter.Enqueue(cat3);

            //act

            //assert
            shelter.Count.ShouldBeEquivalentTo(6);

            shelter.DequeueCat().ShouldBeEquivalentTo(cat1);
            shelter.DequeueCat().ShouldBeEquivalentTo(cat2);
            shelter.DequeueCat().ShouldBeEquivalentTo(cat3);

            shelter.Count.ShouldBeEquivalentTo(3);
        }

        [Fact]
        public void AnimalShelter_Should_DequeueAny()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            var dog1 = new Dog();
            var dog2 = new Dog();
            var dog3 = new Dog();

            var cat1 = new Cat();
            var cat2 = new Cat();
            var cat3 = new Cat();

            shelter.Enqueue(cat1);
            shelter.Enqueue(dog1);
            shelter.Enqueue(cat2);
            shelter.Enqueue(dog2);
            shelter.Enqueue(dog3);
            shelter.Enqueue(cat3);

            //act

            //assert
            shelter.Count.ShouldBeEquivalentTo(6);

            shelter.DequeueAny().ShouldBeEquivalentTo(cat1);
            shelter.DequeueAny().ShouldBeEquivalentTo(dog1);
            shelter.DequeueAny().ShouldBeEquivalentTo(cat2);
            shelter.DequeueAny().ShouldBeEquivalentTo(dog2);
            shelter.DequeueAny().ShouldBeEquivalentTo(dog3);
            shelter.DequeueAny().ShouldBeEquivalentTo(cat3);

            shelter.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void AnimalShelter_Should_Throw_Enqueue_If_Null()
        {
            //arrange
            var shelter = new AnimalShelterQueue();

            //act
            Action act = () => shelter.Enqueue(null);
            
            //assert
            act.ShouldThrow<ArgumentNullException>();
        }
    }
}
