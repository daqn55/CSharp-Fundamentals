using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] operations = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            for (int i = 0; i < operations[0]; i++)
            {
                stack.Push(numbers[i]);
            }
            for (int i = 0; i < operations[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Count < 1)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(operations[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestNumber = int.MaxValue;
                int count = stack.Count;
                for (int i = 0; i < count; i++)
                {
                    int currentNum = stack.Pop();
                    if (smallestNumber > currentNum)
                    {
                        smallestNumber = currentNum;
                    }
                }
                Console.WriteLine(smallestNumber);
            }
        }
    }
}
