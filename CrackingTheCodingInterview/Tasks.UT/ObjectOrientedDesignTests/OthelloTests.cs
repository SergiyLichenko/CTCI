using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.Othello;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class OthelloTests
    {
        [Fact]
        public void Should_Create_Player()
        {
            //arrange
            var name = String.Empty;
            var surface = Surface.Black;

            //act
            var player = new Player(name, surface);

            //assert
            player.Name.ShouldBeEquivalentTo(name);
            player.Surface.ShouldBeEquivalentTo(surface);
        }

        [Fact]
        public void Should_Throw_Create_Player_If_Null()
        {
            //arrange
            var surface = Surface.Black;

            //act
            Action act = () => new Player(null, surface);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Side_Create()
        {
            //arrange
            var surface = Surface.Black;

            //act
            var side = new Side(surface);

            //assert
            side.Surface.ShouldBeEquivalentTo(surface);
        }

        [Fact]
        public void Should_Side_GetOpposideSide()
        {
            //arrange
            var surface = Surface.Black;
            var side = new Side(surface);

            //act
            var result = side.GetOppositeSide();

            //assert
            result.Surface.ShouldBeEquivalentTo(Surface.White);
        }

        [Fact]
        public void Should_Create_Piece()
        {
            //arrange
            var side = new Side(Surface.White);

            //act
            var piece = new Piece(side);

            //assert
            piece.TopSide.ShouldBeEquivalentTo(side);
            piece.BottomSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Throw_Create_Piece_If_Null()
        {
            //arrange

            //act
            Action act = () => new Piece(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Flip_Piece()
        {
            //arrange
            var side = new Side(Surface.White);
            var piece = new Piece(side);

            //act
            piece.Flip();

            //assert
            piece.TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            piece.BottomSide.Surface.ShouldBeEquivalentTo(Surface.White);
        }

        [Fact]
        public void Should_Throw_Create_Board_If_Negative()
        {
            //arrange

            //act
            Action act = () => new Board(-1);

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_Make_Move_If_Not_In_Range()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));

            //act
            Action firstLow = () => game.MakeMove(new Piece(new Side(Surface.Black)), -1, 1);
            Action firstHigh = () => game.MakeMove(new Piece(new Side(Surface.Black)), Game.DefaultBoardSize, 1);
            Action secondLow = () => game.MakeMove(new Piece(new Side(Surface.Black)), 1, -1);
            Action secondHigh = () => game.MakeMove(new Piece(new Side(Surface.Black)), 1, Game.DefaultBoardSize);

            //assert
            firstLow.ShouldThrow<ArgumentOutOfRangeException>();
            firstHigh.ShouldThrow<ArgumentOutOfRangeException>();
            secondLow.ShouldThrow<ArgumentOutOfRangeException>();
            secondHigh.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_Make_Move_If_Null()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));

            //act
            Action act = () => game.MakeMove(null, 1, 1);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Make_Move_If_Place_Is_Taken()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.Black)), 1, 1);
            //act
            Action act = () => game.MakeMove(new Piece(new Side(Surface.Black)), 1, 1);

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Throw_ShouldFlipAt_If_Not_In_Range()
        {
            //arrange
            var board = new Board(5);

            //act
            Action firstLower = () => board.ShouldFlipAt(-1, 1);
            Action firstHigher = () => board.ShouldFlipAt(5, 1);
            Action secondLower = () => board.ShouldFlipAt(1, -1);
            Action secondHigher = () => board.ShouldFlipAt(1, 5);

            //assert
            firstLower.ShouldThrow<ArgumentOutOfRangeException>();
            firstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            secondLower.ShouldThrow<ArgumentOutOfRangeException>();
            secondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_GetIndexer_If_Not_In_Range()
        {
            //arrange
            var board = new Board(5);
            Piece temp = null;
            //act
            Action firstLower = () => temp = board[-1, 1];
            Action firstHigher = () => temp = board[5, 1];
            Action secondLower = () => temp = board[1, -1];
            Action secondHigher = () => temp = board[1, 5];

            //assert
            firstLower.ShouldThrow<ArgumentOutOfRangeException>();
            firstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            secondLower.ShouldThrow<ArgumentOutOfRangeException>();
            secondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_SetIndexer_If_Not_In_Range()
        {
            //arrange
            var board = new Board(5);
            Piece piece = new Piece(new Side(Surface.Black));

            //act
            Action firstLower = () => board[-1, 1] = piece;
            Action firstHigher = () => board[5, 1] = piece;
            Action secondLower = () => board[1, -1] = piece;
            Action secondHigher = () => board[1, 5] = piece;

            //assert
            firstLower.ShouldThrow<ArgumentOutOfRangeException>();
            firstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            secondLower.ShouldThrow<ArgumentOutOfRangeException>();
            secondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Should_Throw_SetIndexer_If_Place_Is_Taken()
        {
            //arrange
            var board = new Board(5);
            Piece piece = new Piece(new Side(Surface.Black));
            board[1, 1] = piece;

            //act
            Action act = () => board[1, 1] = new Piece(new Side(Surface.White));

            //assert
            act.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Should_Check_Flip_True_Vertical()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 2);
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 2);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 3, 2);

            //assert
            game.Board[3, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[2, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[4, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Check_Flip_False_Vertical()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.White)), 2, 2);
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 2);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 3, 2);

            //assert
            game.Board[3, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[2, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[4, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Check_Flip_True_Horizontal()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 4);
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 2);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 2, 3);

            //assert
            game.Board[2, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[2, 3].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[2, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Check_Flip_False_Horizontal()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.White)), 2, 2);
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 4);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 2, 3);

            //assert
            game.Board[2, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[2, 3].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[2, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Check_Flip_Left_Side_Vertical()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 0);
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 0);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 3, 0);

            //assert
            game.Board[2, 0].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[3, 0].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[4, 0].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }

        [Fact]
        public void Should_Check_Flip_Right_Side_Vertical()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.Black)), 2, 4);
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 4);

            //act
            game.MakeMove(new Piece(new Side(Surface.White)), 3, 4);

            //assert
            game.Board[2, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[3, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
            game.Board[4, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.Black);
        }


        [Fact]
        public void Should_Check_Flip_Top_Side_Horizontal()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));
            game.MakeMove(new Piece(new Side(Surface.White)), 0, 2);
            game.MakeMove(new Piece(new Side(Surface.White)), 0, 4);

            //act
            game.MakeMove(new Piece(new Side(Surface.Black)), 0, 3);

            //assert
            game.Board[0, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[0, 3].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[0, 4].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
        }

        [Fact]
        public void Should_Check_Flip_Bottom_Size_Horizontal()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));

            game.MakeMove(new Piece(new Side(Surface.White)), 4, 3);
            game.MakeMove(new Piece(new Side(Surface.White)), 4, 1);

            //act
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 2);

            //assert
            game.Board[4, 1].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[4, 2].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
            game.Board[4, 3].TopSide.Surface.ShouldBeEquivalentTo(Surface.White);
        }

        [Fact]
        public void Should_Check_ShouldFlipAt_If_No_Piece()
        {
            //arrange
            var board = new Board(5);

            //act
            var result = board.ShouldFlipAt(2, 2);

            //assert
            result.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Should_Throw_Create_Game_If_Null()
        {
            //arrange

            //act
            Action actFirst = () => new Game(null, new Player(string.Empty, Surface.Black));
            Action actSecond = () => new Game(new Player(string.Empty, Surface.Black), null);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_Create_Game_If_Same_Surfaces_On_Players()
        {
            //arrange

            //act
            Action actFirst = () => new Game(new Player(string.Empty, Surface.Black), new Player(string.Empty, Surface.Black));
            Action actSecond = () => new Game(new Player(string.Empty, Surface.White), new Player(string.Empty, Surface.White));

            //assert
            actFirst.ShouldThrow<ArgumentException>();
            actSecond.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Throw_Create_Game_If_Same_Player()
        {
            //arrange
            var player = new Player(string.Empty, Surface.Black);

            //act
            Action act = () => new Game(player, player);

            //assert
            act.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void Should_Create_Game()
        {
            //arrange
            var firstPlayer = new Player(string.Empty, Surface.Black);
            var secondPlayer = new Player(string.Empty, Surface.White);

            //act
            var game = new Game(firstPlayer, secondPlayer);

            //assert
            game.FirstPlayer.ShouldBeEquivalentTo(firstPlayer);
            game.SecondPlayer.ShouldBeEquivalentTo(secondPlayer);
            game.Board.SizeX.ShouldBeEquivalentTo(Game.DefaultBoardSize);
            game.Board.SizeY.ShouldBeEquivalentTo(Game.DefaultBoardSize);
        }


        [Fact]
        public void Should_Check_Score()
        {
            //arrange
            var game = new Game(new Player(string.Empty, Surface.Black),
                new Player(string.Empty, Surface.White));

            game.MakeMove(new Piece(new Side(Surface.Black)), 5, 5);
            game.MakeMove(new Piece(new Side(Surface.White)), 4, 3);
            game.MakeMove(new Piece(new Side(Surface.White)), 4, 1);
            game.MakeMove(new Piece(new Side(Surface.Black)), 4, 2);

            //act
            var scoreFirst = game.FirstPlayerScore;
            var scoreSecond = game.SecondPlayerScore;

            //assert
            scoreFirst.ShouldBeEquivalentTo(1);
            scoreSecond.ShouldBeEquivalentTo(3);
        }
    }
}
