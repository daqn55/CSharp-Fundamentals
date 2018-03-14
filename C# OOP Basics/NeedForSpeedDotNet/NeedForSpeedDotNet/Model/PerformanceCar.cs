using System;
using System.Collections.Generic;
using System.Text;


public class PerformanceCar : Car
{
    private const int horsePowerIncreases = 50;
    private const int suspensionDecreases = 25;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += this.Horsepower * horsePowerIncreases / 100;
        this.Suspension -= this.Suspension * suspensionDecreases / 100;
    }

    public List<string> AddOns { get; set; }

    public override string ToString()
    {
        if (this.AddOns.Count > 0)
        {
            return base.ToString() + "Add-ons: " + string.Join(", ", this.AddOns);
        }
        else
        {
            return base.ToString() + "Add-ons: None";
        }
    }
}

