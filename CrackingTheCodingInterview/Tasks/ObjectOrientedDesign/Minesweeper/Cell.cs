using System;

namespace Tasks.ObjectOrientedDesign.Minesweeper
{
    public class Cell
    {
        public CellType CellType { get; private set; }
        public int Value { get; private set; }
        public bool IsOpen { get; set; }
        public Cell(CellType cellType)
        {
            CellType = cellType;
        }

        public void SetValue(int value)
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException();
            Value = value;
        }

        public int GetValue()
        {
            switch (CellType)
            {
                case CellType.Number:
                    return Value;
                case CellType.Blank:
                    return (int)CellType.Blank;
                case CellType.Bomb:
                    return (int)CellType.Bomb;
                case CellType.Marked:
                    return (int)CellType.Marked;
            }

            return Int32.MinValue;
        }

        public void IncreaseValue()
        {
            if (CellType == CellType.Bomb)
                return;
            if (CellType == CellType.Blank)
                CellType = CellType.Number;
            Value++;
        }

        public Cell Copy()
        {
            return (Cell)MemberwiseClone();
        }
    }
}