using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        while (true)
        {
            string animalType = Console.ReadLine();
            if (animalType == "Beast!")
            {
                break;
            }
            string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            try
            {
                switch (animalType)
                {
                    case "Dog":
                        animals.Add(new Dog(animalInfo[0], int.Parse(animalInfo[1]),
                            animalInfo[2]));
                        break;
                    case "Cat":
                        animals.Add(new Cat(animalInfo[0], int.Parse(animalInfo[1]),
                            animalInfo[2]));
                        break;
                    case "Frog":
                        animals.Add(new Frog(animalInfo[0], int.Parse(animalInfo[1]),
                            animalInfo[2]));
                        break;
                    case "Tomcat":
                        animals.Add(new Tomcat(animalInfo[0], int.Parse(animalInfo[1])));
                        break;
                    case "Kitten":
                        animals.Add(new Kitten(animalInfo[0], int.Parse(animalInfo[1])));
                        break;
                    default: Console.WriteLine("Invalid input!");
                        break;
                }
            }
            catch (ArgumentException a)
            {
                Console.WriteLine(a.Message);
            }
        }

        foreach (var a in animals)
        {
            Output(a, a.Name, a.Age, a.Gender, a.ProduceSound());
        }
    }

    public static void Output(Animal type, string name, int age, string gender, string sound)
    {
        Console.WriteLine(type);
        Console.WriteLine(name + " " + age + " " + gender);
        Console.WriteLine(sound);
    }
}

