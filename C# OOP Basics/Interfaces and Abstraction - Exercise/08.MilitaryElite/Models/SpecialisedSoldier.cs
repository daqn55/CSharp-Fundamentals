using System;
using System.Collections.Generic;
using System.Text;


public class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    private string corps;

    public string Corps
    {
        get { return corps; }
        set { corps = value; }
    }

}

