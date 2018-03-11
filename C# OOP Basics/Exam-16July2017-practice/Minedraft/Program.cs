using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        DraftManager draftManager = new DraftManager();
        while (true)
        {
            List<string> commandsArgs = Console.ReadLine().Split().ToList();

            switch (commandsArgs[0])
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(commandsArgs));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(commandsArgs));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(draftManager.Mode(commandsArgs));
                    break;
                case "Check":
                    Console.WriteLine(draftManager.Check(commandsArgs));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    break;
            }

            if (commandsArgs[0] == "Shutdown")
            {
                break;
            }
        }
    }
}

