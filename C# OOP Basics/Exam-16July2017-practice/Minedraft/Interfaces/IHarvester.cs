using System;
using System.Collections.Generic;
using System.Text;


public interface IHarvester
{
    string Id { get; }
    double OreOutput { get; }
    double EnergyRequirement { get; }
    void ChangeMode(double consumeEnergyPercents, double produceOrePercent);
}

