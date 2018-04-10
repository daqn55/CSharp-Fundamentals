using System;
using System.Collections.Generic;
using System.Text;


public abstract class Command
{
    protected List<Weapon> weapons;

    public Command(string[] data, List<Weapon> weapons)
    {
        this.weapons = weapons;
        this.Data = data;
    }

    protected string[] Data { get; set; }

    public abstract string Execute();
}

