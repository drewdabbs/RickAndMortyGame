using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public class ProgramUI
    {
        Dictionary<string, Room> Rooms = new Dictionary<string, Room>
        {
            {"garage", garage },
            {"house", house },
            {"driveway", driveway }
        };
        public static Room garage = new Room(
            "\n\n\n\n\nYou're in the garage with all your junk and crap\n\n" +
            "Obvious exits are DRIVEWAY and HOUSE\n",
            new List<string> { "driveway", "house" }
            );
        // Note on the EFA module for this, pt 1.1 omits the variable type declaration, <string>, each time this List is implemented breaking the code. Not a pleasant Google search.
        public static Room driveway = new Room(
            "\n\n\n\n\nYou're in the driveway. The car is gone but " +
            "the oil stain is still there.\n\n" +
            "Obvious exits are GARAGE and YARD\n",
            new List<string> { "garage" }
            );
        public static Room house = new Room(
            "\n\n\n\n\nYou're in the house now. It's drab and smells like \n" +
            "lemon pine-sol with a hint of stale fart.\n\n" +
            "Obvious exits are GARAGE and KITCHEN\n",
            new List<string> { "garage" }
            );

        public void Run()
        {
            Room currentRoom = garage;

            Console.Clear();
            Console.WriteLine("You accidentally killed Morty. \n" +
                "In order to construct a passable facimile, you must collect " +
                "enough Mortys from other dimensions to assemble from them " +
                "Morty's genetic structure and connectome.");
            bool alive = true;
            while (alive)
            {
                Console.Clear();
                Console.WriteLine(currentRoom.Splash);
                string command = Console.ReadLine().ToLower();

                if (command.StartsWith("go ") || command.StartsWith("exit "))
                {
                    foreach (string exit in currentRoom.Exits)
                    {
                        if (command.Contains(exit) && Rooms.ContainsKey(exit))
                        {
                            currentRoom = Rooms[exit];
                            foundExit = true;
                            // foundExit has not been implemented as a bool as of pt 1.2, may be corrected later
                            break;
                        }
                    }
                    if (!foundExit)
                    {
                        Console.WriteLine("Uh... Go Where?");
                    }
                    //if (command.Contains("garage"))
                    //{
                    //    currentRoom = garage;
                    //}
                    //else if (command.Contains("driveway"))
                    //{
                    //    currentRoom = driveway;
                    //}
                    //else if (command.Contains("house"))
                    //{
                    //    currentRoom = house;
                    //}
                    //Console.WriteLine("Uh... Go Where?");
                }
                else if (command.StartsWith("get ") || command.StartsWith("take ") || command.StartsWith("grab"))
                {
                    Console.WriteLine("I don't know what you're talking about");
                }
                else if (command.StartsWith("use ") || command.StartsWith("activate"))
                {
                    Console.WriteLine("I doubt you know how.");
                }
                else
                {
                    Console.WriteLine("*BUUURP* What?");
                }

            }

        }
    }
}