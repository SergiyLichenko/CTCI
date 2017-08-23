using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.ObjectOrientedDesign.Jigsaw
{
    public class Board
    {
        private readonly List<Puzzle> _puzzles;
        private readonly int _n;

        public Board(List<Puzzle> puzzles)
        {
            if (puzzles == null)
                throw new ArgumentNullException();
            if (Math.Sqrt(puzzles.Count) % 1 != 0)
                throw new ArgumentException();

            _puzzles = puzzles;
            _n = (int)Math.Sqrt(puzzles.Count);
        }

        public Puzzle[,] SolvePuzzle()
        {
            var result = new Puzzle[_n, _n];
            result[0, 0] = _puzzles.First(x => x.Direction == PuzzleDirection.Bottom && x.Type == PuzzleType.Corner);
            result[0, _n - 1] = _puzzles.First(x => x.Direction == PuzzleDirection.Left && x.Type == PuzzleType.Corner);
            result[_n - 1, 0] = _puzzles.First(x => x.Direction == PuzzleDirection.Right && x.Type == PuzzleType.Corner);
            result[_n - 1, _n - 1] = _puzzles.First(x => x.Direction == PuzzleDirection.Top && x.Type == PuzzleType.Corner);

            result[0, 0].IsUsed = true;
            result[0, _n - 1].IsUsed = true;
            result[_n - 1, 0].IsUsed = true;
            result[_n - 1, _n - 1].IsUsed = true;

            SetSides(result, PuzzleDirection.Right, PuzzleDirection.Bottom);
            SetSides(result, PuzzleDirection.Left, PuzzleDirection.Top);
            SetNormal(result);
           
            return result;
        }

        private void SetNormal(Puzzle[,] result)
        {
            for (int i = 1; i < _n - 1; i++)
            {
                for (int j = 1; j < _n - 1; j++)
                {
                    var normalPuzzles = _puzzles.Where(x => !x.IsUsed && x.Type == PuzzleType.Normal);
                    foreach (var item in normalPuzzles)
                    {
                        if (FitsWith(result[i, j - 1], item, PuzzleDirection.Right))
                        {
                            result[i, j] = item;
                            break;
                        }
                    }
                    result[i, j].IsUsed = true;
                }
            }
        }

        private void SetSides(Puzzle[,] result, PuzzleDirection firstDirection, PuzzleDirection secondDirection)
        {
            int i = 0;
            int j = 0;
            int firstN = firstDirection == PuzzleDirection.Right ? 0 : result.GetLength(1) - 1;
            int secondN = secondDirection == PuzzleDirection.Bottom ? 0 : result.GetLength(0) - 1;
            while (j != _n - 2 || i != _n - 2)
            {
                var flatItems = _puzzles.Where(x => !x.IsUsed &&
                                                    (x.Type == PuzzleType.SideFlatHorizontal ||
                                                     x.Type == PuzzleType.SideFlatVertical)).ToList();
                foreach (var item in flatItems.Where(x => x.Direction == firstDirection))
                {
                    if (FitsWith(result[i, firstN], item, PuzzleDirection.Bottom))
                    {
                        result[++i, firstN] = item;
                        result[i, firstN].IsUsed = true;
                    }
                }
                foreach (var item in flatItems.Where(x => x.Direction == secondDirection))
                {
                    if (FitsWith(result[secondN, j], item, PuzzleDirection.Right))
                    {
                        result[secondN, ++j] = item;
                        result[secondN, j].IsUsed = true;
                    }
                }
            }
        }

        public bool FitsWith(Puzzle first, Puzzle second, PuzzleDirection secondRelativeToFirstDirection)
        {
            if (first == null || second == null)
                throw new ArgumentNullException();
            if (first.Type == PuzzleType.Corner)
            {
                if (first.Direction == PuzzleDirection.Bottom)
                {
                    if (second.Type == PuzzleType.SideFlatHorizontal &&
                        second.Direction == PuzzleDirection.Bottom &&
                        secondRelativeToFirstDirection == PuzzleDirection.Right)
                        return true;
                    if (second.Type == PuzzleType.SideFlatVertical &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Bottom)
                        return true;
                }
                if (first.Direction == PuzzleDirection.Left)
                {
                    if (second.Type == PuzzleType.SideFlatHorizontal &&
                        second.Direction == PuzzleDirection.Left &&
                        secondRelativeToFirstDirection == PuzzleDirection.Bottom)
                        return true;
                    if (second.Type == PuzzleType.SideFlatVertical &&
                        second.Direction == PuzzleDirection.Bottom &&
                        secondRelativeToFirstDirection == PuzzleDirection.Left)
                        return true;
                }
                if (first.Direction == PuzzleDirection.Top)
                {
                    if (second.Type == PuzzleType.SideFlatHorizontal &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Left)
                        return true;
                    if (second.Type == PuzzleType.SideFlatVertical &&
                        second.Direction == PuzzleDirection.Left &&
                        secondRelativeToFirstDirection == PuzzleDirection.Top)
                        return true;
                }
                if (first.Direction == PuzzleDirection.Right)
                {
                    if (second.Type == PuzzleType.SideFlatHorizontal &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Top)
                        return true;
                    if (second.Type == PuzzleType.SideFlatVertical &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Right)
                        return true;
                }
            }
            if ((first.Type == PuzzleType.SideFlatVertical && second.Type == PuzzleType.SideFlatHorizontal) ||
                (first.Type == PuzzleType.SideFlatHorizontal && second.Type == PuzzleType.SideFlatVertical))
            {
                if (secondRelativeToFirstDirection == PuzzleDirection.Bottom
                    || secondRelativeToFirstDirection == PuzzleDirection.Top)
                {
                    if (first.Direction == PuzzleDirection.Right &&
                        second.Direction == PuzzleDirection.Right)
                        return true;
                    if (first.Direction == PuzzleDirection.Left &&
                        second.Direction == PuzzleDirection.Left)
                        return true;
                }
                else
                {
                    if (first.Direction == PuzzleDirection.Bottom &&
                        second.Direction == PuzzleDirection.Bottom)
                        return true;
                    if (first.Direction == PuzzleDirection.Top &&
                        second.Direction == PuzzleDirection.Top)
                        return true;
                }
            }
            if (second.Type == PuzzleType.Normal)
            {
                if (first.Type == PuzzleType.SideFlatVertical)
                {
                    if (first.Direction == PuzzleDirection.Right &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Right)
                        return true;
                    if (first.Direction == PuzzleDirection.Left &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Left)
                        return true;
                    if (first.Direction == PuzzleDirection.Bottom &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Bottom)
                        return true;
                    if (first.Direction == PuzzleDirection.Top &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Top)
                        return true;
                }
                if (first.Type == PuzzleType.SideFlatHorizontal)
                {
                    if (first.Direction == PuzzleDirection.Bottom &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Bottom)
                        return true;
                    if (first.Direction == PuzzleDirection.Top &&
                        second.Direction == PuzzleDirection.Top &&
                        secondRelativeToFirstDirection == PuzzleDirection.Top)
                        return true;
                    if (first.Direction == PuzzleDirection.Left &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Left)
                        return true;
                    if (first.Direction == PuzzleDirection.Right &&
                        second.Direction == PuzzleDirection.Right &&
                        secondRelativeToFirstDirection == PuzzleDirection.Right)
                        return true;
                }
                if (first.Type == PuzzleType.Normal && second.Type == PuzzleType.Normal)
                {
                    if (secondRelativeToFirstDirection == PuzzleDirection.Top)
                    {
                        if (second.Direction == PuzzleDirection.Right &&
                            first.Direction == PuzzleDirection.Top)
                            return true;
                        if (second.Direction == PuzzleDirection.Top &&
                            first.Direction == PuzzleDirection.Right)
                            return true;
                    }
                    if (secondRelativeToFirstDirection == PuzzleDirection.Right)
                    {
                        if (second.Direction == PuzzleDirection.Right &&
                            first.Direction == PuzzleDirection.Top)
                            return true;
                        if (second.Direction == PuzzleDirection.Top &&
                            first.Direction == PuzzleDirection.Right)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}