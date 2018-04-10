using System;
using System.Collections.Generic;
using System.Text;


public abstract class Gem
{
    private const int minDmgStrAdd = 2;
    private const int maxDmgStrAdd = 3;
    private const int minDmgAgiAdd = 1;
    private const int maxDmgAgiAdd = 4;

    public Gem(int str, int agility, int vitality, Clarity clarity, Weapon weapon)
    {
        this.Strength = str;
        this.Agility = agility;
        this.Vitality = vitality;
        DamageIncreasesByClarity(clarity);
    }

    public int Strength { get; private set; }
    public int Agility { get; private set; }
    public int Vitality { get; private set; }

    private void DamageIncreasesByClarity(Clarity clarity)
    {
        this.Strength += clarity.IncreasesDamage;
        this.Agility += clarity.IncreasesDamage;
        this.Vitality += clarity.IncreasesDamage;
    }

    public void WeaponIncreasesDamageDependOfGemType(Weapon weapon)
    {
        weapon.IncreasesDamageByGemStrength(this.Strength * minDmgStrAdd, this.Strength * maxDmgStrAdd);
        weapon.IncreasesDamageByGemAgility(this.Agility * minDmgAgiAdd, this.Agility * maxDmgAgiAdd);
    }

    public void WeaponDecreasesDamage(Weapon weapon)
    {
        weapon.DecreasesDamageStr(this.Strength * minDmgStrAdd, this.Strength * maxDmgStrAdd);
        weapon.DecreasesDamageAgi(this.Agility * minDmgAgiAdd, this.Agility * maxDmgAgiAdd);
    }
}

