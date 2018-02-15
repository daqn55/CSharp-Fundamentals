using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rubiks_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowColl = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int r = rowColl[0];
            int c = rowColl[1];
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[r, c];
            int count = 0;
            for (int row = 0; row < r; row++)
            {
                for (int coll = 0; coll < c; coll++)
                {
                    count++;
                    matrix[row, coll] = count;
                }
            }
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int firstNumCommand = int.Parse(commands[0]);
                int secondNumCommand = int.Parse(commands[2]);
                if (commands[1] == "left")
                {
                    for (int left = 0; left < secondNumCommand; left++)
                    {
                        int memNum = matrix[firstNumCommand, 0];
                        for (int y = 0; y < matrix.GetLength(1) - 1; y++)
                        {
                            matrix[firstNumCommand, y] = matrix[firstNumCommand, y + 1];
                        }
                        matrix[firstNumCommand, matrix.GetLength(firstNumCommand) - 1] = memNum;
                    }
                }
                else if (commands[1] == "right")
                {
                    for (int right = 0; right < secondNumCommand; right++)
                    {
                        int memNum = matrix[firstNumCommand, matrix.GetLength(1) - 1];
                        for (int y = matrix.GetLength(1) - 1; y > 0; y--)
                        {
                            matrix[firstNumCommand, y] = matrix[firstNumCommand, y - 1];
                        }
                        matrix[firstNumCommand, 0] = memNum;
                    }
                }
                else if (commands[1] == "down")
                {
                    for (int up = 0; up < secondNumCommand; up++)
                    {
                        int memNum = matrix[matrix.GetLength(0) - 1, firstNumCommand];
                        for (int y = matrix.GetLength(0) - 1; y > 0; y--)
                        {
                            matrix[y, firstNumCommand] = matrix[y - 1, firstNumCommand];
                        }
                        matrix[0, firstNumCommand] = memNum;
                    }
                }
                else if (commands[1] == "up")
                {
                    for (int down = 0; down < secondNumCommand; down++)
                    {
                        int memNum = matrix[0, firstNumCommand];
                        for (int y = 0; y < matrix.GetLength(0) - 1; y++)
                        {
                            matrix[y, firstNumCommand] = matrix[y + 1, firstNumCommand];
                        }
                        matrix[matrix.GetLength(0) - 1, firstNumCommand] = memNum;
                    }
                }
            }
            int countNumber = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int coll = 0; coll < matrix.GetLength(1); coll++)
                {
                    if (matrix[row, coll] != countNumber)
                    {

                    }
                    countNumber++;
                }
            }
        }
    }
}
