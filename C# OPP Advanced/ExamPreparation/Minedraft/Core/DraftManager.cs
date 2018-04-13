using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private IEnergyRepository energyRepository;
    private HarvesterController harvesterController;
    private ProviderController providerController;

    public DraftManager()
    {
        this.energyRepository = new EnergyRepository();
        this.harvesterController = new HarvesterController(energyRepository);
        this.providerController = new ProviderController(energyRepository);
    }

    public string RegisterHarvester(List<string> arguments)
    {
        return harvesterController.Register(arguments);
    }

    public string RegisterProvider(List<string> arguments)
    {
        return providerController.Register(arguments);
    }

    public string Day()
    {
        var energyProduced = providerController.Produce();
        var oreProduced = harvesterController.Produce();
        
        var sb = new StringBuilder();

        sb.AppendLine(energyProduced);
        sb.Append(oreProduced);

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var mode = harvesterController.ChangeMode(arguments[0]);

        return mode;
    }

    public string Inspect(List<string> arguments)
    {
        var id = int.Parse(arguments[0]);
        var sb = new StringBuilder();
        bool haveId = false;
        if (providerController.Entities.Any(x => x.ID == id))
        {
            var provider = providerController.Entities.First(x => x.ID == id);
            sb.AppendLine(provider.GetType().Name);
            sb.AppendLine($"Durability: {provider.Durability}");
            haveId = true;
        }
        if (harvesterController.Entities.Any(x => x.ID == id))
        {
            var harvester = harvesterController.Entities.First(x => x.ID == id);
            sb.AppendLine(harvester.GetType().Name);
            sb.AppendLine($"Durability: {harvester.Durability}");
            haveId = true;
        }
        if (!haveId || string.IsNullOrWhiteSpace(sb.ToString()))
        {
            sb.AppendLine($"No entity found with id - {id}");
        }

        return sb.ToString().Trim();
    }

    public string Repair(List<string> arguments)
    {
        var val = int.Parse(arguments[0]);
        return providerController.Repair(val);
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Produced: {providerController.TotalEnergyProduced}");
        sb.Append($"Total Mined Plumbus Ore: {harvesterController.OreProduced}");

        return sb.ToString();
    }

}
