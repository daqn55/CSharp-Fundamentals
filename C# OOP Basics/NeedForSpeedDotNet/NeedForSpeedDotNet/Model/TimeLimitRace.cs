using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, List<Car> participants, int goldTime)
        : base(length, route, prizePool, participants)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }
}

