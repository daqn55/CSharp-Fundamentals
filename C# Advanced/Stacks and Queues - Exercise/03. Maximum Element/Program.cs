using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var sortedStack = new Stack<int>();
            sortedStack.Push(0);
            for (int i = 0; i < n; i++)
            {
                int[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (stack.Count > 0)
                {
                    int lastElement = stack.Peek();
                }
                if (commands[0] == 1)
                {
                    stack.Push(commands[1]);
                    if (sortedStack.Peek() <= commands[1])
                    {
                        sortedStack.Push(commands[1]);
                    }
                }
                else if (commands[0] == 2)
                {
                    if (stack.Peek() == sortedStack.Peek())
                    {
                        sortedStack.Pop();
                    }
                    stack.Pop();
                }
                else if (commands[0] == 3)
                {
                    Console.WriteLine(sortedStack.Peek());
                }
            }
        }
    }
}
