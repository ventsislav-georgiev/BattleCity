using System.IO;
using System.Media;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace BattleCity.Core.Utils
{
    internal static class Sounds
    {
        public static WindowsMediaPlayer Player = new WindowsMediaPlayer();
        public static string AppDirectory = Directory.GetParent(Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName;

        public static void TankEngine()
        {
            var path = @"Content\Sounds\TankMoving.wav";
            var filePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(path));
            if (filePath != Player.URL)
            {
                if (!File.Exists(filePath))
                {
                    using (var stream = File.OpenWrite(filePath))
                    {
                        ContentResolver.GetEmbeddedResourceStream(path).CopyTo(stream);
                    }
                }

                Player.URL = filePath;
                Player.settings.setMode("loop", true);
                Player.controls.play();
            }
        }

        public static void FireWeapon()
        {
            using (SoundPlayer fireWeapon = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\FireWeapon.wav")))
            {
                fireWeapon.Play();
                Thread.Sleep(500);
            }
        }

        public static void NewGameLevelSound()
        {
            using (SoundPlayer newGameLevel = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\StartNew.wav")))
            {
                newGameLevel.Play();
            }
        }

        public static void PowerUp()
        {
            using (SoundPlayer powerUp = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\PowerUp.wav")))
            {
                powerUp.Play();
            }
        }

        public static void Highscore()
        {
            using (SoundPlayer highscoreReached = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\Highscore.wav")))
            {
                highscoreReached.Play();
            }
        }

        public static void EnenmyKilled()
        {
            using (SoundPlayer enemyKilled = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\EnenmyKilled.wav")))
            {
                enemyKilled.Play();
            }
        }

        public static void GameOver()
        {
            using (SoundPlayer gameOver = new SoundPlayer(ContentResolver.GetEmbeddedResourceStream(@"Content\Sounds\Gameover.wav")))
            {
                gameOver.Play();
            }
        }
    }
}