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

            tree.Root.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Left.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Left.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.IsNull.ShouldBeEquivalentTo(false);
            tree.Root.Right.Right.Right.IsNull.ShouldBeEquivalentTo(false);
        }
    }
}
