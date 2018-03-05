using System;
using System.Collections.Generic;
using System.Text;


public class Commando : Private, ISpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, double salary, string corps, List<string> codeName, List<string> state)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
        this.CodeName = codeName;
        this.State = state;
    }

    private string corps;

    public string Corps
    {
        get { return corps; }
        set { corps = value; }
    }


    private List<string> codeName = new List<string>();

    public List<string> CodeName
    {
        get { return codeName; }
        set { codeName = value; }
    }

    private List<string> state = new List<string>();

    public List<string> State
    {
        get { return state; }
        set { state = value; }
    }

    public List<string> Missions()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < this.CodeName.Count; i++)
        {
            string mission = $"Code Name: {this.CodeName[i]} State: {this.State[i]}";
            result.Add(mission);
        }
        return result;
    }

    public override string ToString()
    {
        string mission = "";
        if (Missions().Count > 0)
        {
            mission = Environment.NewLine + " " + string.Join($"{Environment.NewLine} ", Missions());

        }
        string result = base.ToString() +
            Environment.NewLine + $"Corps: {this.Corps}" +
            Environment.NewLine + $"Missions:" + mission;

        return result;
    }
}

