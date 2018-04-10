using System;
using System.Collections.Generic;
using System.Text;


public class Amethyst : Gem
{
    private const int str = 2;
    private const int agility = 8;
    private const int vitality = 4;

    public Amethyst(Clarity clarity, Weapon weapon)
        : base(str, agility, vitality, clarity, weapon)
    {
    }
}

