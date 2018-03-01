using System;
using System.Collections.Generic;
using System.Text;


public class Animal : ISoundProducable
{
    private const string errorMsg = "Invalid input!";

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    private string name;

    public string Name
    {
        get { return name; }
        set
        {
            if (value == " ")
            {
                throw new ArgumentException(errorMsg);
            }
            name = value;
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(errorMsg);
            }
            age = value;
        }
    }

    private string gender;

    public string Gender
    {
        get { return gender; }
        set
        {
            if (value == " ")
            {
                throw new ArgumentException(errorMsg);
            }
            gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "";
    }
}

