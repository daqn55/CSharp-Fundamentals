using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, List<Car> participants, int laps)
        : base(length, route, prizePool, participants)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }
}

