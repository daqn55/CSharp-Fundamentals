using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DayCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
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
        var energyProduced = this.ProviderController.Produce();
        var oreProduced = this.HarvesterController.Produce();

        var sb = new StringBuilder();

        sb.AppendLine(energyProduced);
        sb.Append(oreProduced);

        return sb.ToString().TrimEnd();
    }
}

