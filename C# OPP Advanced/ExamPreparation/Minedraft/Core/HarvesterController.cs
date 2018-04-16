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

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var h in this.harvesters)
        {
            try
            {
                var harvester = (Harvester)h;
                harvester.ChangeMode(persents);
                //if (!(h is InfinityHarvester))
                //{
                    h.Broke();
                //}
            }
            catch (Exception)
            {
                reminder.Add(h);
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

        foreach (var h in this.harvesters)
        {
            var hasAttribute = Attribute.IsDefined(h.GetType(), typeof(RefreshEntitiesAttribute));
            if (hasAttribute)
            {
                var infinityHarvester = (Harvester)h;
                infinityHarvester.Durability = 1000;
            }
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

