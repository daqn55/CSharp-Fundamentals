using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[n[0], n[1]];
            for (int row = 0; row < n[0]; row++)
            {
                int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int coll = 0; coll < n[1]; coll++)
                {
                    matrix[row, coll] = numbers[coll];
                }
            }

            int[,] matrixSumElem = new int[3, 3];
            int maxSum = 0;
            for (int row = 0; row < n[0] - 2; row++)
            {
                int sum = 0;
                for (int coll = 0; coll < n[1] - 2; coll++)
                {
                    sum = matrix[row, coll] + matrix[row, coll + 1] + matrix[row, coll + 2]
                        + matrix[row + 1, coll] + matrix[row + 1, coll + 1] + matrix[row + 1, coll + 2]
                        + matrix[row + 2, coll] + matrix[row + 2, coll + 1] + matrix[row + 2, coll + 2];
                    if (maxSum < sum)
                    {
                        matrixSumElem[0, 0] = matrix[row, coll];
                        matrixSumElem[0, 1] = matrix[row, coll + 1];
                        matrixSumElem[0, 2] = matrix[row, coll + 2];

                        matrixSumElem[1, 0] = matrix[row + 1, coll];
                        matrixSumElem[1, 1] = matrix[row + 1, coll + 1];
                        matrixSumElem[1, 2] = matrix[row + 1, coll + 2];

                        matrixSumElem[2, 0] = matrix[row + 2, coll];
                        matrixSumElem[2, 1] = matrix[row + 2, coll + 1];
                        matrixSumElem[2, 2] = matrix[row + 2, coll + 2];

                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            for (int row = 0; row < matrixSumElem.GetLength(0); row++)
            {
                for (int coll = 0; coll < matrixSumElem.GetLength(1); coll++)
                {
                    Console.Write(matrixSumElem[row, coll] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
