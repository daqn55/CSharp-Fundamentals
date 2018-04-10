using System;
using System.Collections.Generic;
using System.Text;


public class Axe : Weapon
{
    private const int minDamage = 5;
    private const int maxDamage = 10;
    private const int sockets = 4;

    public Axe(string name)
        : base(minDamage, maxDamage, sockets, name)
    {
    }
}

