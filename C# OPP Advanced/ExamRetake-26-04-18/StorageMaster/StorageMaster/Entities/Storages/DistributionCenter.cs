using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Entities.Storages
{
    public class DistributionCenter : Storage
    {
        private const int capacity = 2;
        private const int garageSlots = 5;

        public DistributionCenter(string name)
            : base(name, capacity, garageSlots, new Vehicle[] { new Van(), new Van(), new Van() })
        {
        }
    }
}
