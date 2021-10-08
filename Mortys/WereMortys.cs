using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Mortys
{
    public class WerewolfMorty : IMorty
    {
        public int Health { get; set; } = 25;
        public void Scream()
        {
            Console.WriteLine("RAAWWWWWWOOOOOOOOoooooOOOOOOooooowwwww");
        }
        public void Hurt(int damage)
        {
            Health -= damage;
        }
        public int Attack()
        {
            return 5;
        }
    }
    public class HurtWereMorty : IMorty
    {
        public int Health { get; set; } = 10;
        public void Scream()
        {
            Console.WriteLine("*gasp* My... my chest hurts...");
        }
        public void Hurt(int damage)
        {
            Health -= damage;
        }
        public int Attack()
        {
            return 2;
        }
    }
}
