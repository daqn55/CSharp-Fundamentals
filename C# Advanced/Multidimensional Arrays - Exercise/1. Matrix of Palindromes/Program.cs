using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Matrix_of_Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 0;
            for (int row = 0; row < n[0]; row++)
            {
                for (int coll = 0; coll < n[1]; coll++)
                {
                    Console.Write((char)(97 + count));
                    Console.Write((char)(97 + count + coll));
                    Console.Write((char)(97 + count) + " ");
                }
                Console.WriteLine();
                count++;
            }
        }
    }
}
