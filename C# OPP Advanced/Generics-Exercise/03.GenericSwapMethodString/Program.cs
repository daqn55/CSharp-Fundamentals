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

        int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int firstIndex = swapCommand[0];
        int secondIndex = swapCommand[1];

        box.Swap(firstIndex, secondIndex);

        Console.WriteLine(box);
    }
}

