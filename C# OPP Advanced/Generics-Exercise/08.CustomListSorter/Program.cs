using System;


public class Program
{
    static void Main(string[] args)
    {
        Box<string> box = new Box<string>();

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }

            var command = input.Split();

            switch (command[0])
            {
                case "Add":
                    box.Add(command[1]);
                    break;
                case "Remove":
                    box.Remove(int.Parse(command[1]));
                    break;
                case "Contains":
                    if (box.Contains(command[1]))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                    break;
                case "Swap":
                    box.Swap(int.Parse(command[1]), int.Parse(command[2]));
                    break;
                case "Greater":
                    Console.WriteLine(box.CountGreaterThan(command[1]));
                    break;
                case "Max":
                    Console.WriteLine(box.Max());
                    break;
                case "Min":
                    Console.WriteLine(box.Min());
                    break;
                case "Sort":
                    box.Sort();
                    break;
                case "Print":
                    Console.WriteLine(box);
                    break;
            }
        }
    }
}

