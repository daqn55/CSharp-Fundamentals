using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stackFibonacci = new Queue<long>();
            stackFibonacci.Enqueue(0);
            stackFibonacci.Enqueue(1);

            for (int i = 0; i < n; i++)
            {
                long num1 = stackFibonacci.Dequeue();
                long num2 = stackFibonacci.Peek();
                stackFibonacci.Enqueue(num1 + num2);
            }
            Console.WriteLine(stackFibonacci.Peek());
        }
    }
}
