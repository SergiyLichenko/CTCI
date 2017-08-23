using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.Minesweeper;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public  class MinesweeperTests
    {
        [Fact]
        public void Minesweeper_Should_CreateBoard()
        {
            //arrange
            int n = 8;
            var result = new Cell[n, n];

            //act
            var board = new Board();
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                result[i, j] = board[i, j];

            //assert
            result.Cast<Cell>().Count(x => x.CellType == CellType.Bomb).ShouldBeEquivalentTo(10);
        }

        [Fact]
        public void Minesweeper_Should_Throw_Get_Cell_If_Not_In_Range()
        {
            //arrange
            var board = new Board();
            Cell temp;
            //act
            Action actFirstLower = () => temp = board[-1, 3];
            Action actFirstHigher = () => temp = board[8, 3];
            Action actSecondLower = () => temp = board[1, -3];
            Action actSecondHigher = () => temp = board[5, 9];

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Minesweeper_Should_Throw_Explore_Blank_If_Not_In_Range()
        {
            //arrange
            var board = new Board();

            //act
            Action actFirstLower = () => board.ExploreBlank(-1, 3);
            Action actFirstHigher = () => board.ExploreBlank(8, 3);
            Action actSecondLower = () => board.ExploreBlank(1, -3);
            Action actSecondHigher = () => board.ExploreBlank(5, 9);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Minesweeper_Should_Throw_CreateGame_If_Null()
        {
            //arrange

            //act
            Action act = () => new Game(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Minesweeper_Should_CreateGame()
        {
            //arrange
            int n = 8;
            var player = new Player(String.Empty);

            //act
            var game = new Game(player);

            //assert
            game.Player.ShouldBeEquivalentTo(player);
            game.CurrentView.Should().NotBeNull();
            game.GameState.ShouldBeEquivalentTo(GameState.Playing);
            game.CheckedCells.Length.ShouldBeEquivalentTo(n * n);
            game.MarkedCells.Length.ShouldBeEquivalentTo(n * n);
        }

        [Fact]
        public void Minesweeper_Should_Throw_CreatePlayer_If_Null()
        {
            //arrange

            //act
            Action act = () => new Player(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Minesweeper_Should_CreatePlayer()
        {
            //arrange

            //act
            var player = new Player(String.Empty);

            //assert
            player.Name.ShouldBeEquivalentTo(string.Empty);
        }

        [Fact]
        public void Minesweeper_Should_Throw_Check_Cell_If_Not_In_Range()
        {
            //arrange
            var game = new Game(new Player(string.Empty));

            //act
            Action actFirstLower = () => game.CheckCell(-1, 3);
            Action actFirstHigher = () => game.CheckCell(8, 3);
            Action actSecondLower = () => game.CheckCell(1, -3);
            Action actSecondHigher = () => game.CheckCell(5, 9);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }
        [Fact]
        public void Minesweeper_Should_Throw_Mark_Cell_If_Not_In_Range()
        {
            //arrange
            var game = new Game(new Player(string.Empty));

            //act
            Action actFirstLower = () => game.MarkCell(-1, 3);
            Action actFirstHigher = () => game.MarkCell(8, 3);
            Action actSecondLower = () => game.MarkCell(1, -3);
            Action actSecondHigher = () => game.MarkCell(5, 9);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Minesweeper_Should_Throw_Set_Cell_If_Not_In_Range()
        {
            //arrange
            var board = new Board();

            //act
            Action actFirstLower = () => board[-1, 3] = null;
            Action actFirstHigher = () => board[8, 3] = null;
            Action actSecondLower = () => board[1, -3] = null;
            Action actSecondHigher = () => board[5, 9] = null;

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Minesweeper_Should_MarkCell()
        {
            //arrange
            var game = new Game(new Player(string.Empty));

            //act
            game.MarkCell(1, 1);

            //assert
            game.MarkedCells[1, 1].ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Minesweeper_Should_UnMarkCell()
        {
            //arrange
            var game = new Game(new Player(string.Empty));

            //act
            game.MarkCell(1, 1);
            game.MarkCell(1, 1);

            //assert
            game.MarkedCells[1, 1].ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Minesweeper_Should_ExploreBlankCell()
        {
            //arrange
            int n = 8;
            var one = new Cell(CellType.Number);
            var two = new Cell(CellType.Number);
            var three = new Cell(CellType.Number);
            one.SetValue(1);
            one.SetValue(2);
            one.SetValue(3);

            var board = new Board();
            board[0, 0] = new Cell(CellType.Blank);
            board[0, 1] = new Cell(CellType.Blank);
            board[0, 2] = new Cell(CellType.Blank);
            board[1, 0] = new Cell(CellType.Blank);
            board[1, 1] = new Cell(CellType.Blank);
            board[1, 2] = new Cell(CellType.Blank);
            board[2, 0] = new Cell(CellType.Blank);
            board[2, 1] = new Cell(CellType.Blank);
            board[2, 2] = new Cell(CellType.Blank);
            board[2, 3] = new Cell(CellType.Blank);
            board[2, 4] = new Cell(CellType.Blank);
            board[2, 5] = new Cell(CellType.Blank);
            board[3, 0] = new Cell(CellType.Blank);
            board[3, 1] = new Cell(CellType.Blank);
            board[3, 2] = new Cell(CellType.Blank);
            board[4, 0] = new Cell(CellType.Blank);
            board[5, 0] = new Cell(CellType.Blank);

            board[0, 3] = one;
            board[1, 3] = one;
            board[1, 4] = two;
            board[1, 5] = two;
            board[1, 6] = three;
            board[2, 6] = one;
            board[3, 3] = one;
            board[3, 4] = two;
            board[3, 5] = two;
            board[3, 6] = two;
            board[4, 1] = one;
            board[4, 2] = one;
            board[4, 3] = two;
            board[5, 1] = one;
            board[6, 0] = one;
            board[6, 1] = two;

            int[] openIIndexes = new[]
            {
                0,0,0,0,1,1,1,1,1,1,1,2,2,2,2,2,
                2,2,3,3,3,3,3,3,3,
                4,4,4,4,5,5,6,6
            };
            int[] openJIndexes = new[] { 0, 1, 2, 3, 0, 1,
                2, 3, 4, 5, 6, 0, 1, 2, 3, 4, 5, 6, 0, 1,
                2, 3, 4, 5, 6, 0, 1, 2, 3, 0, 1, 0, 1 };

            //act
            board.ExploreBlank(1, 1);

            //assert
            int lastCheckedIndex = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (lastCheckedIndex < openIIndexes.Length &&
                        i == openIIndexes[lastCheckedIndex] &&
                        j == openJIndexes[lastCheckedIndex])
                    {
                        lastCheckedIndex++;
                        board[i, j].IsOpen.ShouldBeEquivalentTo(true);
                    }
                    else
                        board[i, j].IsOpen.ShouldBeEquivalentTo(false);
                }
            }
        }

        [Fact]
        public void Minesweeper_Should_Check_CurrentView()
        {
            //arrange
            int n = 8;
            var one = new Cell(CellType.Number);
            var two = new Cell(CellType.Number);
            var three = new Cell(CellType.Number);
            one.SetValue(1);
            one.SetValue(2);
            one.SetValue(3);

            var board = new Board();
            board[0, 0] = new Cell(CellType.Blank);
            board[0, 1] = new Cell(CellType.Blank);
            board[0, 2] = new Cell(CellType.Blank);
            board[1, 0] = new Cell(CellType.Blank);
            board[1, 1] = new Cell(CellType.Blank);
            board[1, 2] = new Cell(CellType.Blank);
            board[2, 0] = new Cell(CellType.Blank);
            board[2, 1] = new Cell(CellType.Blank);
            board[2, 2] = new Cell(CellType.Blank);
            board[2, 3] = new Cell(CellType.Blank);
            board[2, 4] = new Cell(CellType.Blank);
            board[2, 5] = new Cell(CellType.Blank);
            board[3, 0] = new Cell(CellType.Blank);
            board[3, 1] = new Cell(CellType.Blank);
            board[3, 2] = new Cell(CellType.Blank);
            board[4, 0] = new Cell(CellType.Blank);
            board[5, 0] = new Cell(CellType.Blank);

            board[0, 3] = one;
            board[1, 3] = one;
            board[1, 4] = two;
            board[1, 5] = two;
            board[1, 6] = three;
            board[2, 6] = one;
            board[3, 3] = one;
            board[3, 4] = two;
            board[3, 5] = two;
            board[3, 6] = two;
            board[4, 1] = one;
            board[4, 2] = one;
            board[4, 3] = two;
            board[5, 1] = one;
            board[6, 0] = one;
            board[6, 1] = two;

            int[] openIIndexes = new[]
            {
                0,0,0,1,1,1,1,1,1,1,2,2,2,2,2,
                2,2,3,3,3,3,3,3,3,
                4,4,4,4,5,5,6,6
            };
            int[] openJIndexes = new[] {  1, 2, 3, 0, 1,
                2, 3, 4, 5, 6, 0, 1, 2, 3, 4, 5, 6, 0, 1,
                2, 3, 4, 5, 6, 0, 1, 2, 3, 0, 1, 0, 1 };

            var game = new Game(new Player(string.Empty));
            var prop = game.GetType().GetField("_board", System.Reflection.BindingFlags.NonPublic
                                                         | System.Reflection.BindingFlags.Instance);

            prop.SetValue(game, board);
            game.MarkCell(0, 0);

            //act
            var result = game.CheckCell(1, 1);

            //assert
            int lastCheckedIndex = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        result[i, j].IsOpen.ShouldBeEquivalentTo(false);
                        result[i, j].CellType.ShouldBeEquivalentTo(CellType.Marked);
                    }
                    else if (lastCheckedIndex < openIIndexes.Length &&
                             i == openIIndexes[lastCheckedIndex] &&
                             j == openJIndexes[lastCheckedIndex])
                    {
                        lastCheckedIndex++;
                        result[i, j].IsOpen.ShouldBeEquivalentTo(true);
                        bool res = result[i, j].CellType == CellType.Number ||
                                   result[i, j].CellType == CellType.Blank;

                        res.ShouldBeEquivalentTo(true);
                    }
                    else
                    {
                        result[i, j].IsOpen.ShouldBeEquivalentTo(false);
                        result[i, j].CellType.ShouldBeEquivalentTo(CellType.Hidden);
                    }
                }
            }
        }

        [Fact]
        public void Minesweeper_Should_Check_Is_Won()
        {
            //arrange
            int n = 8;
            var board = new Board();

            //act
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (board[i, j].CellType != CellType.Bomb)
                    board[i, j].IsOpen = true;

            //assert
            board.IsWon.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Minesweeper_Should_Check_Cell_Copy()
        {
            //arrange
            var cell = new Cell(CellType.Hidden);

            //act
            var result = cell.Copy();

            //assert
            result.ShouldBeEquivalentTo(cell);
            result.Equals(cell).ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void Minesweeper_Should_Check_Lost()
        {
            //arrange
            int n = 8;
            var game = new Game(new Player(String.Empty));

            //act
            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                game.CheckCell(i, j);

            //assert
            game.GameState.ShouldBeEquivalentTo(GameState.Lost);
        }
    }
}
