using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IEnergyRepository energyRepository;
    private IReader reader;
    private IWriter writer;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
        this.energyRepository = new EnergyRepository();
        this.harvesterController = new HarvesterController(this.energyRepository);
        this.providerController = new ProviderController(this.energyRepository);
        this.commandInterpreter = new CommandInterpreter(this.harvesterController, this.providerController);
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
