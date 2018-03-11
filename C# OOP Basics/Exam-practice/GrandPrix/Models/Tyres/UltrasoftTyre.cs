using System;
using System.Collections.Generic;
using System.Text;


public class UltrasoftTyre : Tyre
{
    private const string NameOfUtrasoftTyre = "Ultrasoft";

    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    private double degradation;

    public override double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blow Tyre");
            }
            degradation = value;
        }
    }

    public override string Name => NameOfUtrasoftTyre;

    public override void ReduceDegradation()
    {
        var sum = this.Hardness + this.Grip;
        this.Degradation -= sum;
    }
}

