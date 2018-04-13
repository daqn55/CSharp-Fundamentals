using System;


public class Program
{
    static void Main(string[] args)
    {
        Database database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);

        database.Add(6);
        //database.Remove();
        Console.WriteLine(string.Join(" ", database.Fetch()));
    }
}

