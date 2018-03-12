using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{
    private List<Provider> providers;
    private List<Harvester> harvesters;
    private const string exceptionHarvesterRegister = "Harvester is not registered, because of it's ";
    private const string exceptionProvidersRegister = "Provider is not registered, because of it's ";
    private string mode;

    public DraftManager()
    {
        this.providers = new List<Provider>();
        this.harvesters = new List<Harvester>();
        this.TotalStoredEnergy = 0;
        this.TotalMinedOre = 0;
        this.mode = "Full";
    }

    public double TotalStoredEnergy { get; private set; }
    public double TotalMinedOre { get; private set; }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        try
        {
            this.harvesters.Add(HarvesterFactory.RegisterHarvester(arguments));
        }
        catch (ArgumentException a)
        {
            return exceptionHarvesterRegister + a.Message;
        }
        string successfullRegister = $"Successfully registered {type} Harvester - {id}";
        return successfullRegister;
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        try
        {
            providers.Add(ProviderFactory.RegisterProvider(arguments));
        }
        catch (ArgumentException a)
        {
            return exceptionProvidersRegister + a.Message;
        }
        string successfullRegister = $"Successfully registered {type} Provider - {id}";
        return successfullRegister;
    }

    public string Day()
    {
        double totalEnergyForTheDay = 0;
        foreach (var p in providers)
        {
            totalEnergyForTheDay += p.EnergyOutput;
            this.TotalStoredEnergy += p.EnergyOutput;
        }

        double totalOreForTheDay = 0;
        if (this.TotalStoredEnergy >= harvesters.Sum(h => h.EnergyRequirement))
        {
            foreach (var h in harvesters)
            {
                if (this.mode == "Full")
                {
                    totalOreForTheDay += h.OreOutput;
                    this.TotalMinedOre += h.OreOutput;
                    this.TotalStoredEnergy -= h.EnergyRequirement;
                }
                else if (this.mode == "Half")
                {
                    totalOreForTheDay += h.OreOutput * 0.5;
                    this.TotalMinedOre += h.OreOutput * 0.5;
                    this.TotalStoredEnergy -= h.EnergyRequirement * 0.6;
                }
                
            }
        }
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {totalEnergyForTheDay}")
            .Append($"Plumbus Ore Mined: {totalOreForTheDay}");
        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        switch (mode)
        {
            case "Full":
                this.mode = mode;
                break;
            case "Half":
                this.mode = mode;
                break;
            case "Energy":
                this.mode = mode;
                break;
        }
        string result = $"Successfully changed working mode to {arguments[0]} Mode";
        return result;
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        var sb = new StringBuilder();
        if (providers.Any(x => x.Id == id))
        {
            var provider = providers.Find(x => x.Id == id);
            if (provider.GetType().Name == "SolarProvider")
            {
                sb.AppendLine($"Solar Provider - {id}");
            }
            else
            {
                sb.AppendLine($"Pressure Provider - {id}");
            }
            sb.Append($"Energy Output: {provider.EnergyOutput}");
            return sb.ToString();
        }
        else if(harvesters.Any(x => x.Id == id))
        {
            var harvester = harvesters.Find(x => x.Id == id);
            if (harvester.GetType().Name == "SonicHarvester")
            {
                sb.AppendLine($"Sonic Harvester - {id}");
            }
            else if (harvester.GetType().Name == "HammerHarvester")
            {
                sb.AppendLine($"Hammer Harvester - {id}");
            }
            sb.AppendLine($"Ore Output: {harvester.OreOutput}");
            sb.Append($"Energy Requirement: {harvester.EnergyRequirement}");
            return sb.ToString();
        }
        else
        {
            sb.Append($"No element found with id - {id}");
            return sb.ToString();
        }
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.TotalStoredEnergy}")
            .Append($"Total Mined Plumbus Ore: {this.TotalMinedOre}");
        return sb.ToString();
    }

}

