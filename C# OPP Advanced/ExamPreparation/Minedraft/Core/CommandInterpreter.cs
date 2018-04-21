using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.ServiceProvider = serviceProvider;
    }
    public IServiceProvider ServiceProvider { get; }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        List<string> arguments = new List<string>(args.Skip(1));
        var command = args[0];

        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == command + "Command");

        if (commandType == null)
        {
            throw new ArgumentException("Command can't be null");
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new ArgumentException("Invalid command");
        }

        FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

        object[] injectArgs = fieldsToInject
            .Select(f => this.ServiceProvider.GetService(f.FieldType)).ToArray();

        object[] constrArgs = new object[] { arguments }.Concat(injectArgs).ToArray();

        object instance = Activator.CreateInstance(commandType, constrArgs);

        return commandType.GetMethod("Execute").Invoke(instance, null).ToString();
    }
}

