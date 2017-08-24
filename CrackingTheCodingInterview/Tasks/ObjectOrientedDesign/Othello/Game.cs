using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.Othello
{
    public class Game
    {
        public const int DefaultBoardSize = 8;
        public Game(Player firstPlayer, Player secondPlayer)
        {
            if (firstPlayer == null || secondPlayer == null)
                throw new ArgumentNullException();
            if (firstPlayer.Equals(secondPlayer) ||
                firstPlayer.Surface == secondPlayer.Surface)
                throw new ArgumentException();

            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            Board = new Board(DefaultBoardSize);
        }

        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public Board Board { get; private set; }

        public int FirstPlayerScore => Board.GetScoreForSurface(FirstPlayer.Surface);
        public int SecondPlayerScore => Board.GetScoreForSurface(SecondPlayer.Surface);

        public void MakeMove(Piece piece, int i, int j)
        {
            if (piece == null)
                throw new ArgumentNullException();
           
            Board[i, j] = piece;
            if (Board.ShouldFlipAt(i, j))
                Board[i, j]?.Flip();
        }
    }
    public class Player
    {
        public Player(string name, Surface surface)
        {
            Name = name ?? throw new ArgumentNullException();
            Surface = surface;
        }
        public string Name { get; private set; }
        public Surface Surface { get; private set; }
    }

    public class Board
    {
        private Piece[,] _pieces;
        public int SizeX => _pieces.GetLength(1);
        public int SizeY => _pieces.GetLength(0);
        public Piece this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i >= _pieces.GetLength(0) || j >= _pieces.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                return _pieces[i, j];
            }
            set
            {
                if (i < 0 || j < 0 || i >= _pieces.GetLength(0) || j >= _pieces.GetLength(1))
                    throw new ArgumentOutOfRangeException();
                if (this[i, j] != null)
                    throw new InvalidOperationException();
                _pieces[i, j] = value;
            }
        }
        public Board(int size)
        {
            if (size < 2)
                throw new ArgumentOutOfRangeException();
            _pieces = new Piece[size, size];
        }

        public bool ShouldFlipAt(int i, int j)
        {
            if (i < 0 || j < 0 || i >= _pieces.GetLength(0) || j >= _pieces.GetLength(1))
                throw new ArgumentOutOfRangeException();

            var opposideSurface = this[i, j]?.TopSide.GetOppositeSide().Surface;
            if (opposideSurface == null)
                return false;

            if (j < _pieces.GetLength(1) - 1 && j > 0)
            {
                if (this[i, j + 1]?.TopSide.Surface == opposideSurface &&
                    this[i, j - 1]?.TopSide.Surface == opposideSurface)
                    return true;
            }
            if (i > 0 && i < _pieces.GetLength(0) - 1)
            {
                if (this[i - 1, j]?.TopSide.Surface == opposideSurface &&
                    this[i + 1, j]?.TopSide.Surface == opposideSurface)
                    return true;
            }
            return false;
        }

        public int GetScoreForSurface(Surface surface)
        {
            int result = 0;
            for(int i = 0 ; i<SizeY;i++)
            for (int j = 0; j < SizeX; j++)
                result += this[i, j]?.TopSide.Surface == surface ? 1 : 0;
            return result;
        }
    }

    public class Piece
    {
        public Piece(Side topSide)
        {
            TopSide = topSide ?? throw new ArgumentNullException();
            BottomSide = TopSide.GetOppositeSide();
        }

        public Side TopSide { get; private set; }
        public Side BottomSide { get; private set; }
        public void Flip()
        {
            TopSide = TopSide.GetOppositeSide();
            BottomSide = BottomSide.GetOppositeSide();
        }
    }

    public class Side
    {
        public Side(Surface surface)
        {
            Surface = surface;
        }
        public Surface Surface { get; private set; }

        public Side GetOppositeSide()
            => new Side(Surface == Surface.Black ? Surface.White : Surface.Black);
    }


    public enum Surface
    {
        White,
        Black
    }
}
