using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace ShodanAi.Settings
{
    public static class PlayerSounds
    {
        private static readonly object SyncRandom = new();
        private static readonly Random Random = new();

        internal static void PlayPathSounds(string pathQuote)
        {
            string resolvedPath = ResolvePath(pathQuote);

            if (!File.Exists(resolvedPath))
            {
                return;
            }

            _ = Task.Run(() =>
            {
                try
                {
                    using SoundPlayer player = new(resolvedPath);
                    player.Load();
                    player.PlaySync();
                }
                catch
                {
                    // If the waveform cannot be rendered, the AI simply withholds the response.
                }
            });
        }

        internal static void PlayRandomFrom(string relativeFolder)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string resolvedFolder = Path.IsPathRooted(relativeFolder)
                ? relativeFolder
                : Path.Combine(baseDirectory, relativeFolder);

            if (!Directory.Exists(resolvedFolder))
            {
                return;
            }

            string[] candidates = Directory.GetFiles(resolvedFolder, "*.wav", SearchOption.AllDirectories);
            if (candidates.Length == 0)
            {
                return;
            }

            string clip;
            lock (SyncRandom)
            {
                clip = candidates[Random.Next(candidates.Length)];
            }

            PlayPathSounds(clip);
        }

        private static string ResolvePath(string input)
        {
            if (Path.IsPathRooted(input))
            {
                return input;
            }

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDirectory, input);
        }
    }
}
