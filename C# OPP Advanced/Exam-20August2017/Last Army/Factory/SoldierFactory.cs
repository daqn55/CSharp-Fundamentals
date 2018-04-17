using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldiersFactory
{
    public Soldier CreateSoldier(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var age = int.Parse(args[2]);
        var experience = double.Parse(args[3]);
        var endurance = double.Parse(args[4]);

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type soldierType = assembly.GetTypes().FirstOrDefault(t => t.Name == type);
        var constructor = soldierType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        object[] soldierArgs = new object[] { name, age, experience, endurance };

        Soldier soldier = (Soldier)constructor[0].Invoke(soldierArgs);

        

        return soldier;
    }
}
