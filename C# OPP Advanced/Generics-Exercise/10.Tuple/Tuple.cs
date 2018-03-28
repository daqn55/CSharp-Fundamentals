using System;
using System.Collections.Generic;
using System.Text;


public class Tuple <item1, item2>
{
    private item1 firstItem;
    private item2 secondItem;

    public Tuple(item1 firstItem, item2 secondItem)
    {
        this.firstItem = firstItem;
        this.secondItem = secondItem;
    }

    public override string ToString()
    {
        return $"{firstItem} -> {secondItem}";
    }
}

