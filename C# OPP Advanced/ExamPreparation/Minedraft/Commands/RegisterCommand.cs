using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var args = new List<string>(this.Arguments.Skip(1).ToList());
        if (this.Arguments[0] == "Harvester")
        {
            return this.HarvesterController.Register(args);
        }
        else if(this.Arguments[0] == "Provider")
        {
            return this.ProviderController.Register(args);
        }

        throw new Exception();
    }
}

