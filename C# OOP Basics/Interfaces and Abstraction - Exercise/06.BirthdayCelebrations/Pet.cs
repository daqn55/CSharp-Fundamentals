using System;
using System.Collections.Generic;
using System.Text;


public class Pet : CityData
{
    public Pet(string name, string birthday) : base(birthday)
    {
        this.Name = name;
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}

