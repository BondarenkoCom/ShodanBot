using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ShodanAi.Settings
{
    public class PlayerSounds
    {
        internal static void PlayPathSounds(string pathQuote)
        {
            SoundPlayer player = new SoundPlayer(pathQuote);
            player.LoadAsync();
            player.PlayLooping();
            System.Threading.Thread.Sleep(7000);
            player.Stop();
        }
    }
}
