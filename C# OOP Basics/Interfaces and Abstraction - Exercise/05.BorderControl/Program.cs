using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<CityData> cityData = new List<CityData>();
        while (true)
        {
            string[] input = Console.ReadLine().Split();
            if (input[0] == "End")
            {
                break;
            }

            if (input.Length == 3)
            {
                cityData.Add(new Citizen(input[0], int.Parse(input[1]), input[2]));
            }
            else if (input.Length == 2)
            {
                cityData.Add(new Robot(input[0], input[1]));
            }
        }
        string numToCheck = Console.ReadLine();
        foreach (var x in cityData)
        {
            if (x.fakeId(numToCheck))
            {
                Console.WriteLine(x.Id);
            }
        }
    }
}

