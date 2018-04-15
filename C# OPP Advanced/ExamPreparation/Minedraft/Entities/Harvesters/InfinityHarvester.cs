﻿using System;

[RefreshEntities]
public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    //public override double Durability
    //{
    //    get => this.durability;
    //    set => this.durability = Math.Max(0, value);
    //}

    public void RestoreDurability()
    {
        this.Durability = 1000;
    }
}