using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IEnergyRepository energyRepository;

    public Engine()
    {
        this.energyRepository = new EnergyRepository();
        this.harvesterController = new HarvesterController(this.energyRepository);
        this.providerController = new ProviderController(this.energyRepository);
        this.commandInterpreter = new CommandInterpreter(this.harvesterController, this.providerController);
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
