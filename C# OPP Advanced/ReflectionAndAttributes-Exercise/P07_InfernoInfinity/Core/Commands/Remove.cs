using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Remove : Command
{
    public Remove(string[] data, List<Weapon> weapons)
        : base(data, weapons)
    {
    }

    public override string Execute()
    {
        var weaponName = this.Data[1];
        var socketIndex = int.Parse(this.Data[2]);

        var weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);
        weapon.Sockets[socketIndex].WeaponDecreasesDamage(weapon);
        weapon.RemoveGemFromSocket(socketIndex);

        return string.Empty;
    }
}

