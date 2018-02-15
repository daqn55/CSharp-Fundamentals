using System;
using System.Collections;
using System.Collections.Generic;

namespace _3._Decimal_to_Binary_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            while (input != 0)
            {
                if (input % 2 == 0)
                {
                    stack.Push(0);
                }
                else
                {
                    stack.Push(1);
                }
                input /= 2;
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
