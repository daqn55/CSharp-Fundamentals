using System;
using System.Collections.Generic;
using System.Text;


public class Parent
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string birthYear;

    public string BirthYear
    {
        get { return birthYear; }
        set { birthYear = value; }
    }

    private Member parentOf = new Member();

    public Member ParentOf
    {
        get { return parentOf; }
        set { parentOf = value; }
    }

    public Parent(){}
    public Parent(string name, string birthYear, Member parentOf):this()
    {
        this.Name = name;
        this.BirthYear = birthYear;
        this.ParentOf = parentOf;
    }
}

