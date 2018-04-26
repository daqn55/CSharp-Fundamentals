using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int capacity = 1;
        private const int garageSlots = 2;

        public AutomatedWarehouse(string name) 
            : base(name, capacity, garageSlots, new Vehicle[] {new Truck() })
        {
        }
    }
}
