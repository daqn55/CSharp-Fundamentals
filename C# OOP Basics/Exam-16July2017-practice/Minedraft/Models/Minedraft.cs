using System;
using System.Collections.Generic;
using System.Text;

public abstract class Minedraft
{
    protected Minedraft(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }
}

