using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (persons.Any(p => p.Name == data[0]))
            {
                persons.Find(p => p.Name == data[0]).UpdateData(data);
            }
            else
            {
                Person person = new Person();
                person.Name = data[0];
                person.UpdateData(data);
                persons.Add(person);
            }
            
        }

        string nameToExtractData = Console.ReadLine();

        var extractedPerson = persons.Find(p => p.Name == nameToExtractData);
        Console.WriteLine(extractedPerson.Name);
        Console.WriteLine("Company:");
        if (extractedPerson.Company != null)
        {
            Console.WriteLine($"{extractedPerson.Company.CompanyName} " +
                $"{extractedPerson.Company.Department} " +
                $"{extractedPerson.Company.Salary:f2}");
        }
        Console.WriteLine("Car:");
        if (extractedPerson.Car != null)
        {
            Console.WriteLine($"{extractedPerson.Car.CarModel} " +
                $"{extractedPerson.Car.CarSpeed}");
        }
        Console.WriteLine("Pokemon:");
        if (extractedPerson.Pokemons.Count != 0)
        {
            foreach (var p in extractedPerson.Pokemons)
            {
                Console.WriteLine($"{p.PokemonName} {p.PokemonType}");
            }
        }
        Console.WriteLine("Parents:");
        if (extractedPerson.Parents.Count != 0)
        {
            foreach (var p in extractedPerson.Parents)
            {
                Console.WriteLine($"{p.ParentName} {p.ParentBirthday}");
            }
        }
        Console.WriteLine("Children:");
        if (extractedPerson.Childrens.Count != 0)
        {
            foreach (var c in extractedPerson.Childrens)
            {
                Console.WriteLine($"{c.ChildName} {c.ChildBirthday}");
            }
        }
    }
}

