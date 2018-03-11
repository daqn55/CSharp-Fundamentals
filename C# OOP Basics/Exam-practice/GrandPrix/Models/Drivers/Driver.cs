using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    private string name;
    private Car car;

    public Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double TotalTime { get; set; }

    public Car Car
    {
        get { return this.car; }
        set { this.car = value; }
    }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed()
    {
        double speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        return speed;
    }
}

