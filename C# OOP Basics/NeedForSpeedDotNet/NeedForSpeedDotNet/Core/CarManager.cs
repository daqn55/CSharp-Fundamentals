using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.garage = new Garage();
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        switch (type)
        {
            case "Performance":
                PerformanceCar performanceCar = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, performanceCar);
                break;
            case "Show":
                ShowCar showCar = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                cars.Add(id, showCar);
                break;
        }
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        switch (type)
        {
            case "Casual":
                CasualRace casualRace = new CasualRace(length, route, prizePool, new List<Car>());
                races.Add(id, casualRace);
                break;
            case "Drag":
                DragRace dragRace = new DragRace(length, route, prizePool, new List<Car>());
                races.Add(id, dragRace);
                break;
            case "Drift":
                DriftRace driftRace = new DriftRace(length, route, prizePool, new List<Car>());
                races.Add(id, driftRace);
                break;
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int extraParameter)
    {
        switch (type)
        {
            case "TimeLimit":
                TimeLimitRace timeLimitRace = new TimeLimitRace(length, route, prizePool, new List<Car>(), extraParameter);
                races.Add(id, timeLimitRace);
                break;
            case "Circuit":
                CircuitRace circuitRace = new CircuitRace(length, route, prizePool, new List<Car>(), extraParameter);
                races.Add(id, circuitRace);
                break;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (!garage.ParkedCars.Any(x => x.Key == carId))
        {
            if (races[raceId].GetType().Name == "TimeLimitRace")
            {
                if (races[raceId].Participants.Count < 1)
                {
                    races[raceId].Participants.Add(cars[carId]);
                }
            }
            else if (races[raceId].GetType().Name == "CircuitRace")
            {
                var cLap = (CircuitRace)races[raceId];
                for (int i = 0; i < cLap.Laps; i++)
                {
                    cars[carId].Durability -= races[raceId].Length * races[raceId].Length;
                }
                races[raceId].Participants.Add(cars[carId]);
            }
            else
            {
                races[raceId].Participants.Add(cars[carId]);
            }
        }
    }

    public string Start(int id)
    {
        Dictionary<Car, int> participants = new Dictionary<Car, int>();
        if (races[id].Participants.Count > 0)
        {
            string specialRace = string.Empty;
            foreach (var p in races[id].Participants)
            {
                int pp = 0;
                switch (races[id].GetType().Name)
                {
                    case "CasualRace":
                        pp = (p.Horsepower / p.Acceleration) + (p.Suspension + p.Durability);
                        participants.Add(p, pp);
                        break;
                    case "DragRace":
                        pp = p.Horsepower / p.Acceleration;
                        participants.Add(p, pp);
                        break;
                    case "DriftRace":
                        pp = p.Suspension + p.Durability;
                        participants.Add(p, pp);
                        break;
                    case "TimeLimitRace":
                        pp = races[id].Length * ((p.Horsepower / 100) * p.Acceleration);
                        participants.Add(p, pp);
                        specialRace = "TimeLimitRace";
                        break;
                    case "CircuitRace":
                        pp = (p.Horsepower / p.Acceleration) + (p.Suspension + p.Durability);
                        participants.Add(p, pp);
                        specialRace = "CircuitRace";
                        break;
                }
            }

            var sb = new StringBuilder();
            if (races[id].GetType().Name == "CircuitRace")
            {
                var cirRace = (CircuitRace)races[id];
                sb.AppendLine($"{races[id].Route} - {races[id].Length * cirRace.Laps}");
            }
            else
            {
                sb.AppendLine($"{races[id].Route} - {races[id].Length}");
            }
            int count = 0;
            int moneyPercents = 50;
            foreach (var p in participants.OrderByDescending(x => x.Value))
            {
                int money = 0;
                count++;
                if (string.IsNullOrEmpty(specialRace))
                {
                    switch (count)
                    {
                        case 2: moneyPercents = 30; break;
                        case 3: moneyPercents = 20; break;
                    }
                    money = races[id].PrizePool * moneyPercents / 100;
                    sb.AppendLine($"{count}. {p.Key.Brand} {p.Key.Model} {p.Value}PP - ${money}");
                    if (count == 3)
                    {
                        break;
                    }
                }
                else
                {
                    bool breakRace = false;
                    switch (specialRace)
                    {
                        case "TimeLimitRace":
                            var timeRace = (TimeLimitRace)races[id];
                            string earnedTime = "Gold";
                            if (p.Value <= timeRace.GoldTime)
                            {
                                moneyPercents = 100;
                            }
                            else if (p.Value <= timeRace.GoldTime + 15)
                            {
                                moneyPercents = 50;
                                earnedTime = "Silver";
                            }
                            else if (p.Value > timeRace.GoldTime + 15)
                            {
                                moneyPercents = 30;
                                earnedTime = "Bronze";
                            }
                            money = races[id].PrizePool * moneyPercents / 100;
                            sb.AppendLine($"{p.Key.Brand} {p.Key.Model} - {p.Value} s.");
                            sb.AppendLine($"{earnedTime} Time, ${money}.");
                            if (count == 1)
                            {
                                breakRace = true;
                            }
                            break;
                        case "CircuitRace":
                            switch (count)
                            {
                                case 1: moneyPercents = 40; break;
                                case 2: moneyPercents = 30; break;
                                case 3: moneyPercents = 20; break;
                                case 4: moneyPercents = 10; break;
                            }

                            money = races[id].PrizePool * moneyPercents / 100;
                            sb.AppendLine($"{count}. {p.Key.Brand} {p.Key.Model} {p.Value}PP - ${money}");
                            if (count == 4)
                            {
                                breakRace = true;
                            }
                            break;
                    }
                    if (breakRace)
                    {
                        break;
                    }
                }

            }
            races.Remove(id);
            return sb.ToString().TrimEnd();
        }
        else
        {
            return $"Cannot start the race with zero participants.";
        }
    }

    public void Park(int id)
    {
        if (!races.Any(x => x.Value.Participants.Any(p => p.Model == cars[id].Model && p.Brand == cars[id].Brand)))
        {
            garage.ParkedCars.Add(id, cars[id]);
        }
    }

    public void Unpark(int id)
    {
        cars[id] = garage.ParkedCars[id];
        garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        Dictionary<int, Car> garageMem = new Dictionary<int, Car>();
        foreach (var c in garage.ParkedCars)
        {
            switch (c.Value.GetType().Name)
            {
                case "PerformanceCar":
                    var r = (PerformanceCar)c.Value;
                    r.AddOns.Add(addOn);
                    r.Horsepower += tuneIndex;
                    r.Suspension += tuneIndex / 2;
                    garageMem.Add(c.Key, r);
                    break;
                case "ShowCar":
                    var m = (ShowCar)c.Value;
                    m.Stars += tuneIndex;
                    m.Horsepower += tuneIndex;
                    m.Suspension += tuneIndex / 2;
                    garageMem.Add(c.Key, m);
                    break;
            }
        }
        garage.ParkedCars = garageMem;
    }
}


