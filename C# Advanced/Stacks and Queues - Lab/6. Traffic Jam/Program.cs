using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Ceiling(1.1));

            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            var queues = new Queue<string>();
            int count = 0;
            while (input != "end")
            {
                
                if (input != "green")
                {
                    queues.Enqueue(input);
                }
                else if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queues.Count > 0)
                        {
                            Console.WriteLine(queues.Dequeue() + " passed!");
                            count++;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(count + " cars passed the crossroads.");
        }
    }
}
