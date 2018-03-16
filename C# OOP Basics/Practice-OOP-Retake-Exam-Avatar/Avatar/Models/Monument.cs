using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Monument
{
    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}

