using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ListyIterator<T>
{
    private List<T> collection;
    private int internalIndex = 0;

    public ListyIterator(List<T> collection)
    {
        this.collection = collection;
    }

    public bool Move()
    {
        if (this.internalIndex < this.collection.Count - 1)
        {
            this.internalIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.internalIndex == this.collection.Count - 1)
        {
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        if (this.collection.Count < 1)
        {
            return "Invalid Operation!";
        }

        return $"{this.collection[this.internalIndex]}";
    }
}

