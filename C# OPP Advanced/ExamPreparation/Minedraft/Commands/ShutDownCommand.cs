using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var result = string.Format(Constants.SystemShutdown, this.ProviderController.TotalEnergyProduced, this.HarvesterController.OreProduced);

        return result;
    }
}

