using System;

namespace Tasks.ObjectOrientedDesign.Minesweeper
{
    public class Game
    {
        private const int N = 8;
        private Board _board;

        public Player Player { get; private set; }

        public Board CurrentView
        {
            get
            {
                var board = new Board();
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (MarkedCells[i, j])
                            board[i, j] = new Cell(CellType.Marked);
                        else if (_board[i, j].IsOpen)
                            board[i, j] = _board[i, j].Copy();
                        else
                            board[i, j] =  new Cell(CellType.Hidden);
                    }
                }
                return board;
            }
        }

        public GameState GameState { get; private set; } = GameState.Playing;
        public bool[,] CheckedCells { get; private set; }
        public bool[,] MarkedCells { get; private set; }
        public Game(Player player)
        {
            Player = player ?? throw new ArgumentNullException();
            _board = new Board();
            CheckedCells = new bool[N, N];
            MarkedCells = new bool[N, N];
        }

        public Board CheckCell(int i, int j)
        {
            if (i < 0 || i >= N || j < 0 || j >= N)
                throw new ArgumentOutOfRangeException();
            if (CheckedCells[i, j] || MarkedCells[i, j])
                return CurrentView;
            if (GameState != GameState.Playing)
                return CurrentView;

            CheckedCells[i, j] = true;

            if (_board[i, j].CellType == CellType.Number)
                _board[i, j].IsOpen = true;
            if (_board[i, j].CellType == CellType.Bomb)
                GameState = GameState.Lost;
            if (_board[i, j].CellType == CellType.Blank)
                _board.ExploreBlank(i, j);
            if (_board.IsWon)
                GameState = GameState.Won;
            return CurrentView;
        }

        public void MarkCell(int i, int j)
        {
            if (i < 0 || i >= N || j < 0 || j >= N)
                throw new ArgumentOutOfRangeException();
            MarkedCells[i, j] = !MarkedCells[i, j];
        }
    }
}