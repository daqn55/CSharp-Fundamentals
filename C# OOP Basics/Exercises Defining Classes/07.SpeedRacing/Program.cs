using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carsToTrack = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = carsToTrack[0];
            decimal fuelAmount = decimal.Parse(carsToTrack[1]);
            decimal fuelConsumption = decimal.Parse(carsToTrack[2]);

            Car car = new Car();
            car.Model = model;
            car.FuelAmount = fuelAmount;
            car.FuelConsumption = fuelConsumption;

            cars.Add(car);
        }

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string carModel = commands[1];
            decimal amountOfKm = decimal.Parse(commands[2]);

            cars.Find(x => x.Model == carModel).DistanceTraveled += amountOfKm;
            if (cars.Find(x => x.Model == carModel).FuelLeft() < 0)
            {
                cars.Find(x => x.Model == carModel).DistanceTraveled -= amountOfKm;
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelLeft():f2} {c.DistanceTraveled}");
        }
    }
}

