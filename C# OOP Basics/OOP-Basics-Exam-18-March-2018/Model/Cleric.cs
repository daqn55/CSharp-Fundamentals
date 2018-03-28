using DungeonsAndCodeWizards.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Model
{
    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.BaseHealth = 50;
            this.BaseArmor = 25;
            this.RestHealMultiplier = 0.5;
        }

        public override double RestHealMultiplier { get => base.RestHealMultiplier; protected set => base.RestHealMultiplier = value; }

        public void Heal(Character character)
        {
            this.Alive();
            character.Alive();

            if (this.Faction == character.Faction)
            {
                character.Health += this.AbilityPoints;
            }
            else
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

        }
    }
}
