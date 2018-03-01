using System;


class Program
{
    static void Main(string[] args)
    {
        string driver = Console.ReadLine();
        ICars cars = new Ferrari(driver);

        Console.WriteLine(cars);
    }
}

