using System;
using BattleCity.Core.Utils;

namespace BattleCity.Core.ScreenText
{
    internal class Border
    {
        public static void DrawBorder()
        {
            for (int i = -1; i < 40; i++)
            {
                ConsoleUtil.Write(-2, i, "A", ConsoleColor.Gray, ConsoleColor.Gray);
            }

            for (int i = 0; i < 40; i++)
            {
                ConsoleUtil.Write(40, i, "A", ConsoleColor.Gray, ConsoleColor.Gray);
            }

            for (int i = -1; i < 41; i++)
            {
                ConsoleUtil.Write(i, -1, "A", ConsoleColor.Gray, ConsoleColor.Gray);
            }

            for (int i = -2; i < 41; i++)
            {
                ConsoleUtil.Write(i, 40, "A", ConsoleColor.Gray, ConsoleColor.Gray);
            }
        }
    }
}

// Write(int x, int y, string symbols,ConsoleColor color, ConsoleColor backgroundColor)