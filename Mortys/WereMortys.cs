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
        public void Hurt(Attack attack)
        {
            if (attack.Type == DamageType.Piercing || attack.Type == DamageType.Shocking)
            {
                Health -= (int)Math.Floor(attack.Damage * 1.5);
            }
            else if (attack.Type == DamageType.Bludgeoning || attack.Type == DamageType.Psych)
            {
                Health -= (int)Math.Ceiling(attack.Damage * 0.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }
        public int Attack()
        {
            return new Attack(5, 10, DamageType.Slashing, "Paw Slap");
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
