using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());

            int countBulletFired = 0;
            while (locks.Count > 0 && bullets.Count > 0)
            {
                var bullet = bullets.Pop();
                countBulletFired++;

                if (locks.Count > 0)
                {
                    if (bullet <= locks.Peek())
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }

                if (countBulletFired % sizeOfGunBarrel == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (countBulletFired * bulletPrice)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
