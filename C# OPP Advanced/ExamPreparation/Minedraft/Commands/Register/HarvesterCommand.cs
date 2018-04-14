using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HarvesterCommand : Command
{
    public HarvesterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        return this.HarvesterController.Register(this.Arguments);
    }
}
