using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Pizza
{
    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length < 1 || value.Length > 15 || value == " ")
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private Dough dough;

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    private List<Topping> toppings = new List<Topping>();

    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value;}
    }

    public Pizza(string name)
    {
        this.Name = name;
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    public override string ToString()
    {
        double totalCalories = this.Dough.TotalCalories() + this.Toppings.Sum(x => x.TotalCalories());
        return $"{name} - {totalCalories:f2} Calories.";
    }
}
