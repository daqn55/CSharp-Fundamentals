using System;
using System.Collections.Generic;
using System.Text;


public abstract class Harvester : Minedraft, IHarvester
{
    private const int isNotNegative = 0;
    private const int isNotOverBigNum = 20000;
    private const string exceptionOre = "OreOutput";
    private const string exceptionEnergy = "EnergyRequirement";

    public Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    private double oreOutput;
    private double energyRequirement;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < isNotNegative)
            {
                throw new ArgumentException(exceptionOre);
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value > isNotOverBigNum)
            {
                throw new ArgumentException(exceptionEnergy);
            }
            energyRequirement = value;
        }
    }

    public void ChangeMode(double consumeEnergyPercents, double produceOrePercent)
    {
        this.EnergyRequirement *= consumeEnergyPercents;
        this.OreOutput *= produceOrePercent;
    }
}


