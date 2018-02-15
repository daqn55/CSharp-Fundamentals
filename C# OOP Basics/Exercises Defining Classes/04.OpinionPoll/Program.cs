using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            Person person = new Person();
            string[] personInfo = Console.ReadLine().Split(' ');
            person.Name = personInfo[0];
            person.Age = int.Parse(personInfo[1]);
            people.Add(person);
        }

        foreach (var p in people.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{p.Name} - {p.Age}");
        }
    }
}

