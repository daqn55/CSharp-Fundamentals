using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ShutdownCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController
    {
        get { return harvesterController; }
        private set { harvesterController = value; }
    }

    public IProviderController ProviderController
    {
        get { return providerController; }
        private set { providerController = value; }
    }

    public override string Execute()
    {
        var result = string.Format(Constants.SystemShutdown, this.ProviderController.TotalEnergyProduced, this.HarvesterController.OreProduced);

        return result;
    }
}

