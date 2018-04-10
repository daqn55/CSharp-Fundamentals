using System;
using System.Collections.Generic;
using System.Text;


public class Ruby : Gem
{
    private const int str = 7;
    private const int agility = 2;
    private const int vitality = 5;

    public Ruby(Clarity clarity, Weapon weapon)
        : base(str, agility, vitality, clarity, weapon)
    {
    }
}

