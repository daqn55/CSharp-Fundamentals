using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            string[,] matrix = new string[n[0], n[1]];

            for (int i = 0; i < n[0]; i++)
            {
                string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int y = 0; y < numbers.Length; y++)
                {
                    matrix[i, y] = numbers[y];
                }
            }
            int count = 0;
            for (int row = 0; row < n[0] - 1; row++)
            {
                for (int coll = 0; coll < n[1] - 1; coll++)
                {
                    if (matrix[row, coll] == matrix[row + 1, coll] && matrix[row, coll] == matrix[row, coll + 1]
                        && matrix[row + 1, coll] == matrix[row + 1, coll + 1])
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
