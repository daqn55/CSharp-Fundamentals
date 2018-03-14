using System;
using System.Collections.Generic;
using System.Text;


public class DriftRace : Race
{
    protected DriftRace(int length, string route, int prizePool, List<Car> participants)
        : base(length, route, prizePool, participants)
    {
    }
}

