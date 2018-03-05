using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<Soldier> privates)
    : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    private List<Soldier> privates = new List<Soldier>();

    public List<Soldier> Privates
    {
        get { return privates; }
        set { privates = value; }
    }

    public override string ToString()
    {

        string result = base.ToString() + Environment.NewLine +
            $"Privates:" + Environment.NewLine + " " + string.Join($"{Environment.NewLine} ", this.Privates);
        return result;
    }
}

