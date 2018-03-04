using System;                                                                  
using System.Collections.Generic;
using System.Text;


public class CityData : IId
{
    public CityData(string birthday)
    {
        this.Birthday = birthday;
    }
    public CityData(string id, string birthday) :this(birthday)
    {
        this.Id = id;
    }

    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    private string birthday;

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
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

    public string SpecificBirthday(string dateToCheck)
    {
        string year = "";
        if (this.Birthday.Split('/').Length == 3)
        {
            year = this.Birthday.Split('/')[2];

        }
        if (year == dateToCheck)
        {
            return this.Birthday;
        }
        else
        {
            return string.Empty;
        }
    }
}

