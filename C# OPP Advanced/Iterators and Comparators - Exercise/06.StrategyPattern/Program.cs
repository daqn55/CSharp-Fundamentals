using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        SortedSet<Person> peopleNameSorted = new SortedSet<Person>(new PersonNameCompare());
        SortedSet<Person> peopleAgeSorted = new SortedSet<Person>(new PersonAgeCompare());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();

            Person person = new Person(input[0], int.Parse(input[1]));

            peopleNameSorted.Add(person);
            peopleAgeSorted.Add(person);
        }

        foreach (var p in peopleNameSorted)
        {
            Console.WriteLine(p.Name + " " + p.Age);
        }

        foreach (var p in peopleAgeSorted)
        {
            Console.WriteLine(p.Name + " " + p.Age);
        }
    }
}

