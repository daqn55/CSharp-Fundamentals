using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();

        while (true)
        {
            var input = Console.ReadLine().Split();

            if (input[0] == "END")
            {
                break;
            }

            Person person = new Person(input[0], int.Parse(input[1]), input[2]);
            people.Add(person);
        }

        int personToCheck = int.Parse(Console.ReadLine());

        int equalPeople = 0;
        int notEqualPeople = 0;
        for (int i = 0; i < people.Count; i++)
        {
            if (i != personToCheck - 1)
            {
                int isEqual = people[personToCheck-1].CompareTo(people[i]);
                if (isEqual == 1)
                {
                    equalPeople++;
                }
                else
                {
                    notEqualPeople++;
                }
            }
        }

        if (equalPeople == 0)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{equalPeople + 1} {notEqualPeople} {people.Count}");
        }
    }
}

