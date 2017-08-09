using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyAVLTreeTests
    {
        [Fact]
        public void Should_Insert()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(1);

            //assert
            tree.Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Rotate_Left_Left()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);
            tree.Insert(-10);
            tree.Insert(-20);


            //assert
            tree.Count.ShouldBeEquivalentTo(5);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(20);
        }


        [Fact]
        public void Should_Rotate_Left_Right()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);
            tree.Insert(-10);
            tree.Insert(-5);

            //assert
            tree.Count.ShouldBeEquivalentTo(5);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(20);
        }

        [Fact]
        public void Should_Rotate_Right_Right()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(30);
            tree.Insert(40);
            tree.Insert(20);

            //assert
            tree.Count.ShouldBeEquivalentTo(5);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(40);
        }

        [Fact]
        public void Should_Rotate_Right_Left()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(30);

            //assert
            tree.Count.ShouldBeEquivalentTo(5);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(40);
        }


        [Fact]
        public void Should_Insert_Check_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(5);
            tree.Insert(-2);
            tree.Insert(-5);
            tree.Insert(-8);

            //assert
            tree.Count.ShouldBeEquivalentTo(8);

            tree.Root.Data.ShouldBeEquivalentTo(2);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-2);
            tree.Root.Right.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(1);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(3);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(6);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-8);
        }

        [Fact]
        public void Should_Insert_Check_Complex_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();
            tree.Insert(13);
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(11);
            tree.Insert(16);
            tree.Insert(4);
            tree.Insert(8);

            //act
            tree.Insert(3);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(13);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(4);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(null);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(16);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(3);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(11);
        }
    }
}
