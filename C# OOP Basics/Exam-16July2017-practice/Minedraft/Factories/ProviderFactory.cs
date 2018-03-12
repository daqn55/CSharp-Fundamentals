using System;
using System.Collections.Generic;
using System.Text;


public static class ProviderFactory
{

    public static Provider RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        if (type == "Solar")
        {
            SolarProvider solarProvider = new SolarProvider(id, energyOutput);
            return solarProvider;
        }
        else if (type == "Pressure")
        {
            PressureProvider pressureProvider = new PressureProvider(id, energyOutput);
            return pressureProvider;
        }
        else
        {
            throw new ArgumentException();
        }

    }
}

