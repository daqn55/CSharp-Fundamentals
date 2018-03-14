using System;
using System.Collections.Generic;
using System.Text;


public class ShowCar : Car
{
    protected ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        this.Stars = 0;
    }

    public int Stars { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"{this.Stars} *";
    }
}

