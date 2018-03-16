using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Bender
{
    public Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; set; }
    public int Power { get; set; }
}

