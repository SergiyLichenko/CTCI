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

        [Fact]
        public void BinaryToString_Should_Check_Boundaries()
        {
            //arrange

            //act
            Action actLower = () => _bitManipulations.BinaryToString(0);
            Action actHigher = () => _bitManipulations.BinaryToString(1);

            //assert
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void BinaryToString_Should_Check_First_Division()
        {
            //arrange
            double n = 0.5;
            string res = "0.1";

            //act
            var result = _bitManipulations.BinaryToString(n);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void BinaryToString_Should_Check_Multiple_Division()
        {
            //arrange
            double n = 0.1875;
            string res = "0.0011";

            //act
            var result = _bitManipulations.BinaryToString(n);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void BinaryToString_Should_Check_Error()
        {
            //arrange
            double n = 0.72;

            //act
            var result = _bitManipulations.BinaryToString(n);

            //assert
            result.ShouldBeEquivalentTo("ERROR");
        }

        [Fact]
        public void FlipBitToWin_Should_Check_Example()
        {
            //arrange
            int n = 0b11011101111;

            //act
            var result = _bitManipulations.FlipBitToWin(n);

            //assert
            result.ShouldBeEquivalentTo(8);
        }

        [Fact]
        public void FlipBitToWin_Should_Check_Zero()
        {
            //arrange
            int n = 0;

            //act
            var result = _bitManipulations.FlipBitToWin(n);

            //assert
            result.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void FlipBitToWin_Should_Check_All_Ones()
        {
            //arrange
            int n = -1;

            //act
            var result = _bitManipulations.FlipBitToWin(n);

            //assert
            result.ShouldBeEquivalentTo(32);
        }

        [Fact]
        public void FlipBitToWin_Should_Check_Double_Zeros()
        {
            //arrange
            int n = 0b11111001111001;

            //act
            var result = _bitManipulations.FlipBitToWin(n);

            //assert
            result.ShouldBeEquivalentTo(6);
        }


        [Fact]
        public void FlipBitToWin_Should_Check_Double_Zeros_Multiple()
        {
            //arrange
            int n = 0b110100100101001111001;

            //act
            var result = _bitManipulations.FlipBitToWin(n);

            //assert
            result.ShouldBeEquivalentTo(5);
        }

        [Fact]
        public void NextNumber_Should_Check_Next_And_Previous_Simple()
        {
            //arrange
            int n = 0b1010;

            //act
            var result = _bitManipulations.NextNumber(n);

            //assert
            result[0].ShouldBeEquivalentTo(9);
            result[1].ShouldBeEquivalentTo(12);
        }

        [Fact]
        public void NextNumber_Should_Check_Previous_With_Shift()
        {
            //arrange
            int n = 0b100011111;

            //act
            var result = _bitManipulations.NextNumber(n);

            //assert
            result[0].ShouldBeEquivalentTo(0b011111100);
            result[1].ShouldBeEquivalentTo(0b100101111);
        }

        [Fact]
        public void NextNumber_Should_Check_Next_With_Shift()
        {
            //arrange
            int n = 0b101110000;

            //act
            var result = _bitManipulations.NextNumber(n);

            //assert
            result[0].ShouldBeEquivalentTo(0b101101000);
            result[1].ShouldBeEquivalentTo(0b110000011);
        }

        [Fact]
        public void NextNumber_Should_Throw_If_Cant_Get_Previous()
        {
            //arrange
            int n = 0b1111;

            //act
            Action act = () => _bitManipulations.NextNumber(n);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void NextNumber_Should_Throw_If_Cant_Get_Next()
        {
            //arrange
            int n = 0b111_1111_1111_1111_1111_1111_1111_1111;

            //act
            Action act = () => _bitManipulations.NextNumber(n);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void NextNumber_Should_Throw_If_Cant_Get_Next_With_Zeros()
        {
            //arrange
            uint n = 0b1111_1111_1111_1111_1111_0000_0000_0000;

            //act
            Action act = () => _bitManipulations.NextNumber((int)n);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void NextNumber_Should_Check_Zero()
        {
            //arrange
            int n = 0;

            //act
            Action act = () => _bitManipulations.NextNumber(n);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Convertion_Should_Check_Example()
        {
            //arrange
            uint a = 29;
            uint b = 15;

            //act
            int result = _bitManipulations.Convertion(a,  b);

            //assert
            result.ShouldBeEquivalentTo(2);
        }

        [Fact]
        public void Convertion_Should_Check_Max_Difference()
        {
            //arrange
            uint a = 0;
            uint b = uint.MaxValue;

            //act
            int result = _bitManipulations.Convertion(a, b);

            //assert
            result.ShouldBeEquivalentTo(32);
        }

        [Fact]
        public void Convertion_Should_Check_Zero_Difference()
        {
            //arrange
            uint a = 1515223;
            uint b = 1515223;

            //act
            int result = _bitManipulations.Convertion(a, b);

            //assert
            result.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public void PairwiseSwap_Should_Check_Example()
        {
            //arrange
            uint a = 0b01100111;
            uint res = 0b10011011;

            //act
            uint result = _bitManipulations.PairwiseSwap(a);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void PairwiseSwap_Should_Check_Zero()
        {
            //arrange
            uint a = 0;
            uint res = 0;

            //act
            uint result = _bitManipulations.PairwiseSwap(a);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void PairwiseSwap_Should_Check_AllOnes()
        {
            //arrange
            uint a = uint.MaxValue;
            uint res = uint.MaxValue;

            //act
            uint result = _bitManipulations.PairwiseSwap(a);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void PairwiseSwap_Should_Check_Max_Length()
        {
            //arrange
            uint a = 0b1001_0110_0110_0011_1001_0111_0111_0100;
            uint res = 0b0110_1001_1001_0011_0110_1011_1011_1000;

            //act
            uint result = _bitManipulations.PairwiseSwap(a);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void DrawLine_Should_Check_X_RowBoundaries()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int width = 16;
            int y = 4;

            //act
            Action equalAct = ()=> _bitManipulations.DrawLine(screen, width, 5, 5, y);
            Action x1BiggerAct = () => _bitManipulations.DrawLine(screen, width, 6, 5, y);
            Action x1LowerAct = () => _bitManipulations.DrawLine(screen, width, -1, 5, y);
            Action x1HigherAct = () => _bitManipulations.DrawLine(screen, width, width, 5, y);
            Action x2LowerAct = () => _bitManipulations.DrawLine(screen, width, 1, -1, y);
            Action x2HigherAct = () => _bitManipulations.DrawLine(screen, width, 5, width, y);


            //assert
            equalAct.ShouldThrow<ArgumentOutOfRangeException>();
            x1BiggerAct.ShouldThrow<ArgumentOutOfRangeException>();
            x1LowerAct.ShouldThrow<ArgumentOutOfRangeException>();
            x1HigherAct.ShouldThrow<ArgumentOutOfRangeException>();
            x2LowerAct.ShouldThrow<ArgumentOutOfRangeException>();
            x2HigherAct.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void DrawLine_Should_Check_Y_Boundaries()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int x1 = 1;
            int x2 = 4;
            int width = 16;

            //act
            Action yLowerAct = () => _bitManipulations.DrawLine(screen, width, x1, x2, -1);
            Action yHigherAct = () => _bitManipulations.DrawLine(screen, width, x1, x2, 7);


            //assert
            yLowerAct.ShouldThrow<ArgumentOutOfRangeException>();
            yHigherAct.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void DrawLine_Should_Check_Width()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int x1 = 1;
            int x2 = 4;
            int y = 4;

            //act
            Action widthLowerAct = () => _bitManipulations.DrawLine(screen, -1, x1, x2, y);
            Action widthHigherAct = () => _bitManipulations.DrawLine(screen, 97, x1, x2, y);
            Action notDividableAct = () => _bitManipulations.DrawLine(screen, 9, x1, x2, y);

            //assert
            widthLowerAct.ShouldThrow<ArgumentOutOfRangeException>();
            widthHigherAct.ShouldThrow<ArgumentOutOfRangeException>();
            notDividableAct.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void DrawLine_Should_Throw_If_Screen_Null()
        {
            //arrange
            int width = 16;
            int x1 = 1;
            int x2 = 4;
            int y = 4;

            //act
            Action act = () => _bitManipulations.DrawLine(null, -1, x1, x2, y);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void DrawLine_Should_Check_Example()
        {
            //arrange
            byte[] screen = {234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202};
            int width = 16;
            int x1 = 3;
            int x2 = 11;
            int y = 3;
            string res = "\n\n\n   110001001    \n\n";

            //act
            string result = _bitManipulations.DrawLine(screen, width, x1,x2,y);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void DrawLine_Should_Check_Same_Byte()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int width = 16;
            int x1 = 0;
            int x2 = 3;
            int y = 1;
            string res = "\n1110            \n\n\n\n";

            //act
            string result = _bitManipulations.DrawLine(screen, width, x1, x2, y);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void DrawLine_Should_Check_Full_Byte()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int width = 16;
            int x1 = 8;
            int x2 = 15;
            int y = 5;
            string res = "\n\n\n\n\n        11001010";

            //act
            string result = _bitManipulations.DrawLine(screen, width, x1, x2, y);

            //assert
            result.ShouldBeEquivalentTo(res);
        }

        [Fact]
        public void DrawLine_Should_Check_Full_Line()
        {
            //arrange
            byte[] screen = { 234, 212, 234, 2, 143, 52, 24, 145, 23, 44, 185, 202 };
            int width = 16;
            int x1 = 0;
            int x2 = 15;
            int y = 4;
            string res = "\n\n\n\n0001011100101100\n";

            //act
            string result = _bitManipulations.DrawLine(screen, width, x1, x2, y);

            //assert
            result.ShouldBeEquivalentTo(res);
        }
    }
}
