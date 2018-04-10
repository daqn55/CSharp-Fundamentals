using System;
using System.Collections.Generic;
using System.Text;


public class Reviewers : Command
{
    public Reviewers(string[] data, List<Weapon> weapons) : base(data, weapons)
    {
    }

    public override string Execute()
    {
        var type = typeof(Weapon);
        Attribute[] attributes = Attribute.GetCustomAttributes(type);

        string result = string.Empty;
        foreach (var attr in attributes)
        {
            if (attr is CustomAtribute)
            {
                CustomAtribute customAtribute = (CustomAtribute)attr;
                result = $"Reviewers: {customAtribute.reviewers}";
            }
        }

        return result;
    }
}

