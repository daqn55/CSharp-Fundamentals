using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;

    public Engine()
    {
        this.commandInterpreter = new CommandInterpreter();
    }
    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine().Split().ToList();

            Console.WriteLine(this.commandInterpreter.ProcessCommand(input));

            if (input[0] == "Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}
