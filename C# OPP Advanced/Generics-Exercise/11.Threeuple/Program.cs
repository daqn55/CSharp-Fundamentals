using System;


public class Program
{
    static void Main(string[] args)
    {
        var input1 = Console.ReadLine().Split();
        var names = input1[0] + " " + input1[1];
        var address = input1[2];
        var town = input1[3];

        Threeuple<string, string, string> tuple = new Threeuple<string, string, string>(names, address, town);

        var input2 = Console.ReadLine().Split();
        var name = input2[0];
        var litersOfBeer = int.Parse(input2[1]);
        var drunkOrNot = input2[2];
        var isDrunk = "False";
        if (drunkOrNot == "drunk")
        {
            isDrunk = "True";
        }

        Threeuple<string, int, string> tuple2 = new Threeuple<string, int, string>(name, litersOfBeer, isDrunk);

        var input3 = Console.ReadLine().Split();
        var name2 = input3[0];
        var doubleNum = double.Parse(input3[1]);
        var bankName = input3[2];

        Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(name2, doubleNum, bankName);

        Console.WriteLine(tuple);
        Console.WriteLine(tuple2);
        Console.WriteLine(tuple3);
    }
}

