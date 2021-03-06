﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class RecursionNDynamicProgramming
    {
        public long TripleStep(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            long a = 1;
            long b = 2;
            long c = 4;

            if (n == 1)
                return a;
            if (n == 2)
                return b;

            for (int i = 3; i < n; i++)
            {
                var tempC = c;
                c = c + b + a;
                var tempB = b;
                b = tempC;
                a = tempB;
            }
            return c;
        }

        public int MagicIndex(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                return -1;

            return MagicIndexHelper(array, 0, array.Length - 1);
        }

        private int MagicIndexHelper(int[] array, int left, int right)
        {
            int middle = (left + right) / 2;
            if (array[middle] == middle)
                return middle;
            if (right <= left)
                return -1;

            int result = 0;
            result = MagicIndexHelper(array, left, Math.Min(array[middle], middle - 1));
            if (result != -1)
                return result;
            result = MagicIndexHelper(array, Math.Max(middle + 1, array[middle]), right);

            return result;
        }

        public int RecursiveMutliply(int a, int b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentOutOfRangeException();
            if (a == 0 || b == 0)
                return 0;

            return RecursiveMutliplyHelper(a, b);
        }

        private int RecursiveMutliplyHelper(int a, int b)
        {
            int result = 0;
            if (b % 2 == 1)
            {
                result = a;
                b--;
            }
            if (b > 0 && b % 2 == 0)
                result += RecursiveMutliplyHelper(a << 1, b / 2);

            return result;
        }

        public List<int>[] TowersOfHanoi(List<int>[] towers)
        {
            if (towers == null) throw new ArgumentNullException();
            if (towers.Length != 3 || !IsSorted(towers[0])) throw new ArgumentException();
            if (towers[1].Count != 0 || towers[2].Count != 0) throw new InvalidOperationException();
            if (towers[0].Count == 0)
                return towers;

            var result = new List<int>[towers.Length];
            for (int i = 0; i < towers.Length; i++)
                result[i] = new List<int>(towers[i]);

            TowersOfHanoiHelper(result, 2, 0, towers[0].Count);
            return result;
        }

        private void TowersOfHanoiHelper(List<int>[] towers,
            int targetTowerIndex, int sourceIndex, int count)
        {
            int helperIndex = towers.Length - targetTowerIndex - sourceIndex;

            if (count > 1)
                TowersOfHanoiHelper(towers, helperIndex, sourceIndex, count - 1);

            if (towers[targetTowerIndex].Count > 0 &&
                towers[sourceIndex].Count > 0 &&
                towers[targetTowerIndex].Last() > towers[sourceIndex].Last())
                throw new InvalidOperationException();

            towers[targetTowerIndex].Add(towers[sourceIndex].Last());
            towers[sourceIndex].RemoveAt(towers[sourceIndex].Count - 1);

            if (count > 1)
                TowersOfHanoiHelper(towers, targetTowerIndex, helperIndex, count - 1);
        }

        private static bool IsSorted(List<int> arr)
        {
            int l = arr.Count;
            for (int i = 1; i < l / 2 + 1; i++)
                if (arr[i - 1] > arr[i] || arr[l - i] < arr[l - i - 1])
                    return false;
            return true;
        }

        public IEnumerable<string> Parens(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            return ParensHelper(n);
        }

        private IEnumerable<string> ParensHelper(int n)
        {
            if (n == 0)
                return new List<string> { "" };

            var parensList = ParensHelper(n - 1).ToList();
            var result = new HashSet<string>();

            foreach (var item in parensList)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    int leftCount = 0;
                    int rightCount = 0;
                    for (int j = i; j < item.Length; j++)
                    {
                        if (item[j] == '(')
                            leftCount++;
                        else
                            rightCount++;
                        if (leftCount == rightCount)
                            result.Add(item.Insert(i, "(").Insert(j + 2, ")"));
                    }
                }
                result.Add(item + "()");
            }
            return result;
        }

        public int[,] PaintFill(int[,] matrix, int i, int j)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (matrix.Length == 0)
                return matrix;
            if (i < 0 || j < 0 || i >= matrix.GetLength(0) || j >= matrix.GetLength(1))
                throw new ArgumentOutOfRangeException();
            if (matrix.Cast<int>().Any(x => x < 0))
                throw new InvalidOperationException();

            var result = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int ii = 0; ii < matrix.GetLength(0); ii++)
                for (int jj = 0; jj < matrix.GetLength(1); jj++)
                    result[ii, jj] = matrix[ii, jj];

            PaintFillHelper(result, i, j);

            for (int ii = 0; ii < matrix.GetLength(0); ii++)
                for (int jj = 0; jj < matrix.GetLength(1); jj++)
                    result[ii, jj] = result[ii, jj] == -1 ? 0 : result[ii, jj];

            return result;
        }

        private void PaintFillHelper(int[,] matrix, int i, int j)
        {
            int currentCell = matrix[i, j];
            matrix[i, j] = -1;
            if (i > 0 && matrix[i - 1, j] == currentCell)
                PaintFillHelper(matrix, i - 1, j);
            if (i < matrix.GetLength(0) - 1 && matrix[i + 1, j] == currentCell)
                PaintFillHelper(matrix, i + 1, j);
            if (j > 0 && matrix[i, j - 1] == currentCell)
                PaintFillHelper(matrix, i, j - 1);
            if (j < matrix.GetLength(1) - 1 && matrix[i, j + 1] == currentCell)
                PaintFillHelper(matrix, i, j + 1);
        }

        public int Coins(int n, int[] coins)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            if (coins == null)
                throw new ArgumentNullException();
            if (coins.Length == 0 || coins.Any(x => x < 0))
                throw new ArgumentException();
            if (n == 0)
                return 0;

            int[] matrix = new int[n + 1];
            matrix[0] = 1;
            foreach (int coin in coins)
            {
                for (int j = 1; j < matrix.Length; j++)
                {
                    if (j < coin)
                        continue;
                    matrix[j] += matrix[j - coin];
                }
            }
            return matrix.Last();
        }

        public int BoleanEvaluation(string input, bool result)
        {
            if (input == null)
                throw new ArgumentNullException();
            if (input.Length == 0 || !IsValidExpression(input))
                throw new ArgumentException();


            var results = BooleanEvaluationHelper(input, 0, input.Length - 1);

            return results.Count(x => x == result);
        }

        private List<bool> BooleanEvaluationHelper(string input, int leftIndex, int rightIndex)
        {
            var results = new List<bool>();
            if (leftIndex == rightIndex)
                results.Add(input[leftIndex] == '1');
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (IsOperation(input, i))
                {
                    List<bool> leftResult = BooleanEvaluationHelper(input, leftIndex, i - 1);
                    List<bool> rightResults = BooleanEvaluationHelper(input, i + 1, rightIndex);

                    foreach (var left in leftResult)
                        foreach (var right in rightResults)
                        {
                            switch (input[i])
                            {
                                case '^': results.Add(left ^ right); break;
                                case '|': results.Add(left | right); break;
                                case '&': results.Add(left & right); break;
                            }
                        }
                }
            }
            return results;
        }

       private bool IsOperation(string input, int index)
            => input[index] == '|' || input[index] == '&' || input[index] == '^';

        private bool IsValidExpression(string input)
        {
            var chars = new List<char>() { '1', '0', '^', '(', ')', '&', '|' };
            return input.All(item => chars.Contains(item));
        }
    }
}
