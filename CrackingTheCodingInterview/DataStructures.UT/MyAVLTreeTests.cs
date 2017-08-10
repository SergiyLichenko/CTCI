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
        public void Should_Insert_Left_Left_Complex_Example()
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

        }

        [Fact]
        public void Should_Insert_Left_Right_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();
            tree.Insert(5);
            tree.Insert(-10);
            tree.Insert(11);
            tree.Insert(-11);
            tree.Insert(-5);


            //act
            tree.Insert(-6);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(-5);
            tree.Root.TreeHeight.ShouldBeEquivalentTo(4);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-6);
            tree.Root.Left.TreeHeight.ShouldBeEquivalentTo(3);
            tree.Root.Right.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Left.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(11);
            tree.Root.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-11);
            tree.Root.Left.Left.Left.TreeHeight.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_Right_Left_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(5);
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(30);

            //assert
            tree.Count.ShouldBeEquivalentTo(5);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.TreeHeight.ShouldBeEquivalentTo(3);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Right.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Left.TreeHeight.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_Left_Right_Complex_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(13);
            tree.Insert(10);
            tree.Insert(15);
            tree.Insert(5);
            tree.Insert(11);
            tree.Insert(16);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(7);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(13);
            tree.Root.TreeHeight.ShouldBeEquivalentTo(4);

            tree.Root.Left.Data.ShouldBeEquivalentTo(6);
            tree.Root.Left.TreeHeight.ShouldBeEquivalentTo(3);
            tree.Root.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.TreeHeight.ShouldBeEquivalentTo(2);

            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.Left.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Right.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(16);
            tree.Root.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);

            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(4);
            tree.Root.Left.Left.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(7);
            tree.Root.Left.Right.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(11);
            tree.Root.Left.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_Right_Right_Complex_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(30);
            tree.Insert(5);
            tree.Insert(35);
            tree.Insert(32);
            tree.Insert(40);
            tree.Insert(45);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(35);
            tree.Root.TreeHeight.ShouldBeEquivalentTo(3);

            tree.Root.Left.Data.ShouldBeEquivalentTo(30);
            tree.Root.Left.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Right.TreeHeight.ShouldBeEquivalentTo(2);

            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(32);
            tree.Root.Left.Right.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(45);
            tree.Root.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void Should_Insert_Right_Left_Complex_Example()
        {
            //arrange
            var tree = new MyAVLTree<int>();

            //act
            tree.Insert(5);
            tree.Insert(2);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(3);
            tree.Insert(9);
            tree.Insert(16);

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            tree.Root.Data.ShouldBeEquivalentTo(5);
            tree.Root.TreeHeight.ShouldBeEquivalentTo(4);
            
            tree.Root.Left.Data.ShouldBeEquivalentTo(2);
            tree.Root.Left.TreeHeight.ShouldBeEquivalentTo(3);
            tree.Root.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.TreeHeight.ShouldBeEquivalentTo(3);

            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(1);
            tree.Root.Left.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(4);
            tree.Root.Left.Right.TreeHeight.ShouldBeEquivalentTo(2);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(6);
            tree.Root.Right.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.TreeHeight.ShouldBeEquivalentTo(2);

            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(3);
            tree.Root.Left.Right.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Left.TreeHeight.ShouldBeEquivalentTo(1);
            tree.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(16);
            tree.Root.Right.Right.Right.TreeHeight.ShouldBeEquivalentTo(1);
        }
    }
}
