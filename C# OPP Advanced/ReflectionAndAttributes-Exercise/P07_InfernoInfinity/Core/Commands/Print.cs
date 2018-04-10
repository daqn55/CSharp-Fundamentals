using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Print : Command
{
    public Print(string[] data, List<Weapon> weapons)
        : base(data, weapons)
    {
    }

    public override string Execute()
    {
        var weaponName = this.Data[1];

        var weaponToPrint = this.weapons.FirstOrDefault(w => w.Name == weaponName);

        var sb = new StringBuilder();

        int sumOfStr = 0;
        int sumOfAgi = 0;
        int sumOfVitality = 0;
        if (weaponToPrint.Sockets.Any(x => x != null))
        {
            sumOfStr = weaponToPrint.Sockets.Where(x => x != null).Sum(s => s.Strength);
            sumOfAgi = weaponToPrint.Sockets.Where(x => x != null).Sum(s => s.Agility);
            sumOfVitality = weaponToPrint.Sockets.Where(x => x != null).Sum(s => s.Vitality);
        }

        sb.Append($"{weaponName}: {weaponToPrint.MinDamage}-{weaponToPrint.MaxDamage} Damage, " +
            $"+{sumOfStr} Strength, " +
            $"+{sumOfAgi} Agility, +{sumOfVitality} Vitality");

        return sb.ToString().TrimEnd();
    }
}

