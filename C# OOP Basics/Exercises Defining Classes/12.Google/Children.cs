using System;
using System.Collections.Generic;
using System.Text;


public class Children
{
    private string childName;

    public string ChildName
    {
        get { return childName; }
        set { childName = value; }
    }

    private string childBirthday;

    public string ChildBirthday
    {
        get { return childBirthday; }
        set { childBirthday = value; }
    }

    public Children(string childName, string childBirthday)
    {
        this.ChildName = childName;
        this.ChildBirthday = childBirthday;
    }
}

