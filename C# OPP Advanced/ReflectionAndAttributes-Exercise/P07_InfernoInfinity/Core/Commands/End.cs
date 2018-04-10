using System;
using System.Collections.Generic;
using System.Text;


public class END : Command
{
    public END(string[] data, List<Weapon> weapons)
        : base(data, weapons)
    {
    }

    public override string Execute()
    {
        Environment.Exit(0);
        return null;
    }
}

