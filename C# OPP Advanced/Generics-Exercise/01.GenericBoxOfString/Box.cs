using System;
using System.Collections.Generic;
using System.Text;


public class Box <T>
{
    private List<T> input;

    public Box()
    {
        this.input = new List<T>();
    }

    public void AddItem (T input)
    {
        this.input.Add(input);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var item in this.input)
        {
            sb.AppendLine($"{item.GetType().FullName}: {item}");
        }
        return sb.ToString().TrimEnd();
    }
}

