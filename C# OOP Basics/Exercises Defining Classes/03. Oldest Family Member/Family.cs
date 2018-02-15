using System;
using System.Collections.Generic;
using System.Text;


public class Family
{
    private List<Person> people = new List<Person>();

    public void AddMember(Person member)
    {
        people.Add(member);
    }
    public string GetOldestMember()
    {
        string name = people[0].Name;
        int age = people[0].Age;
        foreach (var p in people)
        {
            if (p.Age > age)
            {
                age = p.Age;
                name = p.Name;
            }
        }
        return name + " " + age;
    }

}

