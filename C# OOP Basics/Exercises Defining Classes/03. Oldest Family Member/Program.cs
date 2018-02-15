using System;


class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var person = new Person();
            string[] inputPerson = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            person.Name = inputPerson[0];
            person.Age = int.Parse(inputPerson[1]);
            family.AddMember(person);
        }
        Console.WriteLine(family.GetOldestMember());
    }
}

