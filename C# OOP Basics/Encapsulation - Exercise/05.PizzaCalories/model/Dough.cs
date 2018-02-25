using System;
using System.Collections.Generic;
using System.Text;


public class Dough
{
    private string flourType;

    public string FlourType
    {
        get { return flourType; }
        set
        {
            string typeToLower = value.ToLower();
            if (typeToLower != "white" && typeToLower != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        set
        {
            string techniqueToLower = value.ToLower();
            if (techniqueToLower != "crispy" && techniqueToLower != "chewy" && techniqueToLower != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    private int weight;

    public int Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double TotalCalories()
    {
        double flourType = 0;
        double bakingTechnique = 0;

        switch (this.FlourType.ToLower())
        {
            case "white":
                flourType = 1.5;
                break;
            case "wholegrain":
                flourType = 1;
                break;
        }
        switch (this.BakingTechnique.ToLower())
        {
            case "crispy":
                bakingTechnique = 0.9;
                break;
            case "chewy":
                bakingTechnique = 1.1;
                break;
            case "homemade":
                bakingTechnique = 1;
                break;
        }

        return (2 * this.Weight) * flourType * bakingTechnique;
    }
}

