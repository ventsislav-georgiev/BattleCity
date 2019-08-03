using System;
using System.Collections.Generic;
using System.Threading;
using BattleCity.Core.Utils;

namespace BattleCity.Core.ScreenText
{
    public class GameScreen
    {
        private static int sleepdelay = 50;
        private static string logo = ContentResolver.GetEmbeddedResource(@"Content\TextArt\logo.txt");

        public static void SetScreen()
        {
            Console.WindowHeight = 54;
            Console.BufferHeight = 54;
            Console.WindowWidth = 115;
            Console.BufferWidth = 115;
        }

        public static void SetLevelScreen()
        {
            Console.WindowHeight = 44;
            Console.BufferHeight = 44;
            Console.WindowWidth = 66;
            Console.BufferWidth = 66;
        }

        private static void PrintLogo()
        {
            foreach (var item in logo)
            {
                if (item != '\n')
                {
                    if (item == 'M')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(item);
                }
            }
        }

        private static void PrintLogoAnimated()
        {
            List<char> row = new List<char>();
            foreach (var item in logo)
            {
                if (item == '\n')
                {
                    foreach (var symbol in row)
                    {
                        if (symbol == 'M')
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write(symbol);
                    }
                    Thread.Sleep(sleepdelay);
                    row.Clear();
                }
                else
                {
                    row.Add(item);
                }
            }
        }

        public static void BattleCity()
        {
            Console.CursorVisible = false;
            SetScreen();
            Sounds.NewGameLevelSound();

            Console.Clear();
            PrintLogoAnimated();

            Thread.Sleep(sleepdelay);

            for (int i = 50; i > 24; i = i - 2)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(47, i + 2);
                Console.WriteLine("PRESS ANY KEY TO START");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(47, i);
                Console.WriteLine("PRESS ANY KEY TO START");

                Thread.Sleep(sleepdelay);
            }

            Console.ReadKey(true);
        }
    }
}