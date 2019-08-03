using System;
using BattleCity.Core.CommonTypes;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.ScreenText;

namespace BattleCity.Core.Entities
{
    internal abstract class BaseEntity<TEntity> : BaseEntityAffection<TEntity>
        where TEntity : IEntity
    {
        public event EventHandler DestroyEvent;

        public virtual bool OnDestroy()
        {
            if (this.InvokeEvent(this.DestroyEvent))
            {
                if ((this is Item) && (this as Item).Type == ItemType.BaseFlag)
                {
                    GameOver.EndScreen();
                }
            }
            return true;
        }

        public int ID { get; set; }
        public char[,] Symbols { get; protected set; }

        public ConsoleColor Color { get; private set; }

        public Point Position { get; set; }

        public Direction Direction { get; set; }
        public bool CanBeDestroyed { get; protected set; }

        public bool IsDestroyed { get; set; }

        public virtual bool IsHidden { get; set; }

        public BaseEntity(char[,] symbols, ConsoleColor color, EntityAffection affection)
        {
            this.Symbols = symbols ?? throw new ArgumentNullException();
            this.Color = color;
            this.CanBeDestroyed = true;
            this.AddAffections(affection);
        }

        public void Move(Direction direction)
        {
            if (!this.IsHidden)
            {
                this.Clear();
            }

            var oldPosition = new Point(this.Position);
            if (this.Direction == direction)
            {
                this.Position = GetPosition(direction);
            }

            this.Direction = direction;
            Console.WriteLine();
            if (!OnMoveEvent())
            {
                this.Position = oldPosition;
            }

            if (!this.IsDestroyed && !this.IsHidden)
            {
                this.Write();
            }
        }

        public Point GetPosition(Direction direction)
        {
            var position = new Point(this.Position);
            switch (direction)
            {
                case Direction.Up:
                    position.Y--;
                    break;

                case Direction.Left:

                    position.X--;
                    break;

                case Direction.Down:
                    position.Y++;
                    break;

                case Direction.Right:
                    position.X++;
                    break;
            }
            return position;
        }

        public Point GetDirectionPosition()
        {
            var size = this.Symbols.GetLength(0);
            var middleSize = size / 2;
            size--;

            var position = new Point(this.Position);

            switch (this.Direction)
            {
                case Direction.Up:
                    position.X += middleSize;
                    break;

                case Direction.Left:
                    position.Y += middleSize;
                    break;

                case Direction.Down:
                    position.X += middleSize;
                    position.Y += size;
                    break;

                case Direction.Right:
                    position.X += size;
                    position.Y += middleSize;
                    break;
            }
            return position;
        }

        private void AddAffections(EntityAffection affection)
        {
            this.AddAction(EntityAffectionType.Destroy, (entity) =>
                {
                    if (this.CanBeDestroyed)
                    {
                        if ((!(this is Item) || (this as Item).Type != ItemType.Projectile))
                        {
                            this.Clear();
                        }
                        this.IsDestroyed = true;
                        return this.OnDestroy();
                    }
                    return false;
                }).AddAction(EntityAffectionType.Nothing, (entity) =>
                {
                    if (!this.IsHidden && entity is Item && (entity as Item).ID == this.ID)
                    {
                        return true;
                    }
                    return false;
                });

            foreach (var affectAction in affection.AffectActions)
            {
                this.AddAction(affectAction.Key, affectAction.Value);
            }

            foreach (var affectedType in affection.AffectedTypes)
            {
                this.AddAffection(affectedType.Key, affectedType.Value);
            }
        }

        public Point[] GetPositionOnLayout()
        {
            char[,] orientedSymbols = this.GetSymbols();
            Point[] positionOnLayout = new Point[orientedSymbols.Length];
            int counter = 0;
            for (int rowIndex = 0; rowIndex < orientedSymbols.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < orientedSymbols.GetLength(1); colIndex++)
                {
                    positionOnLayout[counter] = new Point(this.Position.X + rowIndex, this.Position.Y + colIndex);
                    counter++;
                }
            }

            return positionOnLayout;
        }
    }
}