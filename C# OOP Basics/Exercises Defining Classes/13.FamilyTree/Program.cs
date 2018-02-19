using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Person person = new Person();
        bool firstLineIsYear = false;
        if (IsYear(firstLine[0]))
        {
            person.BirthYear = firstLine[0];
            firstLineIsYear = true;
        }
        else
        {
            person.Name = firstLine[0] + " " + firstLine[1];
        }

        List<Member> members = new List<Member>();
        List<Parent> parents = new List<Parent>();
        List<Children> childrens = new List<Children>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }

            string[] dataFamily = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (dataFamily.Length == 3)
            {
                if (!dataFamily.Contains("-"))
                {
                    string names = Names(dataFamily[0], dataFamily[1]);
                    Member member = new Member();
                    member.Name = names;
                    member.BirthDate = dataFamily[2];
                    members.Add(member);
                }
                else
                {
                    Parent parent = new Parent();
                    parent.BirthYear = dataFamily[0];
                    parent.ParentOf.BirthDate = dataFamily[2];
                    parents.Add(parent);
                }
            }
            else if (dataFamily.Length == 4)
            {
                if (IsYear(dataFamily[0]))
                {
                    Parent parent = new Parent();
                    parent.BirthYear = dataFamily[0];
                    parent.ParentOf.Name = Names(dataFamily[2], dataFamily[3]);
                    parents.Add(parent);
                }
                else
                {
                    Parent parent = new Parent();
                    parent.Name = Names(dataFamily[0], dataFamily[1]);
                    parent.ParentOf.BirthDate = dataFamily[3];
                    parents.Add(parent);
                }
            }
            else if (dataFamily.Length == 5)
            {
                Parent parent = new Parent();
                parent.Name = Names(dataFamily[0], dataFamily[1]);
                parent.ParentOf.Name = Names(dataFamily[3], dataFamily[4]);
                parents.Add(parent);
            }
        }

        if (firstLineIsYear)
        {
            person.Name = members.Find(x => x.BirthDate == person.BirthYear).Name;
        }
        else
        {
            person.BirthYear = members.Find(x => x.Name == person.Name).BirthDate;
        }

        foreach (var p in parents)
        {
            if (p.Name == null)
            {
                p.Name = members.Find(x => x.BirthDate == p.BirthYear).Name;
            }
            else if (p.BirthYear == null)
            {
                p.BirthYear = members.Find(x => x.Name == p.Name).BirthDate;
            }
            if (p.ParentOf.Name == null)
            {
                p.ParentOf.Name = members.Find(x => x.BirthDate == p.ParentOf.BirthDate).Name;
            }
            else if (p.ParentOf.BirthDate == null)
            {
                p.ParentOf.BirthDate = members.Find(x => x.Name == p.ParentOf.Name).BirthDate;
            }
        }

        Console.WriteLine(person.Name + " " + person.BirthYear);
        Console.WriteLine("Parents:");
        foreach (var p in parents)
        {
            if (p.ParentOf.Name == person.Name)
            {
                Console.WriteLine(p.Name + " " + p.BirthYear);
            }
        }
        Console.WriteLine("Children:");
        foreach (var p in parents)
        {
            if (p.Name == person.Name)
            {
                Console.WriteLine(p.ParentOf.Name + " " + p.ParentOf.BirthDate);
            }
        }
    }

    public static bool IsYear(string date)
    {
        bool isYear = DateTime.TryParseExact(date, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthYear);
        return isYear;
    }

    public static string Names(string firstName, string lastName)
    {
        return firstName + " " + lastName;
    }
}

