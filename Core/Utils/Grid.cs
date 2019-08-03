using System.Collections.Generic;
using BattleCity.Core.Entities;
using BattleCity.Core.Entities.Items;

namespace BattleCity.Core.Utils
{
    internal class Grid
    {
        private int _width;
        private int _height;
        private Node[,] _nodes;

        public Grid(int width, int height, Item[,] layout)
        {
            this._width = width;
            this._height = height;
            this._nodes = BuildNodes(layout);
        }

        private static Node[,] BuildNodes(Item[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(1);
            Node[,] nodes = new Node[height, width];

            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (int colIndex = 0; colIndex < width; colIndex++)
                {
                    if (matrix[rowIndex, colIndex].Type.CompareTo(ItemType.Nothing) == 0 ||
                        matrix[rowIndex, colIndex].Type.CompareTo(ItemType.AISpawnPoint) == 0 ||
                        matrix[rowIndex, colIndex].Type.CompareTo(ItemType.PlayerSpawnPoint) == 0 ||
                        matrix[rowIndex, colIndex].Type.CompareTo(ItemType.Forrest) == 0)
                    {
                        nodes[rowIndex, colIndex] = new Node(rowIndex, colIndex, true);
                    }
                    else
                    {
                        nodes[rowIndex, colIndex] = new Node(rowIndex, colIndex, false);
                    }
                }
            }

            return nodes;
        }

        public Node GetNodeAt(int x, int y)
        {
            return this._nodes[x, y];
        }

        public bool isWalkableAt(int x, int y)
        {
            return this.isInside(x, y) && this._nodes[x, y] != null && this._nodes[x, y].Walkable;
        }

        public bool isInside(int x, int y)
        {
            return (x >= 0 && x < this._width) && (y >= 0 && y < this._height);
        }

        public void setWalkableAt(int x, int y)
        {
            this._nodes[x, y].Walkable = true;
        }

        public List<Node> getNeighbors(Node node)
        {
            int x = node.X;
            int y = node.Y;
            List<Node> neighbors = new List<Node>();

            if (this.isWalkableAt(x, y - 1))
            {
                neighbors.Add(this._nodes[x, y - 1]);
            }

            if (this.isWalkableAt(x, y + 1))
            {
                neighbors.Add(this._nodes[x, y + 1]);
            }

            if (this.isWalkableAt(x - 1, y))
            {
                neighbors.Add(this._nodes[x - 1, y]);
            }

            if (this.isWalkableAt(x + 1, y))
            {
                neighbors.Add(this._nodes[x + 1, y]);
            }

            return neighbors;
        }

        //public static Queue<Node> Backtrace(Node node)
        public static Queue<Direction> Backtrace(Node node)
        {
            //Queue<Node> path = new Queue<Node>();
            Queue<Direction> path = new Queue<Direction>();
            while (!Game.CancellationTokenSource.Token.IsCancellationRequested && node.Parent != null)
            {
                Node tempNode = node;
                //path.Enqueue(node);
                node = node.Parent;
                if (tempNode.X > node.X)
                {
                    path.Enqueue(Direction.Right);
                    path.Enqueue(Direction.Right);
                    path.Enqueue(Direction.Right);
                }
                else if (tempNode.X < node.X)
                {
                    path.Enqueue(Direction.Left);
                    path.Enqueue(Direction.Left);
                    path.Enqueue(Direction.Left);
                }
                else if (tempNode.Y > node.Y)
                {
                    path.Enqueue(Direction.Down);
                    path.Enqueue(Direction.Down);
                    path.Enqueue(Direction.Down);
                }
                else if (tempNode.Y < node.Y)
                {
                    path.Enqueue(Direction.Up);
                    path.Enqueue(Direction.Up);
                    path.Enqueue(Direction.Up);
                }
            }

            return path;
        }
    }
}