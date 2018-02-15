using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Reverse_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            foreach (var i in stack)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
