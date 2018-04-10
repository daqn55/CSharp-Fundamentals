using System;
using System.Collections.Generic;
using System.Text;


public class Sword : Weapon
{
    private const int minDamage = 4;
    private const int maxDamage = 6;
    private const int sockets = 3;

    public Sword(string name)
        : base(minDamage, maxDamage, sockets, name)
    {
    }
}

