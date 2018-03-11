using System;

public class Car
{
    private const int maximuCapacityOfFuelTank = 160;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }


    private double fuelAmount;

    public double FuelAmount
    {
        get { return fuelAmount; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value > maximuCapacityOfFuelTank ? maximuCapacityOfFuelTank : value;
        }
    }

    public Tyre Tyre { get; protected set; }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void ReduceFuel(int length, double fuelConsumption)
    {
        this.FuelAmount = this.FuelAmount - (length * fuelConsumption);
    }

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }
}