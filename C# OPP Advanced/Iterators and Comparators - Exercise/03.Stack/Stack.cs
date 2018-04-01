using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Stack<T> : IEnumerable<T>
{
    private List<T> collection;

    public Stack()
    {
        this.collection = new List<T>();
    }

    public void Push(params T[] item)
    {
        foreach (var i in item)
        {
            this.collection.Add(i);
        }
    }

    public T Pop()
    {
        if (this.collection.Count < 1)
        {
            throw new ArgumentException("No elements");
        }
        var lastItem = this.collection.Last();
        this.collection.RemoveAt(this.collection.Count - 1);

        return lastItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.collection.Count-1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

