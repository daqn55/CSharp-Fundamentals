using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : CityData, ICitizen, IBuyer
{
    public Citizen(string name, int age, string id, string birthday) : base(id, birthday)
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

    private int food;

    public int Food
    {
        get { return food; }
        set { food = value; }
    }

    public int BuyFood()
    {
        return 10;
    }
}

