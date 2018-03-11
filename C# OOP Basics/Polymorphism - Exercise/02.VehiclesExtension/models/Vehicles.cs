using System;
using System.Collections.Generic;
using System.Text;


public class Vehicles : IVehicles
{
    public Vehicles(double fuelQuantity, double litersPerKm, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
        this.TankCapacity = tankCapacity;
    }

    private double fuelQuantity;

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }

    private double litersPerKm;

    public double LitersPerKm
    {
        get { return litersPerKm; }
        set { litersPerKm = value; }
    }

    private double tankCapacity;

    public double TankCapacity
    {
        get { return tankCapacity; }
        set
        {
            if (value < this.FuelQuantity)
            {
                this.FuelQuantity = 0;
            }
            tankCapacity = value;
        }
    }


    public string VehicleTravelled(double kilometersToTravel, string type, double extraConsumation)
    {
        double fuelConsumate = kilometersToTravel * (this.LitersPerKm + extraConsumation);
        if (fuelConsumate > this.FuelQuantity)
        {
            throw new ArgumentException($"{type} needs refueling");
        }
        else
        {
            this.FuelQuantity -= fuelConsumate;
        }

        string result = type + $" travelled {kilometersToTravel} km";
        return result;
    }

    public void VehicleRefueling(double fuel, string type, double keepFuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }
        else if (this.TankCapacity >= this.FuelQuantity + (fuel * keepFuel))
        {
            this.FuelQuantity += (fuel * keepFuel);
        }
        else
        {
            throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
        }
    }
}

