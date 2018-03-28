using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Box<double> box = new Box<double>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            box.AddItem(double.Parse(Console.ReadLine()));
        }

        double compareElement = double.Parse(Console.ReadLine());

        Console.WriteLine(box.CompareTo(compareElement));
    }
}

