using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int y = 0; y < n; y++)
                {
                    matrix[i, y] = numbers[y];
                }
            }
            int sumDiagonalOne = 0;
            for (int i = 0; i < n; i++)
            {
                sumDiagonalOne += matrix[i, i];
            }
            int sumDiagonalTwo = 0;
            for (int i = 0; i < n; i++)
            {
                sumDiagonalTwo += matrix[(n - 1 - i), i];
            }
            Console.WriteLine(Math.Abs(sumDiagonalOne - sumDiagonalTwo));
        }
    }
}
