using System;
using System.Collections.Generic;
using System.Text;


public class HammerHarvester : Harvester
{
    private const int increaseOrePersent = 2;
    private const int increaseEnergyPersent = 1;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        IncreasesEficiency();
    }

    private void IncreasesEficiency()
    {
        this.OreOutput += this.OreOutput * increaseOrePersent;
        this.EnergyRequirement += this.EnergyRequirement * increaseEnergyPersent;
    }
}

