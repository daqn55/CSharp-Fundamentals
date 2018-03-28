using DungeonsAndCodeWizards.Core;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
            DungeonMaster dungeonMaster = new DungeonMaster();

            while (!dungeonMaster.IsGameOver())
            {
                string first = Console.ReadLine();
                if (string.IsNullOrEmpty(first))
                {
                    Console.WriteLine("Final stats:");
                    Console.WriteLine(dungeonMaster.GetStats());
                    break;
                }
                string[] input = first.Split();

                try
                {
                    string[] arg = input.Skip(1).ToArray();

                    switch (input[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(dungeonMaster.JoinParty(arg));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dungeonMaster.AddItemToPool(arg));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dungeonMaster.PickUpItem(arg));
                            break;
                        case "UseItem":
                            Console.WriteLine(dungeonMaster.UseItem(arg));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dungeonMaster.UseItemOn(arg));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(arg));
                            break;
                        case "GetStats":
                            Console.WriteLine(dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dungeonMaster.Attack(arg));
                            break;
                        case "Heal":
                            Console.WriteLine(dungeonMaster.Heal(arg));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dungeonMaster.EndTurn(arg));
                            break;
                    }
                    if (dungeonMaster.IsGameOver())
                    {
                        Console.WriteLine("Final stats:");
                        Console.WriteLine(dungeonMaster.GetStats());
                    }
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentException a)
                    {
                        Console.WriteLine($"Parameter Error: {a.Message}");
                    }
                    else if (ex is InvalidOperationException i)
                    {
                        Console.WriteLine($"Invalid Operation: {i.Message}");
                    }
                }
            }
		}
	}
}