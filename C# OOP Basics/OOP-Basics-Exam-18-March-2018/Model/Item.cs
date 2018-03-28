using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Model
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; protected set; }

        public virtual void AffectCharacter(Character character)
        {
            character.Alive();
        }
    }
}
