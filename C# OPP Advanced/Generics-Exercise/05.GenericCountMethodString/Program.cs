using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Box<string> box = new Box<string>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            box.AddItem(Console.ReadLine());
        }

        string compareElement = Console.ReadLine();

        Console.WriteLine(box.CompareTo(compareElement));
    }
}

