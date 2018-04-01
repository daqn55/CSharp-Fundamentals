using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listy;


        listy = new ListyIterator<string>(Console.ReadLine().Split().Skip(1).ToList());

        var input = Console.ReadLine();

        while (input != "END")
        {
            switch (input)
            {
                case "Move":
                    Console.WriteLine(listy.Move());
                    break;
                case "Print":
                    Console.WriteLine(listy);
                    break;
                case "HasNext":
                    Console.WriteLine(listy.HasNext());
                    break;
            }

            input = Console.ReadLine();
        }
    }
}

