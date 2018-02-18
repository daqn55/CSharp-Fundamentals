using System;
using System.Collections.Generic;
using System.Text;


public class Pokemon
{
    private string pokemonName;

    public string PokemonName
    {
        get { return pokemonName; }
        set { pokemonName = value; }
    }

    private string pokemonType;

    public string PokemonType
    {
        get { return pokemonType; }
        set { pokemonType = value; }
    }

    public Pokemon(string pokemonName, string pokemonType)
    {
        this.PokemonName = pokemonName;
        this.PokemonType = pokemonType;
    }
}

