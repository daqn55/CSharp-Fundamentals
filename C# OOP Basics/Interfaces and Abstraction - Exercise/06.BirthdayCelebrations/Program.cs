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

            switch (input[0])
            {
                case "Citizen":
                    cityData.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4]));
                    break;
                case "Robot":
                    cityData.Add(new Robot(input[1], input[2]));
                    break;
                case "Pet":
                    cityData.Add(new Pet(input[1], input[2]));
                    break;
            }
        }
        string yearToCheck = Console.ReadLine();
        foreach (var x in cityData)
        {
            if (x.SpecificBirthday(yearToCheck) != "")
            {
                Console.WriteLine(x.SpecificBirthday(yearToCheck));
            }
        }
    }
}
