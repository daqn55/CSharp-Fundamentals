using System;
using System.Collections.Generic;
using System.Text;


public abstract class Rarity
{
    public Rarity(int increasesDamage, Weapon weapon)
    {
        this.IncreasesDamage = increasesDamage;
        this.WeaponRarityChange(weapon);
    }

    public int IncreasesDamage { get; }

    private void WeaponRarityChange(Weapon weaponType)
    {
        weaponType.IncreasedDamage(this.IncreasesDamage);
    }
}

