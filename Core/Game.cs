using System;
using System.Linq;
using System.Threading;
using BattleCity.Core.Entities.Tanks;
using BattleCity.Core.Levels;
using BattleCity.Core.ScreenText;
using BattleCity.Core.Utils;

namespace BattleCity.Core
{
    internal abstract class Game
    {
        private static int _currentLevel = 0;
        public static Level Level;
        public static bool IsGameLevelRunning;
        public static CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        protected static void Start()
        {
            GameScreen.BattleCity();
            Console.Clear();
            Sounds.TankEngine();
            Game.Continue(true);
            Play();
        }

        public static void NextLevel()
        {
            CancellationTokenSource.Cancel();
            Thread.Sleep(100);
            CancellationTokenSource = new CancellationTokenSource();

            if (Level != null)
            {
                Console.Clear();
            }

            GameScreen.SetLevelScreen();

            var nextLevel = (LevelType)Enum.Parse(typeof(LevelType),
                _currentLevel > 9 ?
                "_" + _currentLevel :
                "_0" + _currentLevel);

            IsGameLevelRunning = true;
            Level = new Level(nextLevel);
            Level.Write();
            ScoreScreen.SideScreen(Level.Player1, Level.Type, Level.AITanks);
        }

        public static void LevelEnd()
        {
            foreach (var entity in Level.Entities)
            {
                entity.IsDestroyed = true;
            }
            Level = null;
        }

        public static void Continue(bool success)
        {
            if (success)
            {
                _currentLevel++;
                NextLevel();
                Border.DrawBorder();
            }
            else
            {
                Start();
            }
        }

        private static void Play()
        {
            while (true)
            {
                if (Level != null && !Level.AITanks.Any(rank => rank.Value > 0) && !Level.Entities.Any(entity => entity is AI))
                {
                    Game.Continue(true);
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    while (Console.KeyAvailable) { Console.ReadKey(true); }
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.DownArrow:

                        case ConsoleKey.LeftArrow:

                        case ConsoleKey.RightArrow:

                        case ConsoleKey.UpArrow:
                            if (Level != null)
                                Level.Player1.Move(keyPressed.Key);
                            break;

                        case ConsoleKey.Spacebar:
                            if (Level != null)
                            {
                                Level.Player1.Fire();
                                Sounds.FireWeapon();
                            }
                            break;
                        case ConsoleKey.Z:
                            Game.Continue(true);
                            break;
                        default:
                            break;
                    }
                }

                Thread.Sleep(60);
            }
        }
    }
}