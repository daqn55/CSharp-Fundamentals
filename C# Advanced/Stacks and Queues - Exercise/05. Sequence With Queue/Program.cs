using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sequence_With_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                long firstNum = queue.Peek();
                queue.Enqueue(firstNum + 1);
                queue.Enqueue(2 * firstNum + 1);
                queue.Enqueue(firstNum + 2);
                Console.Write(queue.Dequeue());
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
