using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Command : ICommand
{
    public Command(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public IList<string> Arguments { get; private set; }

    public abstract string Execute();
}

