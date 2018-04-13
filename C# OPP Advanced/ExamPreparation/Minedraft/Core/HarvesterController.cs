using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HarvesterController : IHarvesterController
{
    private IHarvesterFactory factory;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
        this.harvesters = new List<IHarvester>();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        int persents = 100;
        switch (mode)
        {
            case "Energy":
                persents = 20;
                break;
            case "Half":
                persents = 50;
                break;
        }

        foreach (var h in this.harvesters)
        {
            var harvester = (Harvester)h;
            harvester.ChangeMode(persents);
            harvester.LoseDurability(100);
        }

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception )
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        double energyNeeded = this.harvesters.Select(x => x.EnergyRequirement).Sum();

        double oreProducedByTheDay = 0;
        if (this.energyRepository.TakeEnergy(energyNeeded))
        {
            oreProducedByTheDay = this.harvesters.Select(n => n.Produce()).Sum();
            this.OreProduced += oreProducedByTheDay;
        }

        return string.Format(Constants.OreOutputToday, oreProducedByTheDay);
    }

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
}

