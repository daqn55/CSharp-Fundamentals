public abstract class Ammunition : IAmmunition
{
    public Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        WearLevelOnCreation();
    }

    public string Name { get; private set; }

    public double Weight { get; private set; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }

    private void WearLevelOnCreation()
    {
        this.Weight *= 100;
    }
}