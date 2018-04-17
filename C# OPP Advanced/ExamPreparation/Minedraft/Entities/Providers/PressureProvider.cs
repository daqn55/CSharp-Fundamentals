using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PressureProvider : Provider
{
    private const int DurabilityLoss = 300;
    private const int EnergyRequirementMultyplier = 2;

    public PressureProvider(int id, double energyOutput) : base(id, energyOutput)
    {
        this.EnergyOutput *= EnergyRequirementMultyplier;
        this.Durability -= DurabilityLoss;
    }


}

