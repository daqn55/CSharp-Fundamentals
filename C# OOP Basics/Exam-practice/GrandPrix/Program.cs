using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int numbersOfLaps = int.Parse(Console.ReadLine());
        int lengthOfTrack = int.Parse(Console.ReadLine());
        RaceTower raceTower = new RaceTower();
        raceTower.SetTrackInfo(numbersOfLaps, lengthOfTrack);
        bool finishTheRace = true;
        while (finishTheRace)
        {
            List<string> commandArgs = Console.ReadLine().Split().ToList();
            
            switch (commandArgs[0])
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string result = raceTower.CompleteLaps(commandArgs);
                    Console.WriteLine(result);
                    if (result != null && result.Split().Length > 2 && result.Split()[1] == "wins")
                    {
                        finishTheRace = false;
                    }
                    break;
                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;
            }
        }
    }
}

