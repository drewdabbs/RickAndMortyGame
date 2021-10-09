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
        public Attack Attack()
            // EFA -- This was... a challenge. It made a believer of me of naming with intent, if I wasn't before. Head is still a little off from this one but calling the class and the method 'Attack' I was not able to follow when this perfectly to find a fix for a long time. I understood it was the variable type 'int' as stated in the Module 2.3 that was causing the error, intellisense helped me that far. I just could not figure out a fix as the (Method)Attack returns two int's, a new enum, and a string. I just didn't understand where and how to start. Can I fix the (Class)Attack, or is it the (Method)Attack? Fun times, I am addicted to coffee again.
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
        public void Hurt(Attack attack)
        {
            if (attack.Type == DamageType.Piercing || attack.Type == DamageType.Shocking)
            {
                Health -= (int)Math.Floor(attack.Damage * 2.5);
            }
            else if (attack.Type == DamageType.Bludgeoning || attack.Type == DamageType.Psych)
            {
                Health -= (int)Math.Ceiling(attack.Damage * 1.5);
            }
            else
            {
                Health -= attack.Damage;
            }
        }
        public Attack Attack()
        {
            return new Attack(1, 2, DamageType.Bludgeoning, "Weak Punch");
        }
    }
}
