using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Model
{
    public abstract class Bag
    {
        private List<Item> thisItems;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.thisItems = new List<Item>();
            this.Items = new List<Item>();
            this.Load = 0;
        }

        public int Capacity { get; set; }
        public int Load { get; protected set; }
        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if ((this.Load + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                var t = (ICollection<Item>)this.Items;
                t.Add(item);
                this.Load += item.Weight;
            }
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count < 1)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (this.Items.FirstOrDefault(i => i.GetType().Name == name) == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            else
            {
                var itemToPass = this.Items.FirstOrDefault(i => i.GetType().Name == name);
                var t = (ICollection<Item>)this.Items;
                t.Remove(itemToPass);
                return itemToPass;
            }
        }
    }
}
