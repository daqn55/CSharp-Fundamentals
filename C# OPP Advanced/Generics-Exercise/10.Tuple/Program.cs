using System;


public class Program
{
    static void Main(string[] args)
    {
        var input1 = Console.ReadLine().Split();
        var names = input1[0] + " " + input1[1];
        var address = input1[2];

        Tuple<string, string> tuple = new Tuple<string, string>(names, address);

        var input2 = Console.ReadLine().Split();
        var name = input2[0];
        var litersOfBeer = int.Parse(input2[1]);

        Tuple<string, int> tuple2 = new Tuple<string, int>(name, litersOfBeer);

        var input3 = Console.ReadLine().Split();
        var intNum = int.Parse(input3[0]);
        var doubleNum = double.Parse(input3[1]);

        Tuple<int, double> tuple3 = new Tuple<int, double>(intNum, doubleNum);

        Console.WriteLine(tuple);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}

