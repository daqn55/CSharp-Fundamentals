using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Citizen> citizen = new List<Citizen>();
        List<Rebel> rebels = new List<Rebel>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            if (input.Length == 4)
            {
                citizen.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
            }
            else if (input.Length == 3)
            {
                rebels.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
            }
        }

        int buyedFood = 0;
        while (true)
        {
            string name = Console.ReadLine();
            if (name == "End")
            {
                break;
            }
            if (citizen.Any(y => y.Name == name))
            {
                buyedFood += citizen.Find(x => x.Name == name).BuyFood();
            }
            else if (rebels.Any(s => s.Name == name))
            {
                buyedFood += rebels.Find(x => x.Name == name).BuyFood();
            }

        }

        Console.WriteLine(buyedFood);
    }
}

