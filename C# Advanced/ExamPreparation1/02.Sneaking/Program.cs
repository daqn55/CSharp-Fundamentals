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

        string rowOfRoom = Console.ReadLine();
        string[,] room = new string[NumOfrow, rowOfRoom.Length];

        for (int i = 0; i < NumOfrow; i++)
        {
            int count = 0;
            foreach (var r in rowOfRoom)
            {
                room[i, count] = r.ToString();
                count++;
            }
            if (i != NumOfrow - 1)
            {
                rowOfRoom = Console.ReadLine();
            }
        }

        string allDirections = Console.ReadLine();
        List<string> directions = new List<string>();
        foreach (var d in allDirections)
        {
            directions.Add(d.ToString());
        }

        Dictionary<int, int> positionsNik = new Dictionary<int, int>();
        Dictionary<int, int> positionsSam = new Dictionary<int, int>();

        for (int row = 0; row < room.GetLength(0); row++)
        {
            for (int col = 0; col < room.GetLength(1); col++)
            {
                if (room[row, col] == "N")
                {
                    positionsNik.Add(row, col);
                    break;
                }
                if (room[row, col] == "S")
                {
                    positionsSam.Add(row, col);
                    break;
                }
            }
        }

        var samRow = positionsSam.First().Key;
        var samCol = positionsSam.First().Value;
        bool isDeadSam = false;
        bool isDeadNik = false;
        bool lastDirection = false;
        while (!isDeadSam && !isDeadNik && !lastDirection)
        {
            Dictionary<int, int> leftEnemy = new Dictionary<int, int>();
            Dictionary<int, int> rightEnemy = new Dictionary<int, int>();

            for (int i = 0; i < directions.Count; i++)
            {
                leftEnemy.Clear();
                rightEnemy.Clear();

                for (int row = 0; row < room.GetLength(0); row++)
                {
                    bool rightEnemyFound = false;
                    bool leftEnemyFound = false;

                    for (int col = 0; col < room.GetLength(1); col++)
                    {
                        if (room[row, col] == "b" && !rightEnemyFound)
                        {
                            room[row, col] = ".";

                            if (col == room.GetLength(1) - 1)
                            {
                                room[row, col] = "d";
                                leftEnemy.Add(row, col + 1);
                                leftEnemyFound = true;
                            }
                            else
                            {
                                room[row, col + 1] = "b";
                                rightEnemy.Add(row, col + 1);
                                rightEnemyFound = true;
                            }

                        }
                        else if (room[row, col] == "d" && !leftEnemyFound)
                        {

                            room[row, col] = ".";
                            if (col == 0)
                            {
                                room[row, col] = "b";
                                rightEnemy.Add(row, 0);
                                rightEnemyFound = true;
                            }
                            else
                            {
                                room[row, col - 1] = "d";
                                leftEnemy.Add(row, col - 1);
                                leftEnemyFound = true;
                            }
                        }
                    }
                }

                switch (directions[i])
                {
                    case "U":
                        isDeadSam = SamDies(room, samRow, samCol, isDeadSam);
                        if (isDeadSam)
                        {
                            break;
                        }
                        room[samRow, samCol] = ".";
                        room[samRow - 1, samCol] = "S";
                        samRow = samRow - 1;

                        if (positionsNik.First().Key == samRow)
                        {
                            room[positionsNik.First().Key, positionsNik.First().Value] = "X";
                            isDeadNik = true;
                            break;
                        }
                        break;
                    case "D":
                        isDeadSam = SamDies(room, samRow, samCol, isDeadSam);
                        if (isDeadSam)
                        {
                            break;
                        }
                        room[samRow, samCol] = ".";
                        room[samRow + 1, samCol] = "S";
                        samRow = samRow + 1;

                        if (positionsNik.First().Key == samRow)
                        {
                            room[positionsNik.First().Key, positionsNik.First().Value] = "X";
                            isDeadNik = true;
                            break;
                        }
                        break;
                    case "L":
                        isDeadSam = SamDies(room, samRow, samCol, isDeadSam);
                        if (isDeadSam)
                        {
                            break;
                        }
                        room[samRow, samCol] = ".";
                        room[samRow, samCol - 1] = "S";
                        samCol = samCol - 1;
                        break;
                    case "R":
                        isDeadSam = SamDies(room, samRow, samCol, isDeadSam);
                        if (isDeadSam)
                        {
                            break;
                        }
                        room[samRow, samCol] = ".";
                        room[samRow, samCol + 1] = "S";
                        samCol = samCol + 1;
                        break;
                    case "W":
                        isDeadSam = SamDies(room, samRow, samCol, isDeadSam);
                        break;
                }

                if (isDeadSam || isDeadNik)
                {
                    break;
                }
                if (i == directions.Count - 1)
                {
                    lastDirection = true;
                }
            }
        }

        if (isDeadSam)
        {
            Console.WriteLine($"Sam died at {samRow}, {samCol}");
        }
        else if (isDeadNik)
        {
            Console.WriteLine("Nikoladze killed!");
        }
        for (int row = 0; row < room.GetLength(0); row++)
        {
            for (int col = 0; col < room.GetLength(1); col++)
            {
                Console.Write(room[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static bool SamDies(string[,] room, int samRow, int samCol, bool isDeadSam)
    {
        for (int enemy = 0; enemy < room.GetLength(1); enemy++)
        {
            if (room[samRow, enemy] == "d")
            {
                if (enemy > samCol)
                {
                    room[samRow, samCol] = "X";
                    isDeadSam = true;
                    break;
                }
            }
            else if (room[samRow, enemy] == "b")
            {
                if (enemy < samCol)
                {
                    room[samRow, samCol] = "X";
                    isDeadSam = true;
                    break;
                }
            }
        }

        return isDeadSam;
    }
}

