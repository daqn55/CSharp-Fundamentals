using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{
    private List<Driver> drivers;
    private int currentLap;
    private string weather;
    private Dictionary<string, string> driversWhosLostTheRace = new Dictionary<string, string>();
    private string completeLapsResult;

    public int LapsNumber { get; set; }
    public int TrackLength { get; set; }

    public RaceTower()
    {
        this.weather = "Sunny";
        drivers = new List<Driver>();
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            drivers.Add(DriverFactory.CreateDriver(commandArgs));
        }
        catch (ArgumentException a)
        {
            Console.WriteLine(a.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        drivers.Find(d => d.Name == commandArgs[1]).TotalTime += 20;
        switch (commandArgs[0])
        {
            case "Refuel":
                drivers.Find(d => d.Name == commandArgs[1]).Car.Refuel(double.Parse(commandArgs[2]));
                break;
            case "ChangeTyres":
                if (commandArgs[2] == "Hard")
                {
                    drivers.Find(d => d.Name == commandArgs[1])
                        .Car.ChangeTyre(new HardTyre(double.Parse(commandArgs[3])));
                }
                else if (commandArgs[2] == "Utrasoft")
                {
                    drivers.Find(d => d.Name == commandArgs[1])
                        .Car.ChangeTyre(new UltrasoftTyre(double.Parse(commandArgs[3]), double.Parse(commandArgs[4])));
                }
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        try
        {

            int numberOfLaps = int.Parse(commandArgs[0]);
            var sb = new StringBuilder();
            if (numberOfLaps > this.LapsNumber)
            {
                throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
            }
            else
            {
                for (int i = 0; i < numberOfLaps; i++)
                {
                    this.currentLap++;
                    for (int z = 0; z < drivers.Count; z++)
                    {
                        try
                        {
                            drivers[z].TotalTime += 60M / ((decimal)this.TrackLength / drivers[z].Speed());
                            drivers[z].Car.ReduceFuel(this.TrackLength, drivers[z].FuelConsumptionPerKm);
                            drivers[z].Car.Tyre.ReduceDegradation();
                        }
                        catch (ArgumentException a)
                        {
                            driversWhosLostTheRace.Add(drivers[z].Name, a.Message);
                            drivers.RemoveAt(z);
                            z -= 1;
                        }
                    }

                    for (int y = drivers.Count-1; y > 0; y--)
                    {
                        drivers = drivers.OrderBy(x => x.TotalTime).ToList();

                        bool aggressiveUltrasoftDriver = drivers[y-1].GetType().Name == "AggressiveDriver" && drivers[y-1].Car.Tyre.Name == "Utrasoft";
                        bool aggressiveUltrasoftDriverFirst = drivers[y].GetType().Name == "AggressiveDriver" && drivers[y].Car.Tyre.Name == "Utrasoft";
                        bool enduranceHardTyreDriverFirst = drivers[y].GetType().Name == "EnduranceDriver" && drivers[y].Car.Tyre.Name == "Hard";
                        bool enduranceHardTyreDriver = drivers[y-1].GetType().Name == "EnduranceDriver" && drivers[y-1].Car.Tyre.Name == "Hard";
                        var diffrence = Math.Abs(drivers[y].TotalTime - drivers[y - 1].TotalTime);
                        if ((aggressiveUltrasoftDriver || aggressiveUltrasoftDriverFirst) && diffrence <= 3) 
                        {
                            int driverToRemove = 0;
                            if (aggressiveUltrasoftDriver)
                            {
                                driverToRemove = y - 1;
                            }
                            else
                            {
                                driverToRemove = y;
                            }
                            if (weather == "Foggy")
                            {
                                driversWhosLostTheRace.Add(drivers[driverToRemove].Name, "Crashed");
                                drivers.RemoveAt(driverToRemove);
                            }
                            else
                            {
                                this.completeLapsResult = $"{drivers[y].Name} has overtaken {drivers[y - 1].Name} on lap {this.currentLap}.";
                                drivers[y].TotalTime -= 3;
                                drivers[y - 1].TotalTime += 3;
                            }
                        }
                        else if ((enduranceHardTyreDriver || enduranceHardTyreDriverFirst) && diffrence <= 3)
                        {
                            int driverToRemove = 0;
                            if (enduranceHardTyreDriver)
                            {
                                driverToRemove = y - 1;
                            }
                            else
                            {
                                driverToRemove = y;
                            }
                            if (weather == "Rainy")
                            {
                                driversWhosLostTheRace.Add(drivers[driverToRemove].Name, "Crashed");
                                drivers.RemoveAt(driverToRemove);
                            }
                            else
                            {
                                this.completeLapsResult = $"{drivers[y].Name} has overtaken {drivers[y - 1].Name} on lap {this.currentLap}.";
                                drivers[y].TotalTime -= 3;
                                drivers[y - 1].TotalTime += 3;
                            }
                        }
                        else if (diffrence <= 2)
                        {
                            this.completeLapsResult = $"{drivers[y].Name} has overtaken {drivers[y - 1].Name} on lap {this.currentLap}.";
                            drivers[y].TotalTime -= 2;
                            drivers[y - 1].TotalTime += 2;
                        }
                    }
                }
                if (this.currentLap == this.LapsNumber)
                {
                    var winer = drivers.OrderBy(d => d.TotalTime).First();
                    var secondsForLap = 60 / (this.TrackLength / winer.Speed());
                    string result = $"{winer.Name} wins the race for {(winer.TotalTime):f3} seconds.";
                    this.completeLapsResult = result;
                }
            }
        }
        catch (ArgumentException a)
        {
            Console.WriteLine(a.Message);
        }
        return this.completeLapsResult;
    }

    public string GetLeaderboard()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.currentLap} / {this.LapsNumber}");

        int count = 1;
        foreach (var d in drivers.OrderBy(x => x.TotalTime))
        {
            sb.AppendLine($"{count} {d.Name} {d.TotalTime:f3}");
            count++;
        }

        foreach (var f in driversWhosLostTheRace.Reverse())
        {
            sb.AppendLine($"{count} {f.Key} {f.Value}");
            count++;
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

}

