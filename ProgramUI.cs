using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public enum Item { plumbus, meeseeks, portalgun };
    public class ProgramUI
    {
        //EFA -- public enum Item { plumbus, meeseeks, portalgun}; -- Intended or not, the module pt 1.3 instructs to create this enum in the ProgramUI class, but enum's cannoit be created in classes but must be created in the namespace
        public List<Item> inventory = new List<Item>();
        Dictionary<string, Room> Rooms = new Dictionary<string, Room>
        {
            {"garage", garage },
            {"house", house },
            {"driveway", driveway },
            {"laboratory", lab },
            {"lab", lab }
            // EFA -- Minor but module 3.2 lists this line of code ending in a comma as if another line of code followed, so is not needed.
        };
        public static Room garage = new Room(
            "\n\n\n\n\nYou're in the garage with all your junk and crap\n\n" +
            "Obvious exits are DRIVEWAY and HOUSE\n",
            new List<string> { "driveway", "house" },
            new List<Item> { Item.plumbus },
            new List<Event> {
                new Event(
                    "control panel",
                    EventType.Use,
                    new Result("laboratory", "You've opened the hatch to you LABORATORY.")
                    )
            }
            );
        // EFA -- The module pt 1.1 omits the variable type declaration, <string>, each time this List is implemented breaking the code. Not a pleasant Google search.
        public static Room driveway = new Room(
            "\n\n\n\n\nYou're in the driveway. The car is gone but " +
            "the oil stain is still there.\n\n" +
            "Obvious exits are GARAGE and YARD\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
            );
        public static Room house = new Room(
            "\n\n\n\n\nYou're in the house now. It's drab and smells like \n" +
            "lemon pine-sol with a hint of stale fart.\n\n" +
            "Obvious exits are GARAGE and KITCHEN\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
            );
        public static Room lab = new Room(
            "\n\n\n\n\n)You've entered your secret lab under the garage." +
            "It's way nicer than the rest of the house.\n\n" +
            "Obvious exits are GARAGE\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
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
                    bool foundExit = false;
                    // EFA -- This bool was not in the instruction, I added it so I could test without errors. As of module 2.2 this if and foreach is not implemented, nor does the conditional restrict player 'movement' as described. Typing the statements 'go' or 'exit' still places the user in any room stated.
                    foreach (string exit in currentRoom.Exits)
                    {
                        if (command.Contains(exit) && Rooms.ContainsKey(exit))
                        {
                            currentRoom = Rooms[exit];
                            foundExit = true;
                            // foundExit has not been implemented as a bool as of pt 1.2, may be corrected later. Instructions in pt 1.3 ask the student to run the program to test it, which cannot happen with this broken code/error. Perhaps this for each lesson can be delayed until later, using the original if else until then.
                            break;
                        }
                    }
                    if (!foundExit)
                    {
                        Console.WriteLine("Uh... Go Where?");
                    }
                    if (command.Contains("garage"))
                    {
                        currentRoom = garage;
                    }
                    else if (command.Contains("driveway"))
                    {
                        currentRoom = driveway;
                    }
                    else if (command.Contains("house"))
                    {
                        currentRoom = house;
                    }
                    Console.WriteLine("Uh... Go Where?");
                }
                else if (command.StartsWith("get ") || command.StartsWith("take ") || command.StartsWith("grab"))
                {
                    bool foundItem = false;
                    foreach(Item item in currentRoom.Items)
                    {
                        if(!foundItem && command.Contains(item.ToString()))
                            {
                            Random rand = new Random();
                            int flavorTextChoice = rand.Next(0, 3);
                            string flavorText;
                            switch (flavorTextChoice)
                            {
                                case 0:
                                    flavorText = "Don't lose it! ";
                                    break;
                                case 1:
                                    flavorText = "Good on you! ";
                                    break;
                                case 2:
                                default:
                                    flavorText = "Fantastic! ";
                                    break;
                            }
                            Console.WriteLine($"You found a(n) {item}. {flavorText}" +
                                $"Press any key to continue...");
                            currentRoom.RemoveItem(item);
                            inventory.Add(item);
                            foundItem = true;
                            Console.ReadKey();
                            break;
                        }
                    }
                    if (!foundItem)
                        // EFA thus far, unless I missed a step, (!foundItem) does not fire the Console.WriteLine
                    {
                        Console.WriteLine( "I don't know what you are talking about.");
                    }
                }
                else if (command.StartsWith("use ") || command.StartsWith("activate"))
                {
                    string eventMessage = "I doubt you know how.";
                    foreach (Event roomEvent in Room.Events)
                    {
                        if(!command.Contains(roomEvent.TriggerPhrase) || roomEvent.Type != EventType.Use)
                        {
                            continue;
                        }
                        if(roomEvent.EventResult.Type == ResultType.NewExit)
                            // EFA -- ResultType is not found in the Class 'Result' since it is an enum and is declared in the namespace. Since the namespace is already the same, the enum can be called directly. This happens a couple times below.
                        {
                            Room.AddExit(roomEvent.EventResult.ResultDestination);
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                        else if(roomEvent.EventResult.Type == ResultType.GetItem)
                        {
                            inventory.Add(roomEvent.EventResult.ResultItem);
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                        else if(roomEvent.EventResult.Type == ResultType.MessageOnly)
                        {
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                    }
                    Console.WriteLine(eventMessage);
                }
                else
                {
                    Console.WriteLine("*BUUURP* What?");
                }

            }

        }
    }
}