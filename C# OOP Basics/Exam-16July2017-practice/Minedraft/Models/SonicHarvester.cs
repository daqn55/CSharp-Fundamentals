using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        ReduceEnergy();
    }

    public int SonicFactor { get; private set; }

    private void ReduceEnergy()
    {
        this.EnergyRequirement /= this.SonicFactor;
    }
}

