using System;
using System.Collections.Generic;

namespace _01.Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string args = string.Empty;
            var fullWindow = greenLight + freeWindow;
            var indexHitedToPrind = 0;
            var hitedCar = "";
            var countOfPassedCars = 0;
            var carPassed = true;
            var lastCarLenght = 0;

            while ((args = Console.ReadLine()) != "END")
            {

                if (args == "green")
                {
                    var secondsLeftGreen = greenLight;

                    while (carPassed)
                    {
                        var currentCar = "";
                        if (cars.Count > 0)
                        {
                            currentCar = cars.Dequeue();
                            if (secondsLeftGreen > 0)
                            {
                                countOfPassedCars++;
                            }
                        }
                        else
                        {
                            break;
                        }

                        for (int i = 0; i < secondsLeftGreen; i++)
                        {
                            if (i < currentCar.Length)
                            {
                                indexHitedToPrind = i;
                            }
                            else
                            {
                                secondsLeftGreen -= i;
                                break;
                            }
                            
                        }

                        if (secondsLeftGreen >= 0 && indexHitedToPrind == currentCar.Length-1)
                        {
                            carPassed = true;
                            indexHitedToPrind = 0;
                        }
                        else
                        {
                            secondsLeftGreen = 0;
                        }

                        var index = indexHitedToPrind;
                        if (secondsLeftGreen == 0 && index < currentCar.Length-1)
                        {
                            for (int i = 1; i <= freeWindow; i++)
                            {
                                if ((i + index) < currentCar.Length)
                                {
                                    hitedCar = currentCar;
                                    indexHitedToPrind = i + index;
                                }
                                else
                                {
                                    carPassed = true;
                                    break;
                                }
                                carPassed = false;
                            }
                        }
                        
                    }
                }
                else
                {
                    cars.Enqueue(args);
                }

                if (!carPassed)
                {
                    break;
                }
            }

            if (carPassed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{countOfPassedCars} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitedCar} was hit at {hitedCar[indexHitedToPrind+1]}.");
            }
        }
    }
}
