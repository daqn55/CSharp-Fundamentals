using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : CityData, ICitizen
{
    public Citizen(string name, int age, string id) : base(id)
    {
        this.Name = name;
        this.Age = age;
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
}

