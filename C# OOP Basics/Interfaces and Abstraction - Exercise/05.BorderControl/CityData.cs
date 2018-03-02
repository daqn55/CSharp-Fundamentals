using System;
using System.Collections.Generic;
using System.Text;


public class CityData : IId
{
    public CityData(string id)
    {
        this.Id = id;
    }

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool fakeId(string numToCheck)
    {
        string lastNumbers = this.Id.Substring(this.Id.Length - numToCheck.Length);
        if (lastNumbers == numToCheck)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

