using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ModeCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController
    {
        get { return harvesterController; }
        private set { harvesterController = value; }
    }

    public override string Execute()
    {
        var mode = this.HarvesterController.ChangeMode(this.Arguments[0]);

        return mode;
    }
}

