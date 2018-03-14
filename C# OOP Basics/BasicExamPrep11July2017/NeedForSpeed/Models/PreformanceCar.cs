using System;
using System.Collections.Generic;
using System.Text;


public class PreformanceCar : Car
{
    private const int horsePowerIncreases = 50;
    private const int suspensionDecreases = 25;

    protected PreformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.AddOns = new List<string>();
        this.Horsepower += this.Horsepower * horsePowerIncreases / 100;
        this.Suspension -= this.Suspension * suspensionDecreases / 100;
    }

    public List<string> AddOns { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("Add-ons: ")
            .AppendJoin(", ", this.AddOns);
        return base.ToString() +  sb.ToString();
    }
}

