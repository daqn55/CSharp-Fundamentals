using System;
using System.Collections.Generic;
using System.Text;


public class Knife : Weapon
{
    private const int minDamage = 3;
    private const int maxDamage = 4;
    private const int sockets = 2;

    public Knife(string name)
        : base(minDamage, maxDamage, sockets, name)
    {
    }
}

