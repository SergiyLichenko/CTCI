using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace DataStructures.UT
{
    public class MyRedBlackTreeTests
    {
        [Fact]
        public void Should_Create_Default()
        {
            //arrange

            //act
            var result = new MyRedBlackTree<int>();

            //assert
            result.Count.ShouldBeEquivalentTo(0);
            result.Root.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Insert_Root()
        {
            //arrange
            var result = new MyRedBlackTree<int>();

            //act
            result.Insert(1);

            //assert
            result.Count.ShouldBeEquivalentTo(1);

            result.Root.Data.ShouldBeEquivalentTo(1);
            result.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            result.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            result.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            result.Root.Left.IsNull.ShouldBeEquivalentTo(true);
            result.Root.Right.IsNull.ShouldBeEquivalentTo(true);
            result.Root.Left.Parent.ShouldBeEquivalentTo(result.Root);
            result.Root.Right.Parent.ShouldBeEquivalentTo(result.Root);
        }

        [Fact]
        public void Should_Check_Insert_Recolor_Root()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(15);

            //assert
            tree.Count.ShouldBeEquivalentTo(4);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(15);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Insert_Recolor_Recursive()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(-20);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(2);
            tree.Insert(8);
            tree.Insert(27);
            tree.Insert(4);

            //assert
            tree.Count.ShouldBeEquivalentTo(11);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(6);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(25);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(2);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(8);
            tree.Root.Left.Right.Left.Right.Data.ShouldBeEquivalentTo(4);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Left_Left_Rotation_Simple()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(13);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(13);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(20);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Left_Right_Rotation_Simple()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(7);
            tree.Insert(15);
            tree.Insert(17);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(17);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(20);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Left_Case_Complex()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(-20);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(30);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(4);

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            tree.Root.Data.ShouldBeEquivalentTo(6);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(1);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(9);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Left.Right.Right.Data.ShouldBeEquivalentTo(4);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(30);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Right_Right_Rotation_Simple()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(7);
            tree.Insert(30);
            tree.Insert(40);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(40);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Right_Left_Rotation_Simple()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(7);
            tree.Insert(30);
            tree.Insert(25);

            //assert
            tree.Count.ShouldBeEquivalentTo(6);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(25);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(30);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Right_Case_Complex()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(20);
            tree.Insert(-20);
            tree.Insert(6);
            tree.Insert(15);
            tree.Insert(25);
            tree.Insert(12);
            tree.Insert(17);
            tree.Insert(16);

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            tree.Root.Data.ShouldBeEquivalentTo(15);
            tree.Root.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(12);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(17);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(25);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Left.Right.Data.ShouldBeEquivalentTo(6);
            tree.Root.Right.Left.Left.Data.ShouldBeEquivalentTo(16);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
        }

        [Fact]
        public void Should_Check_Example()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(-10);
            tree.Insert(15);
            tree.Insert(17);
            tree.Insert(40);
            tree.Insert(50);
            tree.Insert(60);

            //assert
            tree.Count.ShouldBeEquivalentTo(8);

            tree.Root.Data.ShouldBeEquivalentTo(17);
            tree.Root.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(50);
            tree.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(60);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Find()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(30);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(35);

            //act
            var result = tree.Find(30);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Right);
        }

        [Fact]
        public void Should_Not_Find_Null_Node()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(-10);
            tree.Insert(0);

            //act
            var result = tree.Find(0);

            //assert
            result.ShouldBeEquivalentTo(tree.Root.Right);
        }

        [Fact]
        public void Should_Find_Return_Null_If_Not_Contains()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(30);
            tree.Insert(5);
            tree.Insert(7);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(35);

            //act
            var result = tree.Find(300);

            //assert
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Remove_Throw_If_Null()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            Action act = () => tree.Remove(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }


        [Fact]
        public void Should_Remove_Check_Single_Red_Node_Case()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(30);
            tree.Insert(-5);
            tree.Insert(7);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(35);

            var node = tree.Find(30);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(7);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Right.Data.ShouldBeEquivalentTo(35);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(7);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(38);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Remove_Check_Black_Node_And_Single_Red_Child_Case()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(5);
            tree.Insert(30);
            tree.Insert(-5);
            tree.Insert(7);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(32);
            tree.Insert(41);
            tree.Insert(35);

            var node = tree.Find(30);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(32);
            tree.Root.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(38);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(35);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(41);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Left.Left.Right.Data.ShouldBeEquivalentTo(7);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);

            tree.Root.Left.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Remove_Check_Black_Node_And_Single_Red_Child_Case_Child()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(5);
            tree.Insert(10);

            var node = tree.Find(10);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(1);

            tree.Root.Data.ShouldBeEquivalentTo(5);
            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Remove_Check_Black_Node_And_Single_Red_Child_Case_Root()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(5);
            tree.Insert(10);

            var node = tree.Find(5);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(1);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Remove_Check_Single_Root()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(5);

            var node = tree.Find(5);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(0);
            tree.Root.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Remove_Check_Rotation_Case_Three_And_One()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(25);

            var node = tree.Find(25);
            tree.Remove(node);

            node = tree.Find(-10);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(2);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.ShouldBeEquivalentTo(null);
            tree.Root.Left.Right.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Remove_Check_Rotation_Case_Four()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(38);
            tree.Insert(40);

            var node = tree.Find(40);
            tree.Remove(node);

            node = tree.Find(20);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(4);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(38);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Right.Left.Left.ShouldBeEquivalentTo(null);
            tree.Root.Right.Left.Right.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Remove_Check_Rotation_Case_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(25);
            tree.Insert(40);

            var node = tree.Find(-10);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(4);

            tree.Root.Data.ShouldBeEquivalentTo(30);
            tree.Root.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(25);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Right.Right.Left.ShouldBeEquivalentTo(null);
            tree.Root.Right.Right.Right.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void Should_Remove_Check_Multiple_Rotations_Cases_Two_Five_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(15);
            tree.Insert(50);
            tree.Insert(80);

            var node = tree.Find(-10);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(7);

            tree.Root.Data.ShouldBeEquivalentTo(40);
            tree.Root.Left.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Data.ShouldBeEquivalentTo(60);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(50);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(80);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);

            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Multiple_Rotations_Cases_Three_Five_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-30);
            tree.Insert(50);
            tree.Insert(-40);
            tree.Insert(-20);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(-70);
            tree.Insert(15);
            tree.Insert(40);
            tree.Insert(45);


            var node = tree.Find(-70);
            tree.Remove(node);

            node = tree.Find(-40);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(30);
            tree.Root.Left.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(50);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(15);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(40);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(70);
            tree.Root.Left.Left.Right.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Right.Left.Right.Data.ShouldBeEquivalentTo(45);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Right);
            tree.Root.Left.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Right);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Multiple_Rotations_Cases_Two_Four()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(-30);
            tree.Insert(50);
            tree.Insert(80);
            tree.Insert(90);

            var node = tree.Find(10);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            tree.Root.Data.ShouldBeEquivalentTo(20);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(60);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(40);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(80);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Right.Left.Right.Data.ShouldBeEquivalentTo(50);
            tree.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(90);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Left);
            tree.Root.Left.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Left);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left.Right);
            tree.Root.Right.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left.Right);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Right);
            tree.Root.Right.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Right);

            tree.Root.Left.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Black_Node_With_Red_Left_Child()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(-30);

            var node = tree.Find(-20);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(7);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(-5);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(60);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Case_Four()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(-20);
            tree.Insert(0);
            tree.Insert(-30);

            var node = tree.Find(-30);
            tree.Remove(node);
            node = tree.Find(0);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(4);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Data.ShouldBeEquivalentTo(30);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-20);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);

            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Case_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(-20);
            tree.Insert(0);

            var node = tree.Find(30);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(4);

            tree.Root.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Right.Data.ShouldBeEquivalentTo(10);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(0);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);

            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Case_Three_And_One()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(30);
            tree.Insert(25);

            var node = tree.Find(25);
            tree.Remove(node);

            node = tree.Find(30);
            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(2);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-10);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);

            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);

            tree.Root.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Multiple_Rotations_Cases_Three_Five_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-30);
            tree.Insert(50);
            tree.Insert(-40);
            tree.Insert(-20);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(100);
            tree.Insert(-25);
            tree.Insert(-15);
            tree.Insert(-27);

            var node = tree.Find(100);
            tree.Remove(node);

            node = tree.Find(70);
            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(9);

            tree.Root.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Right.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-40);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(-25);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(-15);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(50);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(-27);
            tree.Root.Right.Right.Left.Data.ShouldBeEquivalentTo(30);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);
            tree.Root.Left.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Left);
            tree.Root.Right.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Left);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Multiple_Rotations_Cases_Two_Five_Six()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(0);
            tree.Insert(-30);
            tree.Insert(-15);
            tree.Insert(5);

            var node = tree.Find(40);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(7);

            tree.Root.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Right.Data.ShouldBeEquivalentTo(5);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(-15);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(0);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(10);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);

            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void Should_Remove_Check_Mirror_Multiple_Rotations_Cases_Two_Four()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(-30);
            tree.Insert(-15);
            tree.Insert(-40);

            var node = tree.Find(-5);

            //act
            tree.Remove(node);

            //assert
            tree.Count.ShouldBeEquivalentTo(10);

            tree.Root.Data.ShouldBeEquivalentTo(10);
            tree.Root.Left.Data.ShouldBeEquivalentTo(-20);
            tree.Root.Right.Data.ShouldBeEquivalentTo(40);
            tree.Root.Left.Left.Data.ShouldBeEquivalentTo(-30);
            tree.Root.Left.Right.Data.ShouldBeEquivalentTo(-10);
            tree.Root.Right.Left.Data.ShouldBeEquivalentTo(20);
            tree.Root.Right.Right.Data.ShouldBeEquivalentTo(60);
            tree.Root.Left.Left.Left.Data.ShouldBeEquivalentTo(-40);
            tree.Root.Left.Right.Left.Data.ShouldBeEquivalentTo(-15);
            tree.Root.Right.Right.Right.Data.ShouldBeEquivalentTo(70);

            tree.Root.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Left.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Red);
            tree.Root.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Red);

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(false);

            tree.Root.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Parent.ShouldBeEquivalentTo(null);
            tree.Root.Left.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Right.Parent.ShouldBeEquivalentTo(tree.Root);
            tree.Root.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left);
            tree.Root.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right);
            tree.Root.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);

            tree.Root.Left.Left.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Left);
            tree.Root.Left.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left.Left);
            tree.Root.Left.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Left);
            tree.Root.Left.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);
            tree.Root.Left.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right.Left);
            tree.Root.Left.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Left.Right);
            tree.Root.Right.Left.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Left.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Left);
            tree.Root.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right);
            tree.Root.Right.Right.Right.Left.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Right);
            tree.Root.Right.Right.Right.Right.Parent.ShouldBeEquivalentTo(tree.Root.Right.Right.Right);

            tree.Root.Left.Left.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Left.Right.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Left.Right.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Left.IsNull.ShouldBeEquivalentTo(true);
            tree.Root.Right.Right.Right.Right.IsNull.ShouldBeEquivalentTo(true);

            tree.Root.Left.Left.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.Left.IsDoubleBlack.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.Right.IsDoubleBlack.ShouldBeEquivalentTo(false);

            tree.Root.Left.Left.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Left.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Left.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Left.Color.ShouldBeEquivalentTo(NodeColor.Black);
            tree.Root.Right.Right.Right.Right.Color.ShouldBeEquivalentTo(NodeColor.Black);
        }

        [Fact]
        public void LoadTest_Should_Check_Valid_Creation_Deletion_Multiple()
        {
            //arrange
            int treesCount = 1000;
            int nodesCount = 20;
            Random random = new Random();

            //act

            //assert

            for (int i = 0; i < treesCount; i++)
            {
                var tree = new MyRedBlackTree<int>();
                var currentNumbers = new HashSet<int>();

                while (tree.Count != nodesCount)
                {
                    bool toInsert = random.Next() > Int32.MaxValue/5;
                    if (toInsert)
                    {
                        var number = random.Next();
                        if(currentNumbers.Contains(number))
                            continue;
                        tree.Insert(number);
                        currentNumbers.Add(number);
                        tree.IsValid().ShouldBeEquivalentTo(true);
                    }
                    else
                        RemoveFromTree(tree, currentNumbers);
                }
                while (tree.Count != 0)
                    RemoveFromTree(tree, currentNumbers);
                tree.IsValid().ShouldBeEquivalentTo(true);
                tree.Root.ShouldBeEquivalentTo(null);
                tree.Count.ShouldBeEquivalentTo(0);
            }

            void RemoveFromTree(MyRedBlackTree<int> tree, HashSet<int> currentNumbers)
            {
                if (tree.Count == 0)
                    return;
                var index = random.Next(0, currentNumbers.Count);
                var element = currentNumbers.ElementAt(index);
                var node = tree.Find(element);

                node.Should().NotBeNull();
                node.IsNull.ShouldBeEquivalentTo(false);
                node.IsDoubleBlack.ShouldBeEquivalentTo(false);
                node.Data.ShouldBeEquivalentTo(element);

                tree.IsValid().ShouldBeEquivalentTo(true);
                tree.Remove(node);
                tree.IsValid().ShouldBeEquivalentTo(true);
                currentNumbers.Remove(element);
            }
        }

        [Fact]
        public void Should_Check_Is_Valid_True()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(-30);
            tree.Insert(-15);
            tree.Insert(-40);

            //act
            var result = tree.IsValid();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Is_Valid_False_When_Root_Is_Red()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Root.Color = NodeColor.Red;

            //act
            var result = tree.IsValid();

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Is_Valid_Empty_Tree()
        {
            //arrange
            var tree = new MyRedBlackTree<int>();

            //act
            var result = tree.IsValid();

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Check_Is_Valid_False_When_Double_Red()
        {
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(-30);
            tree.Insert(-15);
            tree.Insert(-40);

            tree.Root.Left.Left.Right.Color = NodeColor.Red;
            //act
            var result = tree.IsValid();

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Check_Is_Valid_False_When_Different_Number_Of_Black_Nodes()
        {
            var tree = new MyRedBlackTree<int>();
            tree.Insert(10);
            tree.Insert(-10);
            tree.Insert(40);
            tree.Insert(-20);
            tree.Insert(-5);
            tree.Insert(20);
            tree.Insert(60);
            tree.Insert(70);
            tree.Insert(-30);
            tree.Insert(-15);
            tree.Insert(-40);

            tree.Root.Right.Right.Right.Color = NodeColor.Black;
            //act
            var result = tree.IsValid();

            //assert
            result.ShouldBeEquivalentTo(false);
        }
    }
}
