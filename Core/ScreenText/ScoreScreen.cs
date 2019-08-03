using System;
using System.Collections.Generic;
using BattleCity.Core.Entities.Tanks;
using BattleCity.Core.Levels;
using BattleCity.Core.Utils;

/*UNDER CONSTRUCTION*/

namespace BattleCity.Core.ScreenText
{
    internal class ScoreScreen
    {
        static public int scoreOffset = 42;

        private static void ShowScore()
        {
            ConsoleUtil.Write(scoreOffset, 12, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
            ConsoleUtil.Write(scoreOffset + 1, 12, Statistics.Player1Points.ToString(), ConsoleColor.Black, ConsoleColor.Gray);
        }

        //static void SetScreen()
        //{
        //    Console.WindowHeight = 54;
        //    Console.BufferHeight = 54;

        //    Console.WindowWidth = 120;
        //    Console.BufferWidth = 120;
        //}

        private static void ShowLives(int Lives)
        {
            ConsoleUtil.Write(scoreOffset, 8, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);

            ConsoleUtil.Write(scoreOffset + 1, 8, Lives.ToString(), ConsoleColor.Black, ConsoleColor.Gray);
        }

        private static void ShowLevel(LevelType level)
        {
            ConsoleUtil.Write(scoreOffset, 4, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
            string leveltostring = level.ToString();
            leveltostring = leveltostring.Trim('_');
            ConsoleUtil.Write(scoreOffset + 1, 4, leveltostring, ConsoleColor.Black, ConsoleColor.Gray);
        }

        private static void WriteLabels()
        {
            ConsoleUtil.Write(scoreOffset, 3, "       LEVEL        ", ConsoleColor.Gray, ConsoleColor.Black);
            ConsoleUtil.Write(scoreOffset, 4, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
            ConsoleUtil.Write(scoreOffset, 7, "   PLAYER 1 LIVES:  ", ConsoleColor.Gray, ConsoleColor.Black);
            ConsoleUtil.Write(scoreOffset, 8, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
            ConsoleUtil.Write(scoreOffset, 11, "  PLAYER 1 SCORE:   ", ConsoleColor.Gray, ConsoleColor.Black);
            ConsoleUtil.Write(scoreOffset, 12, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
            ConsoleUtil.Write(scoreOffset, 15, "    ENEMIES LEFT    ", ConsoleColor.Gray, ConsoleColor.Black);
            ConsoleUtil.Write(scoreOffset, 16, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
        }

        private static void EnemiesCount(Dictionary<TankRank, int> tanks)
        {
            int enemies = 0;
            if (tanks.ContainsKey(TankRank.Rank1))
            {
                enemies = enemies + tanks[TankRank.Rank1];
            }
            if (tanks.ContainsKey(TankRank.Rank2))
            {
                enemies = enemies + tanks[TankRank.Rank2];
            }
            if (tanks.ContainsKey(TankRank.Rank3))
            {
                enemies = enemies + tanks[TankRank.Rank3];
            }
            if (tanks.ContainsKey(TankRank.Rank4))
            {
                enemies = enemies + tanks[TankRank.Rank4];
            }

            int counter = 16;
            int newLine = 0;
            for (int i = 0; i < 2; i++)
            {
                ConsoleUtil.Write(scoreOffset, counter, "00000000000000000000", ConsoleColor.Gray, ConsoleColor.Gray);
                counter++;
            }
            counter = 16;
            int counter2 = scoreOffset + 3;
            for (int i = 0; i < enemies; i++)
            {
                Console.SetCursorPosition(scoreOffset, counter);
                if (newLine == 10)
                {
                    counter++;
                    newLine = 0;
                    counter2 = scoreOffset + 3;
                }
                ConsoleUtil.Write(counter2, counter, "@", ConsoleColor.Black, ConsoleColor.Gray);
                counter2++;

                newLine++;
            }
        }

        public static void SideScreen(ITank player, LevelType level, Dictionary<TankRank, int> tanks)
        {
            WriteLabels();
            ShowLives(player.Lives);
            ShowLevel(level);
            ShowScore();
            EnemiesCount(tanks);
        }
    }
}

/*

 public static void Write(int x, int y, string symbols,
			ConsoleColor color,
			ConsoleColor backgroundColor)

 */