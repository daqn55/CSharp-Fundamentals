using System;
using System.Collections.Generic;
using System.Text;


public class Common : Rarity
{
    private const int increasesDamage = 1;

    public Common(Weapon weapon) : base(increasesDamage, weapon)
    {
    }
}

