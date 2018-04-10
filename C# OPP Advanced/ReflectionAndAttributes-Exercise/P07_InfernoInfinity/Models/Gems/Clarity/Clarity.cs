using System;
using System.Collections.Generic;
using System.Text;


public abstract class Clarity
{
    public Clarity(int increasesDmg)
    {
        this.IncreasesDamage = increasesDmg;
    }

    public int IncreasesDamage { get; }

}

