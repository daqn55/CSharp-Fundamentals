using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicles
{
    public Car(double fuelQuantity, double litersPerKm, double tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }
}

