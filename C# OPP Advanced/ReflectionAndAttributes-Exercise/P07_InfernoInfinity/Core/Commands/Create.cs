using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Create : Command
{
    public Create(string[] data, List<Weapon> weapons)
        : base(data, weapons)
    {
    }

    public override string Execute()
    {
        var rarity = this.Data[1].Split()[0];
        var weaponType = this.Data[1].Split()[1];
        var weaponName = this.Data[2];

        

        Assembly assembly = Assembly.GetCallingAssembly();
        Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

        object[] commandArgs = new object[] { weaponName };
        object instance = Activator.CreateInstance(type, commandArgs);

        Assembly rarityAssembly = Assembly.GetCallingAssembly();
        Type rarityType = rarityAssembly.GetTypes().FirstOrDefault(t => t.Name == rarity);
        object[] rarirtyCommandArgs = new object[] { (Weapon)instance };
        object rarityInstance = Activator.CreateInstance(rarityType, rarirtyCommandArgs);

        this.weapons.Add((Weapon)instance);
        return string.Empty;
    }
}

