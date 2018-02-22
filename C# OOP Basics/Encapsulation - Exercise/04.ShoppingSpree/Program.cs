using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] people = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            List<Person> persons = new List<Person>();
            List<Product> allProducts = new List<Product>();
            for (int i = 0; i < people.Length; i++)
            {
                string[] splitPerson = people[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(splitPerson[0], decimal.Parse(splitPerson[1]));
                persons.Add(person);
            }

            for (int i = 0; i < products.Length; i++)
            {
                string[] splitProduct = products[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                Product product = new Product(splitProduct[0], decimal.Parse(splitProduct[1]));
                allProducts.Add(product);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                string product = command[1];

                if (persons.Find(p => p.Name == name).Money < allProducts.Find(x => x.Name == product).Cost)
                {
                    Console.WriteLine(name + " can't afford " + product);
                }
                else
                {
                    persons.Find(x => x.Name == name).Products.Add(allProducts.Find(p => p.Name == product));
                    persons.Find(x => x.Name == name).Money -= allProducts.Find(p => p.Name == product).Cost;
                    Console.WriteLine(name + " bought " + product);
                }
            }

            foreach (var p in persons)
            {
                Console.Write(p.Name + " - ");
                if (p.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", p.Products));
                }
            }
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
            Environment.Exit(0);
        }
    }
}

