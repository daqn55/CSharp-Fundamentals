using System;
using System.Collections.Generic;
using System.Text;
using StorageMaster.Entities.Vehicles;
using StorageMaster.Fatories;

namespace StorageMaster.Entities.Storages
{
    public class Warehouse : Storage
    {
        private const int capacity = 10;
        private const int garageSlots = 10;
        private VehicleFactory vehicleFactory;
        private IEnumerable<Vehicle> vehicles;

        public Warehouse(string name)
            : base(name, capacity, garageSlots, new List<Vehicle> { new Semi(), new Semi(), new Semi()})
        {
            this.vehicleFactory = new VehicleFactory();
        }

        private IEnumerable<Vehicle> makeDefaultVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                vehicles.Add(this.vehicleFactory.CreateVehicle("Semi"));
            }

            return vehicles;
        }
    }
}
