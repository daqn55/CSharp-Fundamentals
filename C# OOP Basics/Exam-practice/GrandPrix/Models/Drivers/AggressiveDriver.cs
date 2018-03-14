using System;
using System.Collections.Generic;
using System.Text;


public class AggressiveDriver : Driver
{
    private const double FuelConsumption = 2.7;
    private const decimal speedMultiplierAggresiveDriver = 1.3M;

    public AggressiveDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }

    public override decimal Speed()
    {
        return base.Speed() * speedMultiplierAggresiveDriver;
    }
}

