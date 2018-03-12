using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : Minedraft, IProviders
{
    private const int isNotZero = 0;
    private const int lessThanTenTousant = 10000;
    private const string exceptionEnergy = "EnergyOutput";

    public Provider(string id, double energyOutput) : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < isNotZero || value >= lessThanTenTousant)
            {
                throw new ArgumentException(exceptionEnergy);
            }
            energyOutput = value;
        }

    }
}


