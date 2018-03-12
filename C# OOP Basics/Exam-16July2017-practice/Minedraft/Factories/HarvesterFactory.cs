using System;
using System.Collections.Generic;
using System.Text;


public static class HarvesterFactory
{
    public static Harvester RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            SonicHarvester sonicHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            return sonicHarvester;
        }
        else if (type == "Hammer")
        {
            HammerHarvester hammerHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
            return hammerHarvester;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

