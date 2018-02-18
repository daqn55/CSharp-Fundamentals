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

    private Company company;

    public Company Company
    {
        get { return company; }
        set { company = value; }
    }

    private Car car;

    public Car Car
    {
        get { return car; }
        set { car = value; }
    }

    private List<Pokemon> pokemons = new List<Pokemon>();

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    private List<Parent> parents = new List<Parent>();

    public List<Parent> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    private List<Children> childrens = new List<Children>();

    public List<Children> Childrens
    {
        get { return childrens; }
        set { childrens = value; }
    }

    public Person(){}
    public Person(string name, Company company, Car car, List<Pokemon> pokemons,
        List<Parent> parents, List<Children> childrens):this()
    {
        this.Name = name;
        this.Company = company;
        this.Car = car;
        this.Pokemons = pokemons;
        this.Parents = parents;
        this.Childrens = childrens;
    }

    public void UpdateData (string[] data)
    {
        switch (data[1])
        {
            case "company":
                Company = new Company(data[2], data[3], decimal.Parse(data[4]));
                break;
            case "pokemon":
                Pokemon pokemon = new Pokemon(data[2], data[3]);
                Pokemons.Add(pokemon);
                break;
            case "parents":
                Parent parent = new Parent(data[2], data[3]);
                Parents.Add(parent);
                break;
            case "children":
                Children children = new Children(data[2], data[3]);
                Childrens.Add(children);
                break;
            case "car":
                Car = new Car(data[2], int.Parse(data[3]));
                break;
        }
    }
}

