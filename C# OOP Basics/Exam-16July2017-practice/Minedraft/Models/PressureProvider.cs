using System;
using System.Collections.Generic;
using System.Text;


public class PressureProvider : Provider
{
    private const double specialEnergyIncreases = 1.5;

    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        IncreaseEnergy();
    }

    private void IncreaseEnergy()
    {
        this.EnergyOutput *= specialEnergyIncreases;
    }
}

