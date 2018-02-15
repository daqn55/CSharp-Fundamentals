using System;
using System.Collections;
using System.Collections.Generic;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }
            int stackCount = stack.Count;
            for (int i = 1; i <= stackCount; i++)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
