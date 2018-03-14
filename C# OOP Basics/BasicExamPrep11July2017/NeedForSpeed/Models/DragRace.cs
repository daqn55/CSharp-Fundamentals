using System;
using System.Collections.Generic;
using System.Text;


public class DragRace : Race
{
    protected DragRace(int length, string route, int prizePool, List<Car> participants) 
        : base(length, route, prizePool, participants)
    {
    }
}

