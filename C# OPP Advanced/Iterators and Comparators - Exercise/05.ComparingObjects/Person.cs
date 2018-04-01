﻿using System;
using System.Collections.Generic;
using System.Text;


public class Person : IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public string Name { get; }

    public int Age { get; }

    public string Town { get; }

    public int CompareTo(Person person)
    {
        if (this.Name == person.Name && this.Age == person.Age && this.Town == person.Town)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}

