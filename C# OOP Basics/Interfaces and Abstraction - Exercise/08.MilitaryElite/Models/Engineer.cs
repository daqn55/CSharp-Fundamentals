using System;
using System.Collections.Generic;
using System.Text;


public class Engineer : Private, ISpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps, List<string> partName, List<int> hoursWorked)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
        this.PartName = partName;
        this.HoursWorked = hoursWorked;
    }

    private string corps;

    public string Corps
    {
        get { return corps; }
        set { corps = value; }
    }


    private List<string> partName = new List<string>();

    public List<string> PartName
    {
        get { return partName; }
        set { partName = value; }
    }

    private List<int> hoursWorked = new List<int>();

    public List<int> HoursWorked
    {
        get { return hoursWorked; }
        set { hoursWorked = value; }
    }

    public List<string> Repairs()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < this.partName.Count; i++)
        {
            string repair = $"Part Name: {this.PartName[i]} Hours Worked: {this.HoursWorked[i]}";
            result.Add(repair);
        }
        return result;
    }

    public override string ToString()
    {
        string repair = "";
        if (Repairs().Count > 0)
        {
            repair = Environment.NewLine + " " + string.Join($"{Environment.NewLine} ", Repairs());

        }
        string result = base.ToString() +
            Environment.NewLine + $"Corps: {this.Corps}" +
            Environment.NewLine + $"Repairs:" + repair;

        return result;
    }
}

