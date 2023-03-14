using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShodanAi.AbstractShodan
{
    class NewHacker : Shodan
    {
        public NewHacker(string name, string pathQuote) : base(name, pathQuote) { }
    }

    class OldHacker : Shodan
    {
        public OldHacker(string name, string pathQuote) : base(name, pathQuote) { }

    }
    class FreeHacker : Shodan
    {
        public FreeHacker(string name, string pathQuote) : base(name, pathQuote) { }

    }
}