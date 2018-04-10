using System;
using System.Collections.Generic;
using System.Text;


public class Uncommon : Rarity
{
    private const int increasesDamage = 2;

    public Uncommon(Weapon weapon) : base(increasesDamage, weapon)
    {
    }
}

