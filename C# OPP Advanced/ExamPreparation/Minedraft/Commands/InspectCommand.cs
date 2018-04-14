using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);
        var sb = new StringBuilder();
        bool haveId = false;

        var providerController = (ProviderController)this.ProviderController;
        if (providerController.Entities.Any(x => x.ID == id))
        {
            var provider = providerController.Entities.First(x => x.ID == id);
            sb.AppendLine(provider.GetType().Name);
            sb.AppendLine($"Durability: {provider.Durability}");
            haveId = true;
        }

        var harvesterController = (HarvesterController)this.HarvesterController;
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
}

