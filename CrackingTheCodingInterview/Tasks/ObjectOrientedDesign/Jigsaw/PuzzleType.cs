using System;

namespace Tasks.ObjectOrientedDesign.Jigsaw
{
    [Flags]
    public enum PuzzleType
    {
        Normal,
        SideFlatHorizontal,
        SideFlatVertical,
        Corner
    }
}