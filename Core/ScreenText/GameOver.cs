using System;
using System.Text;
using System.Threading;
using BattleCity.Core.Utils;

namespace BattleCity.Core.ScreenText
{
    internal class GameOver
    {
        public static void EndScreen()
        {
            Sounds.Player.controls.stop();
            Game.IsGameLevelRunning = false;
            Game.LevelEnd();

            Sounds.GameOver();
            Thread.Sleep(1500);
            Console.Clear();
            GameScreen.SetScreen();

            string gameOver = ContentResolver.GetEmbeddedResource(@"Content\TextArt\gameover.txt");
            StringBuilder readline = new StringBuilder();
            int rowindex = 0;
            foreach (var item in gameOver)
            {
                if (item != '\n')
                {
                    readline.Append(item);
                }
                else
                {
                    ConsoleUtil.Write(33, rowindex, readline.ToString(), ConsoleColor.Red, ConsoleColor.Black);
                    rowindex++;
                    readline.Clear();
                }
            }

            Statistics.ShowScore(35, 16, ConsoleColor.White, ConsoleColor.Black);

            Console.ReadKey(true);
            Game.Continue(false);
        }
    }
}