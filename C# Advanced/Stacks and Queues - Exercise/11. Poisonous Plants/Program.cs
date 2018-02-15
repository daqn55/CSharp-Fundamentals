using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            int daysCount = 0;
            Stack<int> memStack = new Stack<int>();
            while (true)
            {
                if (memStack.Count > stack.Count)
                {
                    int memStackCount = memStack.Count;
                    for (int i = 0; i < memStackCount; i++)
                    {
                        stack.Push(memStack.Pop());
                    }
                }

                int stackCount = stack.Count;
                for (int i = 0; i < stackCount - 1; i++)
                {
                    int memPlant = stack.Pop();
                    if (memPlant <= stack.Peek())
                    {
                        memStack.Push(memPlant);
                    }
                    if (i == stackCount - 2)
                    {
                        memStack.Push(stack.Pop());
                    }
                }
                if (stackCount == memStack.Count)
                {
                    break;
                }
                daysCount++;
            }
            Console.WriteLine(daysCount);
        }
    }
}
