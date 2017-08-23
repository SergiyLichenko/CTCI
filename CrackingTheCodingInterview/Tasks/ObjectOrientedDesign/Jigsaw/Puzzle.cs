using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.Jigsaw
{
    public class Puzzle
    {
        public Puzzle(PuzzleType type, PuzzleDirection direction)
        {
            Type = type;
            Direction = direction;
        }
        public bool IsUsed { get; set; }
        public PuzzleType Type { get; private set; }
        public PuzzleDirection Direction { get; private set; }
    }
}
