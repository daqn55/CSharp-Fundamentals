using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new Engine();
            engine.EngineSpeed = int.Parse(carData[1]);
            engine.EnginePower = int.Parse(carData[2]);

            Cargo cargo = new Cargo();
            cargo.CargoWeight = int.Parse(carData[3]);
            cargo.CargoType = carData[4];

            Tire tire = new Tire();
            tire.TirePressure.Add(double.Parse(carData[5]));
            tire.TirePressure.Add(double.Parse(carData[7]));
            tire.TirePressure.Add(double.Parse(carData[9]));
            tire.TirePressure.Add(double.Parse(carData[11]));
            tire.TireAge.Add(int.Parse(carData[6]));
            tire.TireAge.Add(int.Parse(carData[8]));
            tire.TireAge.Add(int.Parse(carData[10]));
            tire.TireAge.Add(int.Parse(carData[12]));

            Car car = new Car(carData[0], engine, cargo, tire);
            cars.Add(car);
        }
        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var c in cars.Where(x => x.Cargo.CargoType == "fragile"))
            {
                if (c.Tire.TirePressure.Any(x => x < 1))
                {
                    Console.WriteLine(c.Model);
                }
            }
        }
        else if(command == "flamable")
        {
            foreach (var c in cars.Where(x => x.Cargo.CargoType == "flamable"))
            {
                if (c.Engine.EnginePower > 250)
                {
                    Console.WriteLine(c.Model);
                }
            }
        }
    }
}

