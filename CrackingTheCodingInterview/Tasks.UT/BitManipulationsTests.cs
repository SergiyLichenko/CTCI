﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class BitManipulationsTests
    {
        private readonly BitManipulations _bitManipulations;
        public BitManipulationsTests()
        {
            _bitManipulations = new BitManipulations();
        }

        [Fact]
        public void Insertion_Should_Check_Indexes()
        {
            //arrange
            int n = 0b0100_0000_0000_0000;
            int m = 0b10011;
            int i = 2;
            int j = 5;

            //act
            Action actEqual = () => _bitManipulations.Insertion(n, m, 5, 5);
            Action actIGreater = () => _bitManipulations.Insertion(n, m, 6, 5);
            Action actIHigh = () => _bitManipulations.Insertion(n, m, 31, 5);
            Action actILow = () => _bitManipulations.Insertion(n, m, -1, 5);
            Action actJLow = () => _bitManipulations.Insertion(n, m, 2, -2);
            Action actJHigh = () => _bitManipulations.Insertion(n, m, 6, 32);


            //assert
            actEqual.ShouldThrow<ArgumentOutOfRangeException>();
            actIGreater.ShouldThrow<ArgumentOutOfRangeException>();
            actIHigh.ShouldThrow<ArgumentOutOfRangeException>();
            actILow.ShouldThrow<ArgumentOutOfRangeException>();
            actJLow.ShouldThrow<ArgumentOutOfRangeException>();
            actJHigh.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Insertion_Should_Check_Example()
        {
            //arrange
            int n = 0b0100_0000_0000;
            int m = 0b10011;
            int i = 2;
            int j = 6;

            //act
            var result = _bitManipulations.Insertion(n, m, i, j);
           
            //assert
            result.ShouldBeEquivalentTo(0b10001001100);
        }

        [Fact]
        public void Insertion_Should_Check_Less_Space()
        {
            //arrange
            int n = 0b0101_0000_0000;
            int m = 0b10011;
            int i = 2;
            int j = 8;

            //act
            var result = _bitManipulations.Insertion(n, m, i, j);

            //assert
            result.ShouldBeEquivalentTo(0b10001001100);
        }
    }
}
