using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var listPetrol = new List<decimal>();
            var listPumps = new List<decimal>();

            for (int i = 0; i < n; i++)
            {
                decimal[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();

                listPetrol.Add(values[0]);
                listPumps.Add(values[1]);
            }

            int count = 0;
            decimal kilometres = 0;
            decimal petrol = 0;
            int countStartPosition = 0;
            long currentCountPos = 0;
            while (true)
            {
                if (listPetrol[countStartPosition] < listPumps[countStartPosition])
                {
                    count++;
                    countStartPosition++;
                    continue;
                }
                petrol += listPetrol[count];
                kilometres = listPumps[count];
                petrol -= listPumps[count];
                if (petrol < 0)
                {
                    countStartPosition++;
                    count = countStartPosition;
                    petrol = 0;
                    kilometres = 0;
                    continue;
                }
                if (petrol < kilometres && count == listPumps.Count-1)
                {
                    countStartPosition++;
                    count = countStartPosition;
                    petrol = 0;
                    kilometres = 0;
                    continue;
                }
                if (countStartPosition > 0 && count == listPumps.Count-1)
                {
                    count = 0;
                    continue;
                }
                if (currentCountPos == listPumps.Count-1 && petrol >= kilometres)
                {
                    Console.WriteLine(countStartPosition);
                    break;
                }
                count++;
                currentCountPos++;
            }
        }
    }
}
