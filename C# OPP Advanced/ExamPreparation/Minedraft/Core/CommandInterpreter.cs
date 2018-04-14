﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter : ICommandInterpreter
{
    private DraftManager manager;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.manager = new DraftManager();
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }
    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        List<string> arguments = new List<string>(args.Skip(1));
        var command = args[0];

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == command + "Command");

        object[] constrArgs = new object[] { arguments, this.HarvesterController, this.ProviderController };

        object instance = Activator.CreateInstance(commandType, constrArgs);

        return commandType.GetMethod("Execute").Invoke(instance, null).ToString();

        //switch (command)
        //{
        //    case "Register":
        //        if (args[1] == "Harvester")
        //        {
        //            arguments = new List<string>(args.Skip(2).ToList());
        //            return manager.RegisterHarvester(arguments);
        //        }
        //        else if (args[1] == "Provider")
        //        {
        //            arguments = new List<string>(args.Skip(2).ToList());
        //            return manager.RegisterProvider(arguments);
        //        }
        //        break;
        //    case "Day":
        //        return manager.Day();
        //    case "Mode":
        //        arguments = new List<string>(args.Skip(1).ToList());
        //        return manager.Mode(arguments);
        //    case "Inspect":
        //        arguments = new List<string>(args.Skip(1).ToList());
        //        return manager.Inspect(arguments);
        //    case "Repair":
        //        arguments = new List<string>(args.Skip(1).ToList());
        //        return manager.Repair(arguments);
        //    default:
        //        return manager.ShutDown();
        //}
    }
}
