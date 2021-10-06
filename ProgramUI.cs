using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public class ProgramUI
    {
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("You accidentally killed Morty. \n" +
                "In order to construct a passable facimile, you must collect " +
                "enough Mortys from other dimensions to assemble from them " +
                "Morty's genetic structure and connectome.");
            bool alive = true;
            while (alive)
            {
                string command = Console.ReadLine().ToLower();
                Console.Clear();
                if (command.StartsWith("go ") || command.StartsWith("exit "))
                {
                    Console.WriteLine("Uh... Go Where?");
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