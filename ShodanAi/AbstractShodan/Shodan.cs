using ShodanAi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShodanAi.AbstractShodan
{
    public class Shodan
    {
        public string Name { get; }
        public string PathQuote { get; }
        protected Shodan(string name, string pathQuote)
        {
            Name = name;
            PathQuote = pathQuote;
        }
        public void WelcomeHacker() => PlayerSounds.PlayPathSounds(PathQuote);
        public void WelcomeHacker_Text() => Console.WriteLine($"Shodan see you - {Name}");
    }
}
