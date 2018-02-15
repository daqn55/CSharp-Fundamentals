using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var queue = new Queue<int>();
            for (int i = 0; i < commands[0]; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < commands[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count < 1)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(commands[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
