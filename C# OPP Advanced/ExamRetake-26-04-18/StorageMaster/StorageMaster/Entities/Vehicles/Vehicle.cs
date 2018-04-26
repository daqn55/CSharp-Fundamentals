using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Vehicles
{
    public abstract class Vehicle
    {
        private readonly List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(w => w.Weight) >= this.Capacity ? true : false;

        public bool IsEmpty => this.Trunk.Count == 0 ? true : false;

        public void LoadProduct(Product product)
        {
            //if (this.IsFull)
            //{
            //    throw new InvalidOperationException("Vehicle is full!");
            //}

            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            var lastProduct = this.trunk.Last();
            this.trunk.RemoveAt(this.trunk.Count - 1);

            return lastProduct;
        }
    }
}
