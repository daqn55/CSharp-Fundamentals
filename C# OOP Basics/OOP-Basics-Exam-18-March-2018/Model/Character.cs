using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Model
{
    public abstract class Character
    {
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.BaseHealth = double.MaxValue;
            this.BaseArmor = double.MaxValue;
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            this.RestHealMultiplier = 0.2;
        }

        private string name;

        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth { get; protected set; }

        private double health;

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double BaseArmor { get; protected set; }

        private double armor;

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    value = this.BaseArmor;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double AbilityPoints { get; protected set; }
        public Bag Bag { get; protected set; }
        public Faction Faction { get; protected set; }
        public bool IsAlive { get; set; }
        public virtual double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (this.Armor - hitPoints < 0)
                {
                    var hitPointLeft = Math.Abs(this.Armor - hitPoints);
                    this.Armor = 0;
                    if (this.Health - hitPointLeft < 0)
                    {
                        this.Health = 0;
                    }
                    else
                    {
                        this.Health -= hitPointLeft;
                    }
                }
                else
                {
                    this.Armor -= hitPoints;
                }
                if (this.Health == 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                var currHealth = this.Health + (this.BaseHealth * this.RestHealMultiplier);
                if (currHealth > this.BaseHealth)
                {
                    this.Health = this.BaseHealth;
                }
                else
                {
                    this.Health += (this.BaseHealth * this.RestHealMultiplier);
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Bag.AddItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
        }

        public void Alive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
