using System;
using System.Collections.Generic;
using System.Text;


public class AggressiveDriver : Driver
{
    private const double FuelConsumption = 2.7;
    private const double speedMultiplierAggresiveDriver = 1.3;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }

    public override double Speed()
    {
        return base.Speed() * speedMultiplierAggresiveDriver;
    }
}

