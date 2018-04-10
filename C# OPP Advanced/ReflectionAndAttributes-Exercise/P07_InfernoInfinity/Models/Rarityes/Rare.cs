using System;
using System.Collections.Generic;
using System.Text;


public class Rare : Rarity
{
    private const int increasesDamage = 3;

    public Rare(Weapon weapon)
        : base(increasesDamage, weapon)
    {
    }
}

