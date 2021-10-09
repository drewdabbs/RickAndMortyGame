using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public class Room
    {
        public List<Item> Items { get; }
        public void RemoveItem(Item item)
        {
            if(Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        public string Splash { get; }
        public List<string> Exits { get; }
        public List<Event> Events { get; }
        public Room(string splash, List<string> exits, List<Item> items, List<Event> events)
        {
            Splash = splash;
            Exits = exits;
            Items = items;
            Events = events;
        }
        public void ResolveEvent(Event resolvedEvent)
        {
            if (Events.Contains(resolvedEvent))
            {
                Events.Remove(resolvedEvent);
            }
        }
    }
}
