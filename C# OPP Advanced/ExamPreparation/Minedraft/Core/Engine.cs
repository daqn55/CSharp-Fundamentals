using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine().Split().ToList();

            writer.WriteLine(this.commandInterpreter.ProcessCommand(input));

            if (input[0] == "Shutdown")
            {
                Environment.Exit(0);
            }
        }
    }
}
