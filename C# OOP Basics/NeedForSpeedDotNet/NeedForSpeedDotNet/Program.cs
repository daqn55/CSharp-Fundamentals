using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager();
        while (true)
        {
            string end = Console.ReadLine();
            string[] input = end.Split();
            if (end == "Cops Are Here")
            {
                break;
            }

            switch (input[0])
            {
                case "register":
                    var id = int.Parse(input[1]);
                    var type = input[2];
                    var brand = input[3];
                    var model = input[4];
                    var yearOfProduction = int.Parse(input[5]);
                    var horsepower = int.Parse(input[6]);
                    var acceleration = int.Parse(input[7]);
                    var suspension = int.Parse(input[8]);
                    var durability = int.Parse(input[9]);
                    carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    Console.WriteLine(carManager.Check(int.Parse(input[1])));
                    break;
                case "open":
                    var idO = int.Parse(input[1]);
                    var typeO = input[2];
                    var length = int.Parse(input[3]);
                    var route = input[4];
                    var prizePool = int.Parse(input[5]);
                    if (input.Length == 7)
                    {
                        var extraParameter = int.Parse(input[6]);
                        carManager.Open(idO, typeO, length, route, prizePool, extraParameter);
                    }
                    else
                    {
                        carManager.Open(idO, typeO, length, route, prizePool);
                    }
                    break;
                case "participate":
                    var carId = int.Parse(input[1]);
                    var raceId = int.Parse(input[2]);
                    carManager.Participate(carId, raceId);
                    break;
                case "start":
                    Console.WriteLine(carManager.Start(int.Parse(input[1])));
                    break;
                case "park":
                    carManager.Park(int.Parse(input[1]));
                    break;
                case "unpark":
                    carManager.Unpark(int.Parse(input[1]));
                    break;
                case "tune":
                    carManager.Tune(int.Parse(input[1]), input[2]);
                    break;
            }
        }
    }
}

