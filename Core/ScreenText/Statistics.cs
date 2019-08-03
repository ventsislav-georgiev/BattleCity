using System;
using System.IO;
using System.Text.RegularExpressions;
using BattleCity.Core.Entities.Tanks;
using BattleCity.Core.Levels;
using BattleCity.Core.Utils;

namespace BattleCity.Core.ScreenText
{
    // Rank1 - 5 pts.
    // Rank2 - 10 pts.
    // Rank3 - 15 pts.
    // Rank4 - 20 pts.
    // * LevelReached
    internal class Statistics
    {
        public static int Player1Points;
        public static string StatisticsPath;

        static Statistics()
        {
            var path = @"Content\TextArt\statistics.txt";
            StatisticsPath = Path.Combine(Path.GetTempPath(), Path.GetFileName(path));
            if (!File.Exists(StatisticsPath))
            {
                using (var stream = File.OpenWrite(StatisticsPath))
                {
                    ContentResolver.GetEmbeddedResourceStream(path).CopyTo(stream);
                }
            }
        }

        public static void ShowScore(int x, int y, ConsoleColor frontcolor, ConsoleColor backcolor)
        {
            int highScore = GetHighScore();
            ConsoleUtil.Write(x, y, "Enter your name: ", ConsoleColor.Red, backcolor);
            Console.ForegroundColor = frontcolor;
            string playerName = Console.ReadLine();
            y = y + 3;
            ConsoleUtil.Write(x, y, "Your current score is:", ConsoleColor.Red, backcolor);
            y++;
            ConsoleUtil.Write(x + 1, y, Player1Points.ToString(), frontcolor, backcolor);
            y = y + 2;
            ConsoleUtil.Write(x, y, "The game's high score is:", ConsoleColor.Red, backcolor);
            y++;
            ConsoleUtil.Write(x + 1, y, highScore.ToString(), frontcolor, backcolor);
            y = y + 2;
            if (Player1Points > highScore)
            {
                ConsoleUtil.Write(x, y, "Congratulations! You have the new HIGH SCORE!", frontcolor, backcolor);
            }
            WriteStatsToFile(playerName);
        }

        private static void PrintScores()
        {
            var streamReader = new StreamReader(StatisticsPath);

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                }
            }
        }

        private static int GetHighScore()
        {
            int highScore = 0;
            var streamReader = new StreamReader(StatisticsPath);

            using (streamReader)
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    if (line[0] == '>')
                    {
                        string resultString = Regex.Match(line, @"\d+").Value;
                        int score = Int32.Parse(resultString);
                        if (score >= highScore)
                        {
                            highScore = score;
                        }
                    }
                    line = streamReader.ReadLine();
                }
            }
            return highScore;
        }

        private static void WriteStatsToFile(string playerName)
        {
            //var statsFile = File.Open(@"Statistics.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var streamWriter = new StreamWriter(StatisticsPath, true);

            using (streamWriter)
            {
                streamWriter.WriteLine("*********************");
                streamWriter.WriteLine("> {0} - {1} ", playerName, Player1Points);
                streamWriter.WriteLine("*********************");
            }
            //statsFile.Close();
        }

        public static void DestroyTankPoints(TankRank destroyedTank)
        {
            if (destroyedTank == TankRank.Rank1)
            {
                Player1Points += 5;
            }
            else if (destroyedTank == TankRank.Rank2)
            {
                Player1Points += 10;
            }
            else if (destroyedTank == TankRank.Rank1)
            {
                Player1Points += 15;
            }
            else if (destroyedTank == TankRank.Rank1)
            {
                Player1Points += 20;
            }
        }

        private static void FinishLevelPoints(LevelType level)
        {
            string levelNumberStr = level.ToString();
            int levelValue = int.Parse(levelNumberStr.TrimStart('_'));

            Player1Points += (100 * levelValue);
        }
    }
}