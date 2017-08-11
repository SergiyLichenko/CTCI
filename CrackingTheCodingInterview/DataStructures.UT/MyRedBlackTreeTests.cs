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
    }
}
