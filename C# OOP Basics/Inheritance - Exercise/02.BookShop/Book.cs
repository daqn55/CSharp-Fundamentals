using System;
using System.Collections.Generic;
using System.Text;


public class Book
{
    private string title;

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    private string author;

    public string Author
    {
        get { return author; }
        set
        {
            if (value.Split().Length == 2)
            {
                if (char.IsDigit(value.Split()[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            author = value;
        }
    }

    private decimal price;

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        return stringBuilder.ToString().TrimEnd();
    }
}

