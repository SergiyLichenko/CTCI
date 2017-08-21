using System;

namespace Tasks.ObjectOrientedDesign.ParkingLot
{
    public class Floor
    {
        private Car[,] _slots;
        public int Count { get; private set; }
        public int Width => _slots.GetLength(1);
        public int Height => _slots.GetLength(0);
        public Floor(int width, int height)
        {
            if(width<0 || height<0)
                throw new ArgumentOutOfRangeException();
            _slots = new Car[height, width];
        }

        public Car GetPlace(int i, int j)
        {
            if(i<0 || j<0 || i>=Height || j>=Width)
                throw new ArgumentOutOfRangeException();
            return _slots[i, j];
        }

        public void SetPlace(int i, int j, Car car)
        {
            if (i < 0 || j < 0 || i >= Height || j >= Width)
                throw new ArgumentOutOfRangeException();
            if(car == null)
                throw new ArgumentNullException();
            if(GetPlace(i,j)!=null)
                throw new InvalidOperationException();
            Count++;
            _slots[i, j] = car;
        }

        public void ClearPlace(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Height || j >= Width)
                throw new ArgumentOutOfRangeException();

            Count--;
            _slots[i, j] = null;
        }
    }
}