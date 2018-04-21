using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        int NumOfrow = int.Parse(Console.ReadLine());
        string[,] room = new string[NumOfrow, 2 * NumOfrow];

        for (int i = 0; i < NumOfrow; i++)
        {
            string rowOfRoom = Console.ReadLine();

            int count = 0;
            foreach (var r in rowOfRoom)
            {
                room[i, count] = r.ToString();
                count++;
            }
        }

        string directions = Console.ReadLine();

        bool isDead = false;
        while (isDead)
        {
            for (int row = 0; row < room.GetLength(0); row++)
            {
                for (int col = 0; col < room.GetLength(1); col++)
                {
                    if (room[row, col] != ".")
                    {

                    }
                }
            }
        }
    }
}

