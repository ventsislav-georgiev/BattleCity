using System;
using BattleCity.Core.CommonTypes;
using BattleCity.Core.Entities.Items;
using BattleCity.Core.Levels;

namespace BattleCity.Core.Utils
{
    internal class ConsoleUtil
    {
        static public int offset = 2;
        private static readonly object _locker = new object();

        public const char Empty = ' ';

        public static void Clear(Point point, string symbols)
        {
            Write(point, new string(Empty, symbols.Length));
        }

        public static void Write(Point point, char symbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(point.X, point.Y, symbol.ToString(), color);
        }

        public static void Write(Point point, string symbols, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(point.X, point.Y, symbols, color);
        }

        public static void Write(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(x, y, symbol.ToString(), color);
        }

        public static void Write(int x, int y, string symbols, ConsoleColor color = ConsoleColor.Gray)
        {
            Write(x, y, symbols, color: color, backgroundColor: ConsoleColor.Black);
        }

        public static void Write(int x, int y, string symbols,
            ConsoleColor color,
            ConsoleColor backgroundColor)
        {
            lock (_locker)
            {
                if (!CanWrite(x, y, symbols))
                {
                    return;
                }

                Console.ForegroundColor = color;
                Console.BackgroundColor = backgroundColor;
                Console.SetCursorPosition(x + offset, y + offset);
                Console.Write(symbols);
            }
        }

        public static bool CanWrite(int x, int y, string symbols)
        {
            var currentLevel = Game.Level;
            if (currentLevel != null)
            {
                var levelLayout = currentLevel.Layout;
                var isInsideLayoutHeight = levelLayout.GetLength(0) > x && x >= 0;
                var isInsideLayoutWidth = levelLayout.GetLength(1) > y && y >= 0;

                if (isInsideLayoutHeight && isInsideLayoutWidth)
                {
                    var itemOnPosition = levelLayout[x, y];
                    switch (itemOnPosition.Type)
                    {
                        case ItemType.Forrest:
                        case ItemType.Water:
                            return symbols == itemOnPosition.Symbols[0,0].ToString();
                    }
                }
            }

            return true;
        }
    }
}