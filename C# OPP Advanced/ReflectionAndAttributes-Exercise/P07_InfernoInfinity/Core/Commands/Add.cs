using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Add : Command
{
    public Add(string[] data, List<Weapon> weapons) 
        : base(data, weapons)
    {
    }

    public override string Execute()
    {
        var weaponName = this.Data[1];
        var socketIndex = int.Parse(this.Data[2]);
        var clarityOfGem = this.Data[3].Split()[0];
        var gem = this.Data[3].Split()[1];

        Assembly clarityAssembly = Assembly.GetCallingAssembly();
        Type clarityType = clarityAssembly.GetTypes().FirstOrDefault(t => t.Name == clarityOfGem);
        object clarityInstance = Activator.CreateInstance(clarityType, null);

        Assembly gemAssembly = Assembly.GetCallingAssembly();
        Type gemType = gemAssembly.GetTypes().FirstOrDefault(t => t.Name == gem);
        object[] gemCommandArgs = new object[] { (Clarity)clarityInstance, this.weapons.FirstOrDefault(w => w.Name == weaponName) };
        object gemInstance = Activator.CreateInstance(gemType, gemCommandArgs);

        var weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);
        weapon.AddGemToSocket((Gem)gemInstance, socketIndex);

        return string.Empty;
    }
}

