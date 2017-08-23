using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.ParkingLot;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public class ParkingLotTests
    {
        [Fact]
        public void ParkingLot_Should_Throw_If_Not_In_Range_Create_ParkingLot()
        {
            //arrange

            //act
            Action actFloors = () => new ParkingLot(-1, 1, 1);
            Action actWidth = () => new ParkingLot(1, -1, 1);
            Action actHeight = () => new ParkingLot(1, 1, -1);

            //assert
            actFloors.ShouldThrow<ArgumentOutOfRangeException>();
            actWidth.ShouldThrow<ArgumentOutOfRangeException>();
            actHeight.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Create_ParkingLot_Default()
        {
            //arrange
            int floorsCount = 3;
            int width = 4;
            int height = 5;

            //act
            var parkingLot = new ParkingLot(floorsCount, width, height);

            //assert
            parkingLot.FloorsCount.ShouldBeEquivalentTo(floorsCount);
            parkingLot.GetFloor(floorsCount - 1).Height.ShouldBeEquivalentTo(height);
            parkingLot.GetFloor(floorsCount - 1).Width.ShouldBeEquivalentTo(width);
        }

        [Fact]
        public void ParkingLot_Should_Throw_GetFlor_If_Not_In_Range()
        {
            //arrange
            int floorsCount = 3;
            int width = 4;
            int height = 5;
            var parkingLot = new ParkingLot(floorsCount, width, height);

            //act
            Action actHigher = () => parkingLot.GetFloor(floorsCount);
            Action actLower = () => parkingLot.GetFloor(-1);

            //assert
            actHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actLower.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Create_Floor_If_Not_In_Range()
        {
            //arrange

            //act
            Action actFirst = () => new Floor(-1, 1);
            Action actSecond = () => new Floor(1, -1);

            //assert
            actFirst.ShouldThrow<ArgumentOutOfRangeException>();
            actSecond.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Create_Floor()
        {
            //arrange
            int width = 10;
            int height = 15;

            //act
            var floor = new Floor(width, height);

            //assert
            floor.Height.ShouldBeEquivalentTo(height);
            floor.Width.ShouldBeEquivalentTo(width);
            floor.Count.ShouldBeEquivalentTo(0);
        }


        [Fact]
        public void ParkingLot_Should_Throw_Get_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.GetPlace(-1, 1);
            Action actFirstHigher = () => floor.GetPlace(height, 1);
            Action actSecondLower = () => floor.GetPlace(1, -1);
            Action actSecondHigher = () => floor.GetPlace(1, width);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.SetPlace(-1, 1, new Car(string.Empty));
            Action actFirstHigher = () => floor.SetPlace(height, 1, new Car(string.Empty));
            Action actSecondLower = () => floor.SetPlace(1, -1, new Car(string.Empty));
            Action actSecondHigher = () => floor.SetPlace(1, width, new Car(string.Empty));

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Null()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.SetPlace(1, 1, null);

            //assert
            actFirstLower.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ParkingLot_Should_Throw_Clear_Place_If_Not_In_Range()
        {
            //arrange
            int width = 10;
            int height = 15;
            var floor = new Floor(width, height);

            //act
            Action actFirstLower = () => floor.ClearPlace(-1, 1);
            Action actFirstHigher = () => floor.ClearPlace(height, 1);
            Action actSecondLower = () => floor.ClearPlace(1, -1);
            Action actSecondHigher = () => floor.ClearPlace(1, width);

            //assert
            actFirstLower.ShouldThrow<ArgumentOutOfRangeException>();
            actFirstHigher.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondLower.ShouldThrow<ArgumentOutOfRangeException>();
            actSecondHigher.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ParkingLot_Should_Check_Set_Place()
        {
            //arrange
            var parkingLot = new ParkingLot(3, 5, 5);
            int floor = 2;
            int i = 1;
            int j = 2;

            //act
            parkingLot.GetFloor(floor).SetPlace(i, j, new Car(string.Empty));

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
        }

        [Fact]
        public void ParkingLot_Should_Check_Get_Place()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            var result = parkingLot.GetFloor(floor).GetPlace(i, j);

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
            result.ShouldBeEquivalentTo(car);
        }

        [Fact]
        public void ParkingLot_Should_Check_Clear_Place()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            parkingLot.GetFloor(floor).ClearPlace(i, j);
            var result = parkingLot.GetFloor(floor).GetPlace(i, j);

            //assert
            parkingLot.Count.ShouldBeEquivalentTo(0);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(0);
            result.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public void ParkingLot_Should_Throw_Set_Place_If_Taken()
        {
            //arrange
            int floor = 2;
            int i = 1;
            int j = 2;
            var car = new Car(string.Empty);
            var parkingLot = new ParkingLot(3, 5, 5);
            parkingLot.GetFloor(floor).SetPlace(i, j, car);

            //act
            Action act = () => parkingLot.GetFloor(floor).SetPlace(i, j, new Car(string.Empty));

            //assert
            act.ShouldThrow<InvalidOperationException>();
            parkingLot.Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).Count.ShouldBeEquivalentTo(1);
            parkingLot.GetFloor(floor).GetPlace(i, j).ShouldBeEquivalentTo(car);
        }
    }
}
