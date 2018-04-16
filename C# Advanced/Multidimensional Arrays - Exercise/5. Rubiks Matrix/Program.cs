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

                switch (commands[1])
                {
                    case "left":
                        LeftCommand(matrix, firstNumCommand, secondNumCommand);
                        break;
                    case "right":
                        RightCommand(matrix, firstNumCommand, secondNumCommand);
                        break;
                    case "down":
                        DownCommand(matrix, firstNumCommand, secondNumCommand);
                        break;
                    case "up":
                        UpCommand(matrix, firstNumCommand, secondNumCommand);
                        break;
                }
            }

            int countNumber = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int coll = 0; coll < matrix.GetLength(1); coll++)
                {
                    if (matrix[row, coll] != countNumber)
                    {
                        SearchNumberToSwap(matrix, countNumber, row, coll);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    countNumber++;
                }
            }
        }

        private static void SearchNumberToSwap(int[,] matrix, int countNumber, int row, int coll)
        {
            bool breakFirstLoop = false;

            for (int rowSearch = 0; rowSearch < matrix.GetLength(0); rowSearch++)
            {
                for (int collSearch = 0; collSearch < matrix.GetLength(1); collSearch++)
                {
                    if (matrix[rowSearch, collSearch] == countNumber)
                    {
                        Console.WriteLine($"Swap ({ row }, { coll }) with ({ rowSearch }, { collSearch })");
                        matrix[rowSearch, collSearch] = matrix[row, coll];
                        matrix[row, coll] = countNumber;
                        breakFirstLoop = true;
                        break;
                    }
                }

                if (breakFirstLoop)
                {
                    break;
                }
            }
        }

        private static void LeftCommand(int[,] matrix, int firstNumCommand, int secondNumCommand)
        {
            for (int left = 0; left < secondNumCommand % matrix.GetLength(0); left++)
            {
                int memNum = matrix[firstNumCommand, 0];
                for (int y = 0; y < matrix.GetLength(1) - 1; y++)
                {
                    matrix[firstNumCommand, y] = matrix[firstNumCommand, y + 1];
                }
                matrix[firstNumCommand, matrix.GetLength(1) - 1] = memNum;
            }
        }

        private static void RightCommand(int[,] matrix, int firstNumCommand, int secondNumCommand)
        {
            for (int right = 0; right < secondNumCommand % matrix.GetLength(0); right++)
            {
                int memNum = matrix[firstNumCommand, matrix.GetLength(1) - 1];
                for (int y = matrix.GetLength(1) - 1; y > 0; y--)
                {
                    matrix[firstNumCommand, y] = matrix[firstNumCommand, y - 1];
                }
                matrix[firstNumCommand, 0] = memNum;
            }
        }

        private static void DownCommand(int[,] matrix, int firstNumCommand, int secondNumCommand)
        {
            for (int up = 0; up < secondNumCommand % matrix.GetLength(1); up++)
            {
                int memNum = matrix[matrix.GetLength(0) - 1, firstNumCommand];
                for (int y = matrix.GetLength(0) - 1; y > 0; y--)
                {
                    matrix[y, firstNumCommand] = matrix[y - 1, firstNumCommand];
                }
                matrix[0, firstNumCommand] = memNum;
            }
        }

        private static void UpCommand(int[,] matrix, int firstNumCommand, int secondNumCommand)
        {
            for (int down = 0; down < secondNumCommand % matrix.GetLength(1); down++)
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
}
