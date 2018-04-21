using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RepairCommand : Command
{
    [Inject]
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.ProviderController = providerController;
    }

    public IProviderController ProviderController
    {
        get { return providerController; }
        private set { providerController = value; }
    }

    public override string Execute()
    {
        var val = int.Parse(this.Arguments[0]);
        
        return this.ProviderController.Repair(val);
    }
}

