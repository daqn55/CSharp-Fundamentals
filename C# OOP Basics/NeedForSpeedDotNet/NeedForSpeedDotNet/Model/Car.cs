using System;
using System.Collections.Generic;
using System.Text;


public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration,
        int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.Horsepower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; protected set; }
    public string Model { get; protected set; }
    public int YearOfProduction { get; protected set; }
    public int Horsepower { get; set; }
    public int Acceleration { get; protected set; }
    public int Suspension { get; set; }
    public int Durability { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        return sb.ToString();
    }
}

