using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.SortingNSearching;
using Xunit;

namespace Tasks.UT.SortingNSearching
{
    public class RankFromStreamTests
    {
        [Fact]
        public void Should_Create()
        {
            //Act
            Action act = () => new RankFromStream();

            //Assert
            act.ShouldNotThrow();
        }

        [Fact]
        public void Should_Throw_GetRankOfNumber_If_Not_Contains()
        {
            //Arrange
            var subject = new RankFromStream();
            subject.Add(1);
            subject.Add(2);

            //Act
            Action act = () => subject.GetRankOfNumber(3);

            //Assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Check_Example()
        {
            //Arrange
            var subject = new RankFromStream();
            subject.Add(5);
            subject.Add(1);
            subject.Add(4);
            subject.Add(4);
            subject.Add(5);
            subject.Add(9);
            subject.Add(7);
            subject.Add(13);
            subject.Add(3);

            //Assert
            subject.GetRankOfNumber(1).ShouldBeEquivalentTo(0);
            subject.GetRankOfNumber(3).ShouldBeEquivalentTo(1);
            subject.GetRankOfNumber(4).ShouldBeEquivalentTo(3);
        }
    }
}
