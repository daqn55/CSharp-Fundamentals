using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length == 0 || value == null || value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    private List<Product> products = new List<Product>();

    public List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
    }
}

