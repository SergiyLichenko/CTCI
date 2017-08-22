using System;

namespace Tasks.ObjectOrientedDesign.Minesweeper
{
    [Flags]
    public enum CellType
    {
        Blank = 0,
        Bomb = -1,
        Number = 1,
        Marked = -2,
        Hidden = -3
    }
}