using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split();
        string[] truckInfo = Console.ReadLine().Split();
        List<Vehicles> vehicles = new List<Vehicles>();
        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
        vehicles.Add(car);
        vehicles.Add(truck);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                switch (input[0])
                {
                    case "Drive":
                        if (input[1] == "Car")
                        {
                            Console.WriteLine(vehicles.Find(x => x.GetType().Name == "Car").VehicleTravelled(
                                double.Parse(input[2]), "Car", 0.9));
                        }
                        else if (input[1] == "Truck")
                        {
                            Console.WriteLine(vehicles.Find(x => x.GetType().Name == "Truck").VehicleTravelled(
                                double.Parse(input[2]), "Truck", 1.6));
                        }
                        break;
                    case "Refuel":
                        if (input[1] == "Car")
                        {
                            vehicles.Find(x => x.GetType().Name == "Car").VehicleRefueling(
                                double.Parse(input[2]), "Car", 1);
                        }
                        else if (input[1] == "Truck")
                        {
                            vehicles.Find(x => x.GetType().Name == "Truck").VehicleRefueling(
                                double.Parse(input[2]), "Truck", 0.95);
                        }
                        break;
                }
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
        }
        foreach (var item in vehicles)
        {
            Console.WriteLine(item.GetType().Name + $": {item.FuelQuantity:f2}");
        }
    }
}

