using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public class Room
    {
        public string Splash { get; }
        public List<string> Exits { get; }
        public Room(string splash, List<string> exits)
        {
            Splash = splash;
            Exits = exits;
        }
    }
}
