using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{
    private Tyre tyre;
    private List<Driver> drivers = new List<Driver>();
    private int currentLap;
    private string weather;
    private Dictionary<string, string> driversWhosLostTheRace = new Dictionary<string, string>();
    private string completeLapsResult;

    public int LapsNumber { get; set; }
    public int TrackLength { get; set; }

    public RaceTower()
    {
        this.weather = "Sunny";
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
            var name = commandArgs[2];
            var hp = int.Parse(commandArgs[3]);
            var fuelAmount = double.Parse(commandArgs[4]);
            var tyreType = commandArgs[5];
            var tyreHardness = double.Parse(commandArgs[6]);

            if (tyreType == "Ultrasoft")
            {
                var grip = double.Parse(commandArgs[7]);
                tyre = new UltrasoftTyre(tyreHardness, grip);
            }
            else if (tyreType == "Hard")
            {
                tyre = new HardTyre(tyreHardness);
            }

            Car car = new Car(hp, fuelAmount, tyre);

            if (commandArgs[1] == "Aggressive")
            {
                drivers.Add(new AggressiveDriver(name, car));
            }
            else if (commandArgs[1] == "Endurance")
            {
                drivers.Add(new EnduranceDriver(name, car));
            }
        }
        catch (ArgumentException a)
        {
            Console.WriteLine(a.Message);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        drivers.Find(d => d.Name == commandArgs[2]).TotalTime += 20;
        switch (commandArgs[1])
        {
            case "Refuel":
                drivers.Find(d => d.Name == commandArgs[2]).Car.Refuel(double.Parse(commandArgs[3]));
                break;
            case "ChangeTyres":
                if (commandArgs[3] == "Hard")
                {
                    drivers.Find(d => d.Name == commandArgs[2])
                        .Car.ChangeTyre(new HardTyre(double.Parse(commandArgs[4])));
                }
                else if (commandArgs[3] == "Utrasoft")
                {
                    drivers.Find(d => d.Name == commandArgs[2])
                        .Car.ChangeTyre(new UltrasoftTyre(double.Parse(commandArgs[4]), double.Parse(commandArgs[5])));
                }
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        try
        {

            int numberOfLaps = int.Parse(commandArgs[1]);
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
                            drivers[z].TotalTime += 60 / (this.TrackLength / drivers[z].Speed());
                            drivers[z].Car.ReduceFuel(this.TrackLength, drivers[z].FuelConsumptionPerKm);
                            drivers[z].Car.Tyre.ReduceDegradation();
                        }
                        catch (ArgumentException a)
                        {
                            driversWhosLostTheRace.Add(drivers[z].Name, a.Message);
                            drivers.RemoveAt(z);
                        }
                    }

                    for (int y = drivers.Count-1; y > 0; y--)
                    {
                        drivers = drivers.OrderBy(x => x.TotalTime).ToList();

                        bool aggressiveUltrasoftDriver = drivers[y].GetType().Name == "AggressiveDriver" && drivers[y].Car.Tyre.Name == "Utrasoft";
                        bool enduranceHardTyreDriver = drivers[y].GetType().Name == "EnduranceDriver" && drivers[y].Car.Tyre.Name == "Hard";
                        var diffrence = Math.Abs(drivers[y].TotalTime - drivers[y - 1].TotalTime);
                        if (aggressiveUltrasoftDriver && diffrence <= 3) 
                        {
                            if (weather == "Foggy")
                            {
                                driversWhosLostTheRace.Add(drivers[y].Name, "Crashed");
                                drivers.RemoveAt(y);
                            }
                            else
                            {
                                this.completeLapsResult = $"{drivers[y].Name} has overtaken {drivers[y - 1].Name} on lap {this.currentLap}.";
                                drivers[y].TotalTime -= 3;
                                drivers[y - 1].TotalTime += 3;
                            }
                        }
                        else if (enduranceHardTyreDriver && diffrence <= 3)
                        {
                            if (weather == "Rainy")
                            {
                                driversWhosLostTheRace.Add(drivers[y].Name, "Crashed");
                                drivers.RemoveAt(y);
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
                    string result = $"{winer.Name} wins the race for {winer.TotalTime:f3} seconds.";
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

        foreach (var f in driversWhosLostTheRace)
        {
            sb.AppendLine($"{count} {f.Key} {f.Value}");
            count++;
        }

        return sb.ToString();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[1];
    }

}

