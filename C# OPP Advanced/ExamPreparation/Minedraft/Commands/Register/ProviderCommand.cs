using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProviderCommand : Command
{
    public ProviderCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.ProviderController = providerController;
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        return this.ProviderController.Register(this.Arguments);
    }
}

