using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyLinkedListQueueTests
    {
        [Fact]
        public void Should_Create_Default_Queue()
        {
            //arrange

            //act
            var queue = new MyLinkedListQueue<int>();

            //assert
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Create_With_Collection()
        {
            //arrange
            var array = new int[] { 1, 2, 3, 4, 5 };

            //act
            var queue = new MyLinkedListQueue<int>(array);

            //assert
            queue.Count.ShouldBeEquivalentTo(5);
            queue.Peek().ShouldBeEquivalentTo(1);
        }


        [Fact]
        public void Should_Create_With_Collection_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => new MyLinkedListQueue<int>(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Enqueue_One()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            queue.Enqueue(1);

            //assert
            queue.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Enqueue()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Enqueue(22);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(5);

            var result = queue.Peek();

            //assert
            queue.Count.ShouldBeEquivalentTo(5);
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Peek()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();
            queue.Enqueue(5);
            //act
            var result = queue.Peek();

            //assert
            queue.Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void Should_Peek_Throw_If_Empty()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            Action act = () => queue.Peek();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Dequeue()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();
            queue.Enqueue(1);
            //act
            var result = queue.Dequeue();

            //assert
            result.ShouldBeEquivalentTo(1);
            queue.Count.ShouldBeEquivalentTo(0);
        }


        [Fact]
        public void Should_Dequeue_Throw_If_Empty()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            Action act = () => queue.Dequeue();

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Dequeue_Multiple()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            //act
            var first = queue.Dequeue();
            var second = queue.Dequeue();
            var third = queue.Dequeue();
            var fourth = queue.Dequeue();

            //assert
            first.ShouldBeEquivalentTo(1);
            second.ShouldBeEquivalentTo(2);
            third.ShouldBeEquivalentTo(3);
            fourth.ShouldBeEquivalentTo(4);
            queue.Count.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void Should_Is_Empty_False()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();
            queue.Enqueue(1);

            //act
            var result = queue.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(false);
        }


        [Fact]
        public void Should_Is_Empty_True()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            var result = queue.IsEmpty();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Length_One_Enqueue_Dequeue()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            queue.Enqueue(1);
            var result = queue.Dequeue();
            Action act = () => queue.Dequeue();

            //assert
            result.ShouldBeEquivalentTo(1);
            queue.Count.ShouldBeEquivalentTo(0);
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Check_Length_One_Enqueue_Dequeue_Multiple()
        {
            //arrange
            var queue = new MyLinkedListQueue<int>();

            //act
            queue.Enqueue(1);
            queue.Dequeue();
            queue.Enqueue(2);
            var result = queue.Dequeue();

            //assert
            
            result.ShouldBeEquivalentTo(2);
            queue.Count.ShouldBeEquivalentTo(0);
        }
    }
}
