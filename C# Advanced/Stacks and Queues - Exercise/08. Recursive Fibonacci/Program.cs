using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(getFibonacci(n));
        }
        static public long getFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            long num1 = 0;
            long num2 = 1;
            long finalNum = 0;
            for (int i = 1; i < n; i++)
            {
                finalNum = num1 + num2;
                num1 = num2;
                num2 = finalNum;
            }
            return finalNum;
        }
    }
}
