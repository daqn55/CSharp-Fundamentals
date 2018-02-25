using System;
using System.Collections.Generic;
using System.Text;


public class Topping
{
    private string type;

    public string Type
    {
        get { return type; }
        set
        {
            string typeToLower = value.ToLower();
            if (typeToLower != "meat" && typeToLower != "veggies" && typeToLower != "cheese" && typeToLower != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    private int weight;

    public int Weight
    {
        get { return weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double TotalCalories()
    {
        double typeCal = 0;

        switch (this.Type.ToLower())
        {
            case "meat":
                typeCal = 1.2;
                break;
            case "veggies":
                typeCal = 0.8;
                break;
            case "cheese":
                typeCal = 1.1;
                break;
            case "sauce":
                typeCal = 0.9;
                break;
        }

        return (2 * this.Weight) * typeCal;
    }
}

