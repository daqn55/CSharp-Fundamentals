using DungeonsAndCodeWizards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Model
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;
        }

        public void Attack(Character character)
        {
            this.Alive();
            character.Alive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            else if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
            else
            {
                character.TakeDamage(this.AbilityPoints);
            }

        }
    }
}
