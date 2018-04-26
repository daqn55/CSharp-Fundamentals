using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages
{
    public abstract class Storage
    {
        private readonly Vehicle[] garage;
        private readonly List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];
            this.PutVehicleToGarage(vehicles);
            this.products = new List<Product>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.garage);

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public bool IsFull => this.Products.Sum(w => w.Weight) >= this.Capacity ? true : false;

        private void PutVehicleToGarage(IEnumerable<Vehicle> vehicles)
        {
            int count = 0;
            foreach (var item in vehicles)
            {
                this.garage[count] = item;
                count++;
            }
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.garage.Length)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            else if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            var vehicleToGet = this.garage[garageSlot];

            return vehicleToGet;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var getVehicle = this.GetVehicle(garageSlot);

            if (deliveryLocation.Garage.Any(x => x == null))
            {
                this.garage[garageSlot] = null;
                int freeGarageSlot = 0;

                foreach (var item in deliveryLocation.Garage)
                {
                    if (item == null)
                    {
                        deliveryLocation.garage[freeGarageSlot] = getVehicle;
                        break;
                    }
                    freeGarageSlot++;
                }

                return freeGarageSlot;
            }
            else
            {
                throw new InvalidOperationException("No room in garage!");
            }
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var getVehicle = this.GetVehicle(garageSlot);

            int trunkcount = getVehicle.Trunk.Count;
            int numOfUnloadedProducts = 0;
            for (int i = 0; i < trunkcount; i++)
            {
                if (IsFull)
                {
                    break;
                }

                this.products.Add(getVehicle.Unload());
                numOfUnloadedProducts++;
            }

            return numOfUnloadedProducts;
        }
    }
}
