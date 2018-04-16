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
        var result = string.Empty;
        bool haveId = false;

        var providerController = (ProviderController)this.ProviderController;
        if (providerController.Entities.Any(x => x.ID == id))
        {
            var provider = providerController.Entities.First(x => x.ID == id);

            result = string.Format(Constants.EntityFound, provider.GetType().Name, provider.Durability);
            haveId = true;
        }

        var harvesterController = (HarvesterController)this.HarvesterController;
        if (harvesterController.Entities.Any(x => x.ID == id))
        {
            var harvester = harvesterController.Entities.First(x => x.ID == id);
            result = string.Format(Constants.EntityFound, harvester.GetType().Name, harvester.Durability);
            haveId = true;
        }

        if (!haveId || string.IsNullOrWhiteSpace(result))
        {
            result = string.Format(Constants.NoEntity, id);
        }

        return result;
    }
}

