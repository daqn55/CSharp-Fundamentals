using System;
using System.Collections.Generic;
using System.Text;


public class Soldier : ISoldier
{
    public Soldier(string id, string firstName, string lastName)
    {
        this.Id = id;
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    private string firstName;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public override string ToString()
    {
        string result = $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        return result;
    }
}

