using System;


public class Program
{
    static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(Console.ReadLine());

        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int y = 0; y < input.Length; y++)
            {
                var currentLight = Enum.Parse<TrafficLightsEnum>(input[y]);
                count = (int)currentLight;
                if (currentLight == TrafficLightsEnum.Yellow)
                {
                    currentLight = TrafficLightsEnum.Red;
                }
                else
                {
                    currentLight = currentLight + 1;
                }
                input[y] = currentLight.ToString();
            }
            Console.WriteLine(string.Join(" ", input));
        }

    }
}

