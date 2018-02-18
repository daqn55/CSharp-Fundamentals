using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    private string parentName;

    public string ParentName
    {
        get { return parentName; }
        set { parentName = value; }
    }

    private string parentBirthday;

    public string ParentBirthday
    {
        get { return parentBirthday; }
        set { parentBirthday = value; }
    }

    public Parent(string parentName, string parentBirthday)
    {
        this.ParentBirthday = parentBirthday;
        this.ParentName = parentName;
    }
}

