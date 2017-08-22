using System;
using System.Linq;

namespace Tasks.ObjectOrientedDesign.Minesweeper
{
    public class Board
    {
        public Board()
        {
            CreateBoard();
        }

        private const int BombsCount = 10;
        private const int BoardSize = 64;
        private const int N = 8;
        private bool[,] IsCurrentChecked;
        private Cell[] _cells;
        public bool IsWon => BoardSize - _cells.Count(x => x.IsOpen) - BombsCount == 0;
        
        public Cell this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= N || j < 0 || j >= N)
                    throw new ArgumentOutOfRangeException();
                return _cells[i * N + j];
            }
            set
            {
                if (i < 0 || i >= N || j < 0 || j >= N)
                    throw new ArgumentOutOfRangeException();
                _cells[i * N + j] = value;
            }
        }

        private void CreateBoard()
        {
            var board = new Cell[BoardSize];

            for (int i = 0; i < BombsCount; i++)
                board[i] = new Cell(CellType.Bomb);

            for (int i = BombsCount; i < board.Length; i++)
                board[i] = new Cell(CellType.Blank);

            var random = new Random();
            _cells = board.OrderBy(item => random.Next()).ToArray();

            for (int i = 0; i < BoardSize; i++)
            {
                if (_cells[i].CellType == CellType.Bomb)
                {
                    int ii = i / N;
                    int jj = i % N;
                    if (ii + 1 < N)
                    {
                        this[ii+1, jj].IncreaseValue();
                        if (jj + 1 < N)
                            this [ii + 1, jj + 1].IncreaseValue();
                        if (jj - 1 >= 0)
                            this[ii + 1, jj - 1].IncreaseValue();
                    }
                    if (ii - 1 >= 0)
                    {
                        this[ii - 1, jj].IncreaseValue();
                        if (jj + 1 < N)
                            this[ii - 1, jj + 1].IncreaseValue();
                        if (jj - 1 >= 0)
                            this[ii - 1, jj - 1].IncreaseValue();
                    }
                    if (jj + 1 < N)
                        this[ii, jj + 1].IncreaseValue();
                    if (jj - 1 >= 0)
                        this[ii, jj - 1].IncreaseValue();
                }
            }
        }

        public void ExploreBlank(int i, int j)
        {
            if (i < 0 || i >= N || j < 0 || j >= N)
                throw new ArgumentOutOfRangeException();
            IsCurrentChecked = new bool[N, N];
            ExploreBlankHelper(i, j);
        }

        private void ExploreBlankHelper(int i, int j)
        {
            if (i < 0 || i >= N || j < 0 || j >= N)
                return;
            if (IsCurrentChecked[i, j])
                return;
            if (this[i,j].CellType == CellType.Blank)
            {
                this[i, j].IsOpen = true;
                IsCurrentChecked[i, j] = true;
                ExploreBlankHelper(i + 1, j);
                ExploreBlankHelper(i + 1, j + 1);
                ExploreBlankHelper(i + 1, j - 1);
                ExploreBlankHelper(i - 1, j);
                ExploreBlankHelper(i - 1, j + 1);
                ExploreBlankHelper(i - 1, j - 1);
                ExploreBlankHelper(i, j + 1);
                ExploreBlankHelper(i, j - 1);
            }
            else if (this[i, j].CellType == CellType.Number)
            {
                IsCurrentChecked[i, j] = true;
                this[i, j].IsOpen = true;
            }
        }
    }
}