using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var list = new List<int>(n);
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < n; i++)
            {
                list.Add(input[i]);
            }

            var deadPlantsIndexes = new List<int>();
            int daysCount = 0;
            while (true)
            {
                int plantCount = 0;
                for (int i = list.Count-1; i > 0; i--)
                {
                    if (!deadPlantsIndexes.Contains(i))
                    {
                        plantCount++;
                        if (!deadPlantsIndexes.Contains(i-1))
                        {
                            if (list[i] > list[i - 1])
                            {
                                deadPlantsIndexes.Add(i);
                            }
                        }
                        else
                        {
                            if (i > 1)
                            {
                                int savePlantIndex = 0;
                                for (int y = i - 1; y > 0; y--)
                                {
                                    if (!deadPlantsIndexes.Contains(y))
                                    {
                                        savePlantIndex = y;
                                        break;
                                    }
                                }
                                if (list[i] > list[savePlantIndex])
                                {
                                    deadPlantsIndexes.Add(i);
                                }
                            }
                            
                        }
                    }
                }
                if (plantCount+1 == list.Count - deadPlantsIndexes.Count)
                {
                    break;
                }
                daysCount++;
            }
            Console.WriteLine(daysCount);
        }
    }
}
