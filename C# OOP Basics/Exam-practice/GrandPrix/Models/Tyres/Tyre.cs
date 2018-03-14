using System;

public abstract class Tyre
{
    private const int InitialValueDegradation = 100;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = InitialValueDegradation;
    }

    public abstract string Name { get; }

    public double Hardness { get; }


    private double degradation;

    public virtual double Degradation
    {
        get { return degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blow Tyre");
            }
            degradation = value;
        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }

}