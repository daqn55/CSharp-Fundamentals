using System;
using System.Collections.Generic;
using System.Text;


public class Threeuple <item1, item2, item3> 
    where item3 : IComparable<item3>
{
    private item1 firstItem;
    private item2 secondItem;
    private item3 thirdItem;

    public Threeuple(item1 firstItem, item2 secondItem, item3 thirdItem)
    {
        this.firstItem = firstItem;
        this.secondItem = secondItem;
        this.thirdItem = thirdItem;
    }

    public override string ToString()
    {
        return $"{firstItem} -> {secondItem} -> {thirdItem}";
    }
}

