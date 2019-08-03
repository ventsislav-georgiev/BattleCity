using System;
using BattleCity.Core.CommonTypes;
using BattleCity.Core.Entities;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.Levels;
using BattleCity.Core.Utils;

namespace BattleCity.Core
{
    internal delegate bool EventHandler();

    internal class ConsoleEntity<TEntity>
        where TEntity : IEntity
    {
        public event EventHandler MoveEvent;

        public bool OnMoveEvent()
        {
            return this.InvokeEvent(MoveEvent);
        }

        protected bool InvokeEvent(EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                return eventHandler();
            }
            return false;
        }

        public virtual void Write()
        {
            var entity = this as IEntity;
            var symbols = this.GetSymbols();

            for (int rowIndex = 0; rowIndex < entity.Symbols.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < entity.Symbols.GetLength(1); colIndex++)
                {
                    char character = symbols[rowIndex, colIndex];
                    var position = new Point(entity.Position.X + rowIndex, entity.Position.Y + colIndex);
                    ConsoleUtil.Write(position, character, entity.Color);
                }
            }
        }

        public virtual void Clear()
        {
            this.Write(ConsoleUtil.Empty);
        }

        public virtual void Move(ConsoleKey key)
        {
            var entity = this as IEntity;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    entity.Move(Direction.Up);
                    break;

                case ConsoleKey.LeftArrow:
                    entity.Move(Direction.Left);
                    break;

                case ConsoleKey.DownArrow:
                    entity.Move(Direction.Down);
                    break;

                case ConsoleKey.RightArrow:
                    entity.Move(Direction.Right);
                    break;
            }
        }

        private void Write(char character)
        {
            var entity = this as IEntity;
            for (int rowIndex = 0; rowIndex < entity.Symbols.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < entity.Symbols.GetLength(1); colIndex++)
                {
                    var position = new Point(entity.Position.X + rowIndex, entity.Position.Y + colIndex);
                    ConsoleUtil.Write(position, character, entity.Color);
                }
            }
        }

        public char[,] GetSymbols()
        {
            var entity = this as IEntity;
            char[,] symbols = entity.Symbols;

            switch (entity.Direction)
            {
                case Direction.Up:
                    break;

                case Direction.Left:
                    symbols = MatrixUtil.RotateLeft<char>(symbols);
                    break;

                case Direction.Down:
                    symbols = MatrixUtil.RotateRight<char>(symbols);
                    symbols = MatrixUtil.RotateRight<char>(symbols);
                    break;

                case Direction.Right:
                    symbols = MatrixUtil.RotateRight<char>(symbols);
                    break;
            }
            return symbols;
        }
    }
}