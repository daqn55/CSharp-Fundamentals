using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Engine> engines = new List<Engine>();
        for (int i = 0; i < n; i++)
        {
            string[] dataEngine = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);

            Engine engine = new Engine();
            if (dataEngine.Length == 3)
            {
                bool displacementCheck = int.TryParse(dataEngine[2], out int displacement);
                if (!displacementCheck)
                {
                    engine.Efficiency = dataEngine[2];
                }
                else
                {
                    engine.Displacements = dataEngine[2];
                }
            }
            else if (dataEngine.Length == 4)
            {
                engine.Efficiency = dataEngine[3];
                engine.Displacements = dataEngine[2];
            }
            engine.Model = dataEngine[0];
            engine.Power = int.Parse(dataEngine[1]);

            engines.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (int i = 0; i < m; i++)
        {
            string[] dataCar = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car();
            if (dataCar.Length == 3)
            {
                bool weightCheck = int.TryParse(dataCar[2], out int weight);
                if (!weightCheck)
                {
                    car.Color = dataCar[2];
                }
                else
                {
                    car.Weight = dataCar[2];
                }
            }
            else if (dataCar.Length == 4)
            {
                car.Color = dataCar[3];
                car.Weight = dataCar[2];
            }
            car.Model = dataCar[0];
            car.Engine = engines.Find(x => x.Model == dataCar[1]);
            cars.Add(car);
        }

        foreach (var c in cars)
        {
            Console.WriteLine(c.ToString());
        }
    }
}

