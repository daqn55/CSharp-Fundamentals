using System;
using System.Collections.Generic;
using System.Text;


public class Vehicles : IVehicles
{
    public Vehicles(double fuelQuantity, double litersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
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

    public string VehicleRefueling(double fuel, string type, double keepFuel)
    {
        this.FuelQuantity += fuel * keepFuel;
        string result = $"{type}: {this.FuelQuantity:f2}";
        return result;
    }
}

