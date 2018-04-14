public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;

    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public virtual double Durability { get; protected set; }

    public void Broke()
    {
        if (this.Durability < 0)
        {
            throw new System.Exception($"{this.GetType().Name} broked!");
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public void ChangeMode(int persents)
    {
        this.EnergyRequirement = (this.EnergyRequirement * persents) / 100;
        this.OreOutput = (this.OreOutput * persents) / 100;
    }

    public void LoseDurability(int durabilityToLose)
    {
        this.Durability -= durabilityToLose;
    }
}