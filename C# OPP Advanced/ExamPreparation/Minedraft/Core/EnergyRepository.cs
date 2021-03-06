﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnergyRepository : IEnergyRepository
{
    public double EnergyStored { get; private set; }

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        if (energyNeeded > this.EnergyStored)
        {
            return false;
        }
        else
        {
            this.EnergyStored -= energyNeeded;
            return true;
        }
    }
}

