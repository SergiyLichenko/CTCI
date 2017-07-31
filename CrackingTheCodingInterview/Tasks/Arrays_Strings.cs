using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class Arrays_Strings
    {
        public bool IsUnique(string str)
        {
            if (str == null)
                throw new ArgumentNullException();
            if (str.Length > 256)
                return false; //assume ASCII

            str = string.Join("", str.ToCharArray().OrderBy(x => x).ToList());

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                    return false;
            }

            return true;
        }

        public bool CheckPermutations(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                throw new ArgumentNullException();
            if (str1.Length != str2.Length)
                return false;

            var dict = new Dictionary<char, int>();
            foreach (var item in str1)
            {
                if (!dict.ContainsKey(item))
                    dict[item] = 0;
                dict[item]++;
            }

            foreach (var item in str2)
            {
                if (!dict.ContainsKey(item) || dict[item] == 0)
                    return false;
                dict[item]--;
            }

            return dict.Values.Sum() == 0;
        }

        public string URLify(string input, int length)
        {
            if (input == null)
                throw new ArgumentNullException();
            if (length < 0)
                throw new ArgumentOutOfRangeException();

            var result = new char[length];
            int index = 0;
            bool isSpace = false;

            foreach (char item in input)
            {
                if (item == ' ' && isSpace)
                    continue;

                isSpace = item == ' ';
                result[index++] = item;

                if (index == length)
                    break;
            }

            var builder = new StringBuilder(length);
            foreach (char item in result)
                builder.Append(item == ' ' ? "%20" : item.ToString());

            return builder.ToString();
        }

        public bool PalindromePermutation(string input)
        {
            if (input == null)
                throw new ArgumentNullException();
            input = new string(input.Where(x => x != ' ').ToArray()).ToLower();

            var dict = input.GroupBy(x => x).ToDictionary(x => x.First(), x => x.Count());

            if (input.Length % 2 == 0)
                return dict.All(item => dict[item.Key] % 2 == 0);

            bool isOdd = false;

            foreach (var item in dict)
            {
                if (isOdd && item.Value % 2 == 1)
                    return false;

                if (item.Value % 2 == 1)
                    isOdd = true;
            }

            return true;
        }

        public bool OneAway(string str1, string str2)
        {
            if (str1 == null || str2 == null)
                throw new ArgumentNullException();
            var difLength = Math.Abs(str1.Length - str2.Length);

            if (difLength > 1)
                return false;

            var map = new Dictionary<char, int>();
            foreach (var item in str1)
            {
                if (!map.ContainsKey(item))
                    map[item] = 0;
                map[item]++;
            }
            foreach (var item in str2)
            {
                if (!map.ContainsKey(item))
                    map[item] = 0;
                map[item]--;
            }
            var count = map.Count(x => x.Value == 1 || x.Value == -1);
            if (difLength == 1)
                return count == 1;
            return count == 2 || count == 0;
        }

        public string StringCompression(string input)
        {
            if (input == null)
                throw new ArgumentNullException();

            var builder = new StringBuilder();
            for (int i = 0; i < input.Length - 1; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < input.Length; j++)
                {
                    currentCount++;
                    if (input[i] == input[j])
                    {
                        if (j == input.Length - 1)
                            i = j - 1;
                        continue;
                    }

                    currentCount--;
                    i = j - 1;
                    break;
                }

                builder.Append(input[i] + currentCount.ToString());
            }
            if (input.Length > 1 && input.Last() != input[input.Length - 2])
                builder.Append(input.Last() + "1");

            var result = builder.ToString();
            return result.Length < input.Length ? result : input;
        }

        public int[,] RotateMatrix(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException();

            for (int i = 0; i < matrix.GetLength(0) / 2; i++)
            {
                for (int j = i; j < matrix.GetLength(1) - i - 1; j++)
                {
                    var temp = matrix[i, j];
                    matrix[i, j] = matrix[matrix.GetLength(0) - 1 - j, i];
                    matrix[matrix.GetLength(0) - 1 - j, i] = matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(1) - 1 - j];
                    matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(1) - 1 - j] =
                        matrix[j, matrix.GetLength(1) - 1 - i];
                    matrix[j, matrix.GetLength(1) - 1 - i] = temp;
                }
            }

            return matrix;
        }

        public int[,] ZeroMatrix(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != 0)
                        continue;
                    matrix[i, j] = Int32.MinValue;

                    for (int k = 0; k < matrix.GetLength(0); k++)
                        matrix[k, j] = matrix[k, j] == 0 ? 0 : Int32.MinValue;
                    for (int k = 0; k < matrix.GetLength(1); k++)
                        matrix[i, k] = matrix[i, k] == 0 ? 0 : Int32.MinValue;
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i, j] == Int32.MinValue ? 0 : matrix[i, j];
                }
            }

            return matrix;
        }

        public bool StringRotation(string input, string input2)
        {
            if (input == null || input2 == null)
                throw new ArgumentNullException();

            var temp = input2 + input2;
            bool result = true;
            int index = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                if (input[index] == temp[i])
                {
                    index++;
                    for (int j = i + 1; index < input.Length; j++)
                    {
                        if (input[index++] == temp[j])
                            continue;
                        index = 0;
                        i = j - 1;
                        break;
                    }
                    if (index == input.Length)
                    {
                        result = true;
                        break;
                    }
                    result = false;
                }
            }

            return result;
        }
    }
}
