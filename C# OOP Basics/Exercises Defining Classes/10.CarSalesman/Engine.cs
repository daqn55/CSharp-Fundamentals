using System;
using System.Collections.Generic;
using System.Text;


public class Engine
{
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private int power;

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    private string displacements;

    public string Displacements
    {
        get { return displacements; }
        set { displacements = value; }
    }

    private string efficiency;

    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }

    public Engine()
    {
        this.Displacements = "n/a";
        this.Efficiency = "n/a";
    }
    public Engine(string model, int power, string displacements, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacements = displacements;
        this.Efficiency = efficiency;
    }
}

