using System;
using System.Collections.Generic;
using System.Text;


public class Children
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string birthYear;

    public string BirthYear
    {
        get { return birthYear; }
        set { birthYear = value; }
    }

    private Children childOf;

    public Children ChildOf
    {
        get { return childOf; }
        set { childOf = value; }
    }

    public Children(){}
    public Children(string name, string birthYear, Children childOF)
    {
        this.Name = name;
        this.BirthYear = birthYear;
        this.ChildOf = childOF;
    }
}

