using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetIndex = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, string>> allInfo = new Dictionary<string, Dictionary<string, string>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] infoName = input.Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
                string name = infoName[0];
                Dictionary<string, string> personData = new Dictionary<string, string>();

                if (!allInfo.ContainsKey(name))
                {
                    allInfo.Add(name, personData);
                }

                foreach (var i in infoName.Skip(1))
                {
                    var info = i.Split(':');
                    if (allInfo[name].ContainsKey(info[0]))
                    {
                        allInfo[name][info[0]] = info[1];
                    }
                    else
                    {
                        allInfo[name].Add(info[0], info[1]);
                    }
                }
            }

            string nameToKill = Console.ReadLine().Split()[1];

            int infoIndex = 0;
            Console.WriteLine($"Info on {nameToKill}:");
            foreach (var p in allInfo.Where(z => z.Key == nameToKill))
            {
                foreach (var v in p.Value.OrderBy(x => x.Key))
                {
                    infoIndex += v.Key.Length + v.Value.Length;
                    Console.WriteLine($"---{v.Key}: {v.Value}");
                }
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }
    }
}
