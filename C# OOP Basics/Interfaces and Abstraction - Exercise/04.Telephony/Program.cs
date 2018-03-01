using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> numbers = new List<string>(Console.ReadLine().Split(' '));
        List<string> sites = new List<string>(Console.ReadLine().Split(' '));

        Smartphone smartphone = new Smartphone();

        numbers.ForEach(n => Console.WriteLine(smartphone.Calling(n)));
        sites.ForEach(s => Console.WriteLine(smartphone.Browsing(s)));
    }
}

