using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Box<T>
    where T : IComparable<T>
{
    private List<T> input;

    public Box()
    {
        this.input = new List<T>();
    }

    public void Add(T input)
    {
        this.input.Add(input);
    }

    public T Remove(int index)
    {
        var returnItem = this.input[index];

        this.input.RemoveAt(index);

        return returnItem;
    }

    public bool Contains(T element)
    {
        return this.input.Contains(element);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        var elementToSwap = this.input[firstIndex];
        this.input[firstIndex] = this.input[secondIndex];
        this.input[secondIndex] = elementToSwap;
    }

    public int CountGreaterThan(T elemntToCompare)
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

    public T Max()
    {
        var result = this.input[0];
        for (int i = 1; i < this.input.Count; i++)
        {
            if (result.CompareTo(this.input[i]) < 0)
            {
                result = this.input[i];
            }
        }

        return result;
    }

    public T Min()
    {
        var result = this.input[0];
        for (int i = 1; i < this.input.Count; i++)
        {
            if (result.CompareTo(this.input[i]) > 0)
            {
                result = this.input[i];
            }
        }

        return result;
    }

    public void Sort()
    {
        this.input.Sort((a, b) => a.CompareTo(b));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var item in this.input)
        {
            sb.AppendLine($"{item}");
        }
        return sb.ToString().TrimEnd();
    }
}

