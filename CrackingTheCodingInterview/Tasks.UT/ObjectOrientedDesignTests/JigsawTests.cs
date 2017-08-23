using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.Jigsaw;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class JigsawTests
    {
        [Fact]
        public void Jigsaw_Should_Check_Example()
        {
            //arrange
            var puzzles = new List<Puzzle>()
            {
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Left),
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Right),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right),
                new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Right),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
                new Puzzle(PuzzleType.Normal, PuzzleDirection.Top),
            };
            var board = new ObjectOrientedDesign.Jigsaw.Board(puzzles);

            //act
            var result = board.SolvePuzzle();

            //assert
            result.GetLength(0).ShouldBeEquivalentTo((int)Math.Sqrt(puzzles.Count));
            result.GetLength(1).ShouldBeEquivalentTo((int)Math.Sqrt(puzzles.Count));

            result[0, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom), cfg => cfg.Excluding(x => x.IsUsed));
            result[0, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom), cfg => cfg.Excluding(x => x.IsUsed));
            result[0, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom), cfg => cfg.Excluding(x => x.IsUsed));
            result[0, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom), cfg => cfg.Excluding(x => x.IsUsed));
            result[0, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom), cfg => cfg.Excluding(x => x.IsUsed));
            result[0, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Corner, PuzzleDirection.Left), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[1, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[2, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[3, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Normal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[4, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 0].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Corner, PuzzleDirection.Right), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 1].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 2].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 3].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 4].ShouldBeEquivalentTo(new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
            result[5, 5].ShouldBeEquivalentTo(new Puzzle(PuzzleType.Corner, PuzzleDirection.Top), cfg => cfg.Excluding(x => x.IsUsed));
        }

        [Fact]
        public void Jigsaw_Should_Throw_FitsWith_If_Null()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            //act
            Action actFirst = () => board.FitsWith(null, new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom), PuzzleDirection.Right);
            Action actSecond = () => board.FitsWith(new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom), null, PuzzleDirection.Right);

            //assert
            actFirst.ShouldThrow<ArgumentNullException>();
            actSecond.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Top_Left_Corner_With_Horizontal()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Top_Left_Corner_With_Vertical()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Top_Right_Corner_With_Horizontal()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Top_Right_Corner_With_Vertical()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Bottom_Right_Corner_With_Horizontal()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Bottom_Right_Corner_With_Vertical()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Bottom_Left_Corner_With_Horizontal()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Bottom_Left_Corner_With_Vertical()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Corner, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_On_Top_Of_Horizontal_Left_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_On_Top_Of_Horizontal_Right_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_Right_To_Horizontal_Top_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_Right_To_Horizontal_Bottom_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_On_Top_Of_Vertical_Left_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_On_Top_Of_Vertical_Right_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_Right_To_Vertical_Top_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_Right_To_Vertical_Bottom_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }
        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_With_Normal_Left_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_With_Normal_Right_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_With_Normal_Top_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_With_Normal_Bottom_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_With_Normal_Top_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Bottom);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Bottom);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_With_Normal_Top_Right_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Left);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Left);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Horizontal_With_Normal_Bottom_Left_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatHorizontal, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Vertical_With_Normal_Bottom_Left_Case()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.SideFlatVertical, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Normal_With_Normal_Vertical_Above()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Normal_With_Normal_Horizontal_Above()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Top);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Normal_With_Normal_Vertical_Right()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Check_FitsWith_Normal_With_Normal_Horizontal_Right()
        {
            //arrange
            var board = new ObjectOrientedDesign.Jigsaw.Board(new List<Puzzle>());

            var first = new Puzzle(PuzzleType.Normal, PuzzleDirection.Top);
            var second = new Puzzle(PuzzleType.Normal, PuzzleDirection.Right);

            //act
            var result = board.FitsWith(first, second, PuzzleDirection.Right);

            //assert
            result.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void Jigsaw_Should_Create_Puzzle()
        {
            //arrange
            var type = PuzzleType.Corner;
            var direction = PuzzleDirection.Left;

            //act
            var puzzle = new Puzzle(type, direction);

            //assert
            puzzle.Type.ShouldBeEquivalentTo(type);
            puzzle.Direction.ShouldBeEquivalentTo(direction);
        }

        [Fact]
        public void Jigsaw_Should_Throw_Create_Board_If_Null()
        {
            //arrange

            //act
            Action act = () => new ObjectOrientedDesign.Jigsaw.Board(null);

            //assert
            act.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void Jigsaw_Should_Throw_Create_Board_If_Not_Square()
        {
            //arrange
            var puzzles = new List<Puzzle>()
            {
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom),
                new Puzzle(PuzzleType.Corner, PuzzleDirection.Bottom)
            };

            //act
            Action act = () => new ObjectOrientedDesign.Jigsaw.Board(puzzles);

            //assert
            act.ShouldThrow<ArgumentException>();
        }
    }
}
