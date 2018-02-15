using System;


class Program
{
    static void Main(string[] args)
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();

        DateModifier dateModifier = new DateModifier();
        var days = Math.Abs(dateModifier.DifferenceBetweenTwoDates(firstDate, secondDate));
        Console.WriteLine(days);
    }
}

