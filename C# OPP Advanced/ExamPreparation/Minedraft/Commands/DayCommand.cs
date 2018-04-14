using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var energyProduced = this.ProviderController.Produce();
        var oreProduced = this.HarvesterController.Produce();

        var sb = new StringBuilder();

        sb.AppendLine(energyProduced);
        sb.Append(oreProduced);

        return sb.ToString().Trim();
    }
}

