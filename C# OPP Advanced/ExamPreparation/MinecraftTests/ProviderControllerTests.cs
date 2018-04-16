using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Class1
{
    [Test]
    public void ConstructorIsValid()
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        ProviderController providerController = new ProviderController(energyRepository);
    }

    public static string[][] RegisterCommandDataSource = new string[][]
    {
            new string[] { "Solar", "80", "80" },
            new string[] { "Pressure", "40", "100" },
            new string[] { "Standart", "30", "70" }
    };

    [TestCaseSource(nameof(RegisterCommandDataSource))]
    public void RegisterCommandInvalid(string[] value)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        ProviderController providerController = new ProviderController(energyRepository);

        IList<string> args = new List<string>(value);

        //Assert.That(providerController.Register(args), Is.EqualTo($"Successfully registered {value[0]}Provider"));
    }


    [Test]
    [TestCase(20D)]
    [TestCase(0D)]
    [TestCase(50D)]
    [TestCase(10D)]
    public void RepairCommandValid(double value)
    {
        IEnergyRepository energyRepository = new EnergyRepository();
        ProviderController providerController = new ProviderController(energyRepository);

        var result = providerController.Repair(value);
        Assert.IsTrue(result.StartsWith("Providers are repaired by"));
        //Assert.That(result, Is.EqualTo($"Providers are repaired by { value }"));
    }
}

