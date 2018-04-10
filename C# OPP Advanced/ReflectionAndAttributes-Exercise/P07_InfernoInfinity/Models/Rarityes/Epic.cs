using System;
using System.Collections.Generic;
using System.Text;


public class Epic : Rarity
{
    private const int increasesDamage = 5;

    public Epic(Weapon weapon)
        : base(increasesDamage, weapon)
    {
    }
}

