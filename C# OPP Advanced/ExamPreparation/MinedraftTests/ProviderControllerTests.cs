using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void RegisterProviderIsValid()
    {
        IList<string> provider1 = new List<string>()
        {
            "Pressure", "1", "100"
        };

        IList<string> provider2 = new List<string>()
        {
            "Pressure", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        var controller = (ProviderController)this.providerController;
        int count = controller.Entities.Count;

        Assert.That(count, Is.EqualTo(2));
    }

    [Test]
    public void ProduceProviderIsValid()
    {
        IList<string> provider1 = new List<string>()
        {
            "Pressure", "1", "100"
        };

        IList<string> provider2 = new List<string>()
        {
            "Pressure", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        this.providerController.Produce();
        this.providerController.Produce();

        var totalEnergy = this.providerController.TotalEnergyProduced;
        Assert.That(totalEnergy, Is.EqualTo(800d));
    }

    [Test]
    public void ReapirProviderIsValid()
    {
        IList<string> provider1 = new List<string>()
        {
            "Pressure", "1", "100"
        };

        IList<string> provider2 = new List<string>()
        {
            "Pressure", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        this.providerController.Repair(100);

        var controller = (ProviderController)this.providerController;

        Assert.That(controller.Entities.First().Durability, Is.EqualTo(800d));
    }

    [Test]
    public void BrokeProviderIsValid()
    {
        IList<string> provider1 = new List<string>()
        {
            "Pressure", "1", "100"
        };

        IList<string> provider2 = new List<string>()
        {
            "Pressure", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        var controller = (ProviderController)this.providerController;
        int count = controller.Entities.Count;

        Assert.That(count, Is.EqualTo(0));
    }
}

