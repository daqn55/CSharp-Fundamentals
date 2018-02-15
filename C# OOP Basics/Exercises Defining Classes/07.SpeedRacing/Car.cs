using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal fuelConsumption;
    private decimal distanceTraveled;

    public string Model
    {
        get { return  model; }
        set {  model = value; }
    }

    public decimal FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public decimal FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    public decimal DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public Car()
    {
        this.distanceTraveled = 0;
    }
    public Car(string model, decimal fuelAmount, decimal fuelConsumption,
        decimal distanceTraveled):this()
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.DistanceTraveled = distanceTraveled;
    }

    public decimal FuelLeft()
    {
        decimal fuelLeft = fuelAmount - (distanceTraveled * fuelConsumption);
        return fuelLeft;
    }
}

