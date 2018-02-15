using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poisonous_Plants_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var plantsPest = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            var deadDays = new int[n];
            stack.Push(0);

            for (int i = 1; i < n; i++)
            {
                int lastDay = 0;
                while (stack.Count > 0 && plantsPest[stack.Peek()] >= plantsPest[i])
                {
                    lastDay = Math.Max(lastDay, deadDays[stack.Pop()]);
                }
                if (stack.Count > 0)
                {
                    deadDays[i] = lastDay + 1;
                }
                stack.Push(i);
            }
            Console.WriteLine(deadDays.Max());
        }
    }
}
