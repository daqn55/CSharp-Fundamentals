using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProviderCommand : Command
{
    public ProviderCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        return this.ProviderController.Register(this.Arguments);
    }
}

