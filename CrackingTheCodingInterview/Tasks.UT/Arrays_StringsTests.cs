using System;

using FluentAssertions;
using Xunit;

namespace Tasks.UT
{
    public class Arrays_StringsTests
    {
        private Arrays_Strings arraysStrings;
        public Arrays_StringsTests()
        {
            arraysStrings = new Arrays_Strings();
        }

        [Fact]
        public void Should_Determine_Unique_String()
        {
            //arrange
            string str = "123";

            //act
            var result = arraysStrings.IsUnique(str);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Determine_Not_Unique_String()
        {
            //arrange
            string str = "11";

            //act
            var result = arraysStrings.IsUnique(str);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Determine_Empty_Unique_String()
        {
            //arrange
            string str = "";

            //act
            var result = arraysStrings.IsUnique(str);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_Determine_Throw_If_String_Is_Null()
        {
            //arrange
            string str = null;

            //act
            Action act = () => arraysStrings.IsUnique(str);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Determine_Not_Unique_When_Max_Length()
        {
            //arrange
            string str = new string('-', 257);

            //act
            var result = arraysStrings.IsUnique(str);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_CheckPermutation_Throw_When_Is_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.CheckPermutations(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_CheckPermutation_Return_False_When_Length_Is_Different()
        {
            //arrange
            string s1 = "1";
            string s2 = "22";

            //act
            var result = arraysStrings.CheckPermutations(s1, s2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_CheckPermutation()
        {
            //arrange
            string s1 = "123";
            string s2 = "321";

            //act
            var result = arraysStrings.CheckPermutations(s1, s2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Should_CheckPermutation_False_When_Different_Character()
        {
            //arrange
            string s1 = "123";
            string s2 = "323";

            //act
            var result = arraysStrings.CheckPermutations(s1, s2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void URLify_Should_Check_Example()
        {
            //arrange
            string str = "Mr John Smith    ";
            int length = 13;
            string strRes = "Mr%20John%20Smith";

            //act
            var result = arraysStrings.URLify(str, length);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void URLify_Should_Throw_If_String_Is_Null()
        {
            //arrange
            int length = 13;

            //act
            Action act = () => arraysStrings.URLify(null, length);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void URLify_Should_Throw_If_Length_Is_Negative()
        {
            //arrange
            string str = "Mr John Smith";
            int length = -1;

            //act
            Action act = () => arraysStrings.URLify(str, length);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void URLify_Should_Check_Double_Space()
        {
            //arrange
            string str = "Mr  John Smith";
            int length = 13;
            string strRes = "Mr%20John%20Smith";

            //act
            var result = arraysStrings.URLify(str, length);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void PalindromePermutation_Should_Check_Example()
        {
            //arrange
            string str = "Tact Coa";

            //act
            var result = arraysStrings.PalindromePermutation(str);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void PalindromePermutation_Should_Trow_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.PalindromePermutation(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void PalindromePermutation_Should_Check_Empty_String()
        {
            //arrange
            string str = "";

            //act
            var result = arraysStrings.PalindromePermutation(str);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void PalindromePermutation_Should_Check_False()
        {
            //arrange
            string str = "Tact Caaf";

            //act
            var result = arraysStrings.PalindromePermutation(str);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void OneAway_Should_First_Example()
        {
            //arrange
            string str1 = "pale";
            string str2 = "ple";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void OneAway_Should_Second_Example()
        {
            //arrange
            string str1 = "pales";
            string str2 = "pale";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void OneAway_Should_Third_Example()
        {
            //arrange
            string str1 = "pale";
            string str2 = "bale";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void OneAway_Should_Fourth_Example()
        {
            //arrange
            string str1 = "pale";
            string str2 = "bake";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void OneAway_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.OneAway(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void OneAway_Should_Check_Empty_Strings()
        {
            //arrange
            string str1 = "";
            string str2 = "";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void OneAway_Should_Check_Double_Plus_Difference()
        {
            //arrange
            string str1 = "paless";
            string str2 = "pale";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void OneAway_Should_Check_Empty_And_One_Character()
        {
            //arrange
            string str1 = "1";
            string str2 = "";

            //act
            var result = arraysStrings.OneAway(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StringCompression_Should_Check_Example()
        {
            //arrange
            string str = "aabcccccaaa";
            string strRes = "a2b1c5a3";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void StringCompression_Should_Trow_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.StringCompression(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StringCompression_Should_Check_Empty_String()
        {
            //arrange
            string str = "";
            string strRes = "";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void StringCompression_Should_Check_Not_Compressed()
        {
            //arrange
            string str = "aert";
            string strRes = "aert";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void StringCompression_Should_Check_Equal_Length()
        {
            //arrange
            string str = "aart";
            string strRes = "aart";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void StringCompression_Should_Check_Compress()
        {
            //arrange
            string str = "aaaaart";
            string strRes = "a5r1t1";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void StringCompression_Should_Check_End()
        {
            //arrange
            string str = "aaaartt";
            string strRes = "a4r1t2";

            //act
            var result = arraysStrings.StringCompression(str);

            //assert
            result.ShouldBeEquivalentTo(strRes);
        }

        [Fact]
        public void RotateMatrix_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.RotateMatrix(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void RotateMatrix_Should_Throw_If_Matrix_Not_Square()
        {
            //arrange
            var matrix = new int[1, 2];
            //act
            Action act = () => arraysStrings.RotateMatrix(matrix);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void RotateMatrix_Should_Check_Empty_Matrix()
        {
            //arrange
            var matrix = new int[0, 0];
            var matrixResult = new int[0, 0];

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }
        [Fact]
        public void RotateMatrix_Should_Check_Size_One()
        {
            //arrange
            var matrix = new int[1, 1] { { 1 } };
            var matrixResult = new int[1, 1] { { 1 } };

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void RotateMatrix_Should_Check_Size_Two()
        {
            //arrange
            var matrix = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            var matrixResult = new int[2, 2] { { 3, 1 }, { 4, 2 } };

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }
        [Fact]
        public void RotateMatrix_Should_Check_Size_Three()
        {
            //arrange
            var matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            var matrixResult = new int[3, 3] { { 7, 4, 1 }, { 8, 5, 2 }, { 9, 6, 3 } };

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void RotateMatrix_Should_Check_Size_Four()
        {
            //arrange
            var matrix = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            var matrixResult = new int[4, 4] { { 13, 9, 5, 1 }, { 14, 10, 6, 2 }, { 15, 11, 7, 3 }, { 16, 12, 8, 4 } };

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void RotateMatrix_Should_Check_Size_Five()
        {
            //arrange
            var matrix = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            var matrixResult = new int[5, 5] { { 21, 16, 11, 6, 1 }, { 22, 17, 12, 7, 2 }, { 23, 18, 13, 8, 3 }, { 24, 19, 14, 9, 4 }, { 25, 20, 15, 10, 5 } };

            //act
            var result = arraysStrings.RotateMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
                for (int j = 0; j < matrixResult.GetLength(1); j++)
                    matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void ZeroMatrix_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.ZeroMatrix(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ZeroMatrix_Should_Empty_Matrix()
        {
            //arrange
            var matrix = new int[0, 0] {  };
            var matrixResult = new int[0, 0] {  };

            //act
            var result = arraysStrings.ZeroMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
            for (int j = 0; j < matrixResult.GetLength(1); j++)
                matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void ZeroMatrix_Should_One_Size()
        {
            //arrange
            var matrix = new int[1, 1] { {2}};
            var matrixResult = new int[1, 1] {{2} };

            //act
            var result = arraysStrings.ZeroMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
            for (int j = 0; j < matrixResult.GetLength(1); j++)
                matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void ZeroMatrix_Should_Zero_Matrix()
        {
            //arrange
            var matrix = new int[3,3] { {1,0,3},{8,5,7},{6,9,0}};
            var matrixResult = new int[3, 3] {{0,0,0},{8,0,0},{0,0,0} };

            //act
            var result = arraysStrings.ZeroMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
            for (int j = 0; j < matrixResult.GetLength(1); j++)
                matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void ZeroMatrix_Should_Zero_Matrix_Without_Zeros()
        {
            //arrange
            var matrix = new int[3, 3] { { 1, 2, 3 }, { 8, 5, 7 }, { 6, 9, 3 } };
            var matrixResult = new int[3, 3] { { 1, 2, 3 }, { 8, 5, 7 }, { 6, 9, 3 } };

            //act
            var result = arraysStrings.ZeroMatrix(matrix);

            //assert
            result.GetLength(0).ShouldBeEquivalentTo(matrixResult.GetLength(0));
            result.GetLength(1).ShouldBeEquivalentTo(matrixResult.GetLength(1));

            for (int i = 0; i < matrixResult.GetLength(0); i++)
            for (int j = 0; j < matrixResult.GetLength(1); j++)
                matrixResult[i, j].ShouldBeEquivalentTo(result[i, j]);
        }

        [Fact]
        public void StringRotation_Should_Throw_If_Null()
        {
            //arrange

            //act
            Action act = () => arraysStrings.StringRotation(null, null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void StringRotation_Should_Check_Example()
        {
            //arrange
            string str1 = "waterbottle";
            string str2 = "erbottlewat";

            //act
            var result = arraysStrings.StringRotation(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StringRotation_Should_Empty_String()
        {
            //arrange
            string str1 = "";
            string str2 = "";

            //act
            var result = arraysStrings.StringRotation(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StringRotation_Should_Check_Lenght_One()
        {
            //arrange
            string str1 = "1";
            string str2 = "1";

            //act
            var result = arraysStrings.StringRotation(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void StringRotation_Should_Check_Fail()
        {
            //arrange
            string str1 = "123";
            string str2 = "132";

            //act
            var result = arraysStrings.StringRotation(str1, str2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }
    }
}
