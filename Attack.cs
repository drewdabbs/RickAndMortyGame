using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame
{
    public enum DamageType { Bludgeoning, Slashing, Piercing, Poison, Acid, Sonic, Psych, Fire, Water, Ice, Shocking, Magic, Necrotic, Radiant};
    public class Attack
    {
        public int Damage;
        public DamageType Type;
        public string Name { get; set; }

        private readonly Random rand = new Random();

        public Attack(int minDamage, int maxDamage, DamageType type, string name)
            // EFA -- As written in module 2.2 adding 'string Name' throws an error, the string 'name' must be lowercase.
        {
            Type = type;
            Damage = rand.Next(minDamage, maxDamage +1);
            Name = name;
        }
    }
}
