using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public string Name { get; protected set; }

    public decimal TotalTime { get; set; }

    public Car Car { get; protected set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual decimal Speed()
    {
        decimal speed = (decimal)((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount);
        return speed;
    }
}

