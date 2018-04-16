public abstract class Harvester : IHarvester
{
    private const int InitialDurability = 1000;
    private double originOreOutput = 0;
    private double originEnergyReq = 0;

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

    public virtual double Durability { get; set; }

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
        return this.OreOutput;
    }

    public void ChangeMode(int persents)
    {
        if (this.EnergyRequirement > this.originEnergyReq)
        {
            this.originOreOutput = this.OreOutput;
            this.originEnergyReq = this.EnergyRequirement;
        }
        this.EnergyRequirement = this.originEnergyReq;
        this.OreOutput = this.originOreOutput;

        this.EnergyRequirement = (this.EnergyRequirement * persents) / 100;
        this.OreOutput = (this.OreOutput * persents) / 100;
    }
}