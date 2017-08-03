using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyArrayQueueTests
    {
        [Fact]
        public void Should_Create_Default_Queue()
        {
            //arrange

            //act
            var queue = new MyArrayQueue<int>();

            //assert
            queue.Count.ShouldBeEquivalentTo(0);
            queue.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Create_Default_With_Capacity()
        {
            //arrange

            //act
            var queue = new MyArrayQueue<int>(5);

            //assert
            queue.Count.ShouldBeEquivalentTo(0);
            queue.Capacity.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Create_Default_With_Collection()
        {
            //arrange
            var array = new[] {1, 2, 3, 4, 5};
            //act
            var queue = new MyArrayQueue<int>(array);

            //assert
            queue.Count.ShouldBeEquivalentTo(array.Length);
            queue.Capacity.ShouldBeEquivalentTo(array.Length);
        }


        [Fact]
        public void Should_Create_Default_With_Collection_Throw_If_Null()
        {
            //arrange
            
            //act
            Action act = ()=> new MyArrayQueue<int>(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Enqueue()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            queue.Enqueue(1);

            //assert
            queue.Count.ShouldBeEquivalentTo(1);
            queue.Capacity.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Enqueue_With_Changed_Size()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            //assert
            queue.Count.ShouldBeEquivalentTo(5);
            queue.Capacity.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void Should_Dequeue_Throw_If_Is_Empty()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            Action act = ()=>queue.Dequeue();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Dequeue_Length_One()
        {
            //arrange
            var queue = new MyArrayQueue<int>(new List<int>(){1});

            //act
            var result = queue.Dequeue();

            //assert
            result.ShouldBeEquivalentTo(1);
            queue.Capacity.ShouldBeEquivalentTo(1);
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Dequeue_After_Enqueue()
        {
            //arrange
            var queue = new MyArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            //act
            var result = queue.Dequeue();

            //assert
            result.ShouldBeEquivalentTo(1);
            queue.Capacity.ShouldBeEquivalentTo(8);
            queue.Count.ShouldBeEquivalentTo(4);
        }

        [Fact]
        public void Should_Check_Head_Tail_Floating()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            queue.Enqueue(5);

            var first = queue.Dequeue();
            var second = queue.Dequeue();
            var third = queue.Dequeue();
            var fourth = queue.Dequeue();

            //assert
            queue.Capacity.ShouldBeEquivalentTo(4);
            queue.Count.ShouldBeEquivalentTo(0);
            first.ShouldBeEquivalentTo(2);
            second.ShouldBeEquivalentTo(3);
            third.ShouldBeEquivalentTo(4);
            fourth.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Check_Floating_Overflow()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Dequeue();
            queue.Enqueue(5);
            queue.Enqueue(6);
            
            //assert
            queue.Capacity.ShouldBeEquivalentTo(8);
            queue.Count.ShouldBeEquivalentTo(5);
            queue.Dequeue().ShouldBeEquivalentTo(2);
            queue.Dequeue().ShouldBeEquivalentTo(3);
            queue.Dequeue().ShouldBeEquivalentTo(4);
            queue.Dequeue().ShouldBeEquivalentTo(5);
            queue.Dequeue().ShouldBeEquivalentTo(6);
        }

        [Fact]
        public void Should_Check_Floating_Overflow_Multiple()
        {
            //arrange
            var queue = new MyArrayQueue<int>(1);

            //act
            queue.Enqueue(1);
            queue.Dequeue();
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Dequeue();
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Dequeue();

            //assert
            queue.Capacity.ShouldBeEquivalentTo(8);
            queue.Count.ShouldBeEquivalentTo(4);
            queue.Dequeue().ShouldBeEquivalentTo(4);
            queue.Dequeue().ShouldBeEquivalentTo(5);
            queue.Dequeue().ShouldBeEquivalentTo(6);
            queue.Dequeue().ShouldBeEquivalentTo(7);
        }

        [Fact]
        public void Should_Check_Is_Empty_True()
        {
            //arrange
            var queue = new MyArrayQueue<int>(1);
            queue.Enqueue(1);
            queue.Dequeue();

            //act
            var result = queue.IsEmpty();
            
            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Is_Empty_False()
        {
            //arrange
            var queue = new MyArrayQueue<int>(1);
            queue.Enqueue(1);

            //act
            var result = queue.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Tail_Floating()
        {
            //arrange
            var queue = new MyArrayQueue<int>(1);

            //act
            queue.Enqueue(1);
            queue.Dequeue();
            queue.Enqueue(2);
            var result = queue.Dequeue();

            //assert
            result.ShouldBeEquivalentTo(2);
            queue.Count.ShouldBeEquivalentTo(0);
            queue.Capacity.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Peek_Throw_If_Empty()
        {
            //arrange
            var queue = new MyArrayQueue<int>();

            //act
            Action act = () => queue.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }


        [Fact]
        public void Should_Peek()
        {
            //arrange
            var queue = new MyArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            //act
            var result = queue.Peek();

            //assert
            result.ShouldBeEquivalentTo(1);
            queue.Capacity.ShouldBeEquivalentTo(8);
            queue.Count.ShouldBeEquivalentTo(5);
            queue.Dequeue().ShouldBeEquivalentTo(1);
            queue.Dequeue().ShouldBeEquivalentTo(2);
            queue.Dequeue().ShouldBeEquivalentTo(3);
            queue.Dequeue().ShouldBeEquivalentTo(4);
            queue.Dequeue().ShouldBeEquivalentTo(5);
        }
    }
}
