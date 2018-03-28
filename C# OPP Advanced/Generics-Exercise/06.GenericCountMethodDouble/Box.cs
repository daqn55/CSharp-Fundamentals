using System;
using System.Collections.Generic;
using System.Text;


public class Box <T> 
    where T : IComparable<T>
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

    public void Swap(int firstIndex, int secondIndex)
    {
        var elementToSwap = this.input[firstIndex];
        this.input[firstIndex] = this.input[secondIndex];
        this.input[secondIndex] = elementToSwap;
    }

    public int CompareTo(T elemntToCompare)
    {
        int count = 0;
        foreach (var e in this.input)
        {


            int c = elemntToCompare.CompareTo(e);
            if (c < 0)
            {
                count++;
            }
            
        }

        return count;
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

