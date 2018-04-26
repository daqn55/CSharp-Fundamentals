using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ParkingFeud
{
    class Program
    {
        static void Main()
        {
            int[] rowsAndCol = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = rowsAndCol[0];
            int col = rowsAndCol[1];
            string[,] matrix = new string[(row + (row - 1)), (col + 2)];

            int samEntrance = int.Parse(Console.ReadLine());

            int spot = 1;
            for (int r = 0; r < matrix.GetLength(0); r += 2)
            {
                char symbol = (char)65;
                for (int c = 1; c < matrix.GetLength(1) - 1; c++)
                {
                    matrix[r, c] = symbol.ToString() + spot;
                    symbol++;
                }
                spot++;
            }

            int driverCount = 1;
            for (int r = 1; r < matrix.GetLength(0); r += 2)
            {
                if (r == samEntrance)
                {
                    matrix[r, 0] = "Sam";
                }
                else
                {
                    matrix[r, 0] = "Driver" + driverCount;
                    driverCount++;
                }
            }

            bool samIsParcked = false;
            string nameDriver = "";
            Dictionary<string, int> driversCount = new Dictionary<string, int>();
            int nextDriver = 1;
            bool samCanPark = true;
            string spotToPrint = "";
            string[] parkingSpots = Console.ReadLine().Split();

            int secondDriverSpot = 0;
            while (true)
            {
                int count = 0;
                secondDriverSpot = -1;
                for (int y = 0; y < parkingSpots.Length; y++)
                {
                    if (!samCanPark)
                    {
                        break;
                    }
                    for (int i = 1; i < parkingSpots.Length; i++)
                    {
                        if (parkingSpots[y] == parkingSpots[i])
                        {
                            samCanPark = false;
                            secondDriverSpot = i;
                            break;
                        }
                        else
                        {
                            samCanPark = true;
                        }
                    }
                }

                while (nextDriver < matrix.GetLength(0))
                {
                    bool haveDriver = false;
                    bool isReverse = false;
                    int countBoxes = -1;
                    if (driversCount.Count == driverCount)
                    {
                        for (int r = nextDriver; r < matrix.GetLength(0); r += 2)
                        {
                            if (isReverse)
                            {
                                for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                                {
                                    if (c == 0)
                                    {
                                        countBoxes += 2;
                                        isReverse = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (parkingSpots[count] == matrix[r - 1, c] || parkingSpots[count] == matrix[r + 1, c])
                                        {
                                            countBoxes++;
                                            driversCount.Add(nameDriver, countBoxes);
                                            samIsParcked = true;
                                            break;
                                        }
                                        else
                                        {
                                            countBoxes++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int c = 0; c < matrix.GetLength(1); c++)
                                {
                                    if (matrix[r, c] != null && !haveDriver)
                                    {
                                        nameDriver = matrix[r, c];
                                        haveDriver = true;
                                    }

                                    if (c == matrix.GetLength(1) - 1)
                                    {
                                        countBoxes += 2;
                                        isReverse = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (parkingSpots[count] == matrix[r - 1, c] || parkingSpots[count] == matrix[r + 1, c])
                                        {
                                            countBoxes++;
                                            driversCount[nameDriver] = (driversCount[nameDriver] * 2) + countBoxes;
                                            matrix[r, c] = nameDriver;
                                            samIsParcked = true;
                                            break;
                                        }
                                        else
                                        {
                                            countBoxes++;
                                        }
                                    }
                                }
                            }

                            if (samIsParcked)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int r = nextDriver; r < matrix.GetLength(0); r += 2)
                        {
                            if (isReverse)
                            {
                                for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                                {
                                    if (c == 0)
                                    {
                                        countBoxes += 2;
                                        isReverse = false;
                                        break;
                                    }
                                    else
                                    {
                                        if (parkingSpots[count] == matrix[r - 1, c] || parkingSpots[count] == matrix[r + 1, c])
                                        {
                                            countBoxes++;
                                            driversCount.Add(nameDriver, countBoxes);
                                            samIsParcked = true;
                                            break;
                                        }
                                        else
                                        {
                                            countBoxes++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int c = 0; c < matrix.GetLength(1); c++)
                                {
                                    if (matrix[r, c] != null && !haveDriver)
                                    {
                                        nameDriver = matrix[r, c];
                                        haveDriver = true;
                                    }

                                    if (c == matrix.GetLength(1) - 1)
                                    {
                                        countBoxes += 2;
                                        isReverse = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (parkingSpots[count] == matrix[r - 1, c] || parkingSpots[count] == matrix[r + 1, c])
                                        {
                                            countBoxes++;
                                            driversCount.Add(nameDriver, countBoxes);
                                            matrix[r, c] = nameDriver;
                                            samIsParcked = true;
                                            break;
                                        }
                                        else
                                        {
                                            countBoxes++;
                                        }
                                    }
                                }
                            }

                            if (samIsParcked)
                            {
                                break;
                            }
                        }
                    }

                    count++;
                    nextDriver += 2;
                }

                if (!samCanPark)
                {
                    nextDriver = 1;
                    int littleCount = 0;
                    int toCheck = 0;
                    foreach (var i in driversCount)
                    {
                        if (littleCount == secondDriverSpot)
                        {
                            toCheck = i.Value;
                        }
                        littleCount++;
                    }
                    if (driversCount["Sam"] > toCheck)
                    {
                        spotToPrint = parkingSpots[samEntrance - 1];
                    }
                    else
                    {
                        spotToPrint = parkingSpots[samEntrance - 1];
                        break;
                    }
                    if (secondDriverSpot == -1)
                    {
                        spotToPrint = parkingSpots[samEntrance - 1];
                        break;
                    }

                    parkingSpots = Console.ReadLine().Split();


                }
                else
                {
                    spotToPrint = parkingSpots[samEntrance - 1];
                    break;
                }
            }


            Console.WriteLine($"Parked successfully at {spotToPrint}.");
            Console.WriteLine($"Total Distance Passed: {driversCount["Sam"]}");


        }
    }
}
