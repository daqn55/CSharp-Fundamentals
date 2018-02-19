using System;
using System.Collections.Generic;
using System.Text;


public class Person
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

    private List<Children> childrens = new List<Children>();

    public List<Children> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }

    private List<Parent> parents = new List<Parent>();

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public Person(){}
    public Person(string name, string birthYear, List<Children> childrens, List<Parent> parents):this()
    {
        this.Name = name;
        this.BirthYear = birthYear;
        this.Childrens = childrens;
        this.Parents = parents;
    }
}

