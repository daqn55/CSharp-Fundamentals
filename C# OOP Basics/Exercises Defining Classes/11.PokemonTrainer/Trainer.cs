using System;
using System.Collections.Generic;
using System.Text;

public class Trainer
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int numberOfBadges;

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    private List<Pokemon> pokemons = new List<Pokemon>();

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }

    public Trainer()
    {
        this.numberOfBadges = 0;
    }
    public Trainer(string name, int numberOfBadges, List<Pokemon> pokemons):this()
    {
        this.Name = name;
        this.NumberOfBadges = numberOfBadges;
        this.Pokemons = pokemons;
    }
}

