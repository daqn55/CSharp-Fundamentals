using System;
using System.Collections;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Stack<string> stack = new Stack<string>();

        var input = Console.ReadLine();
        while (input != "END")
        {
            string[] command = input.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            switch (command[0])
            {
                case "Push":
                    stack.Push(command.Skip(1).ToArray());
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (ArgumentException a)
                    {
                        Console.WriteLine(a.Message);
                    }
                    break;

            }
            input = Console.ReadLine();
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var s in stack)
            {
                Console.WriteLine(s);
            }
        }
        

    }
}

