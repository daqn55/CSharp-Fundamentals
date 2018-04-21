using Microsoft.Extensions.DependencyInjection;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceProvider serviceProvider = ConfigureServices();
        IWriter writer = new Writer();
        IReader reader = new Reader();

        ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        IEnergyRepository energyRepository = new EnergyRepository();
        //services.AddSingleton<IEnergyRepository, EnergyRepository>();
        services.AddSingleton<IProviderController>(s => new ProviderController(energyRepository));
        services.AddSingleton<IHarvesterController>(s => new HarvesterController(energyRepository));

        IServiceProvider serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}