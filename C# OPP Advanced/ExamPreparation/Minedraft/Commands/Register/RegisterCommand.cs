using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class RegisterCommand : Command
{
    [Inject]
    private IHarvesterController harvesterController;
    [Inject]
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
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
        var args = new List<string>(this.Arguments.Skip(1).ToList());

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == this.Arguments[0] + "Command");

        object[] constrArgs = new object[] { args, this.HarvesterController, this.ProviderController };
        object instance = Activator.CreateInstance(commandType, constrArgs);

        return commandType.GetMethod("Execute").Invoke(instance, null).ToString();
    }
}

