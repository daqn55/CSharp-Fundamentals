using System;
using System.Collections.Generic;
using System.Text;


public class Emerald : Gem
{
    private const int str = 1;
    private const int agility = 4;
    private const int vitality = 9;

    public Emerald(Clarity clarity, Weapon weapon)
        : base(str, agility, vitality, clarity, weapon)
    {
    }
}

