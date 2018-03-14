using System;
using System.Collections.Generic;
using System.Text;


public static class DriverFactory
{
    public static Driver CreateDriver(List<string> arguments)
    {
        string typeOfDriver = arguments[0];
        var name = arguments[1];
        var hp = int.Parse(arguments[2]);
        var fuelAmount = double.Parse(arguments[3]);

        Car car = new Car(hp, fuelAmount, TyreFactory.CreateType(arguments));

        if (typeOfDriver == "Aggressive")
        {
            AggressiveDriver aggressiveDriver =  new AggressiveDriver(name, car);
            return aggressiveDriver;
        }
        else if (typeOfDriver == "Endurance")
        {
            EnduranceDriver enduranceDriver =  new EnduranceDriver(name, car);
            return enduranceDriver;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}

