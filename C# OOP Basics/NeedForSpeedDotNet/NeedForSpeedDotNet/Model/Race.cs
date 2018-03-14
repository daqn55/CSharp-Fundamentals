using System;
using System.Collections.Generic;
using System.Text;


public abstract class Race
{
    protected Race(int length, string route, int prizePool, List<Car> participants)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>(participants);
    }

    public int Length { get; protected set; }
    public string Route { get; protected set; }
    public int PrizePool { get; protected set; }
    public List<Car> Participants { get; protected set; }
}

