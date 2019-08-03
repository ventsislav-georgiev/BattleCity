using BattleCity.Core.CommonTypes;

namespace BattleCity.Core.Utils
{
    internal class Node : Point
    {
        public bool Walkable { get; set; }
        public bool Opened { get; set; }
        public bool Closed { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, bool walkable)
            : base(x, y)
        {
            this.Walkable = walkable;
        }

        public Node(Point point, bool walkable)
            : base(point)
        {
            this.Walkable = walkable;
        }
    }
}