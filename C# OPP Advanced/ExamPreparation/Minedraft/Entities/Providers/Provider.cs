public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= 100;

        if (this.Durability < 0)
        {
            throw new System.Exception($"{this.GetType().Name} broked!");
        }

    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}