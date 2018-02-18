using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Tournament")
            {
                break;
            }

            string[] dataTrainer = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Pokemon pokemon = new Pokemon(dataTrainer[1], dataTrainer[2], int.Parse(dataTrainer[3]));
            if (trainers.Any(x => x.Name == dataTrainer[0]))
            {
                trainers.Find(x => x.Name == dataTrainer[0]).Pokemons.Add(pokemon);
            }
            else
            {
                Trainer trainer = new Trainer();
                trainer.Name = dataTrainer[0];
                trainer.Pokemons.Add(pokemon);
                trainers.Add(trainer);
            }
            
        }

        while (true)
        {
            string commands = Console.ReadLine();
            if (commands == "End")
            {
                break;
            }

            foreach (var t in trainers)
            {
                if (t.Pokemons.Any(p => p.Element == commands))
                {
                    t.NumberOfBadges += 1;
                }
                else
                {
                    for (int i = 0; i < t.Pokemons.Count; i++)
                    {
                        t.Pokemons[i].Health -= 10;
                        if (t.Pokemons[i].Health <= 0)
                        {
                            t.Pokemons.RemoveAt(i);
                        }
                    }
                }
            }
        }

        foreach (var t in trainers.OrderByDescending(x => x.NumberOfBadges))
        {
            Console.WriteLine(t.Name + " " + t.NumberOfBadges + " " + t.Pokemons.Count);
        }
    }
}

